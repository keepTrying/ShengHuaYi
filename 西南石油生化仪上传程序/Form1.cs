using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;

namespace 西南石油生化仪上传程序
{
    public partial class Form1 : Form
    {
        private String str_access_conn;
        private String str_access_path;
        private String str_access_copy;
        private static String str_sqlsever_conn = @"server=192.168.1.252;database=jk2007;user=user26;pwd=welcome";
        private OleDbConnection access_conn;
        private SqlConnection sql_conn;
        private DataTable dt_name;
        private DataTable dt_item;
        private DataSet ds_access;
        private int row_name;
        public Form1()
        {
            
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox_code.Focus();

            dateTimePicker_start.Value = DateTime.Now.Date;
            dateTimePicker_end.Value = DateTime.Now.Date;

            str_access_conn = ConfigurationManager.AppSettings["str_access_conn"];
            str_access_path = ConfigurationManager.AppSettings["str_access_source"];
            int end_index = str_access_conn.IndexOf(';',45);
            str_access_copy = str_access_conn.Substring(45,end_index-45);
            try
            {
                sql_conn = new SqlConnection(str_sqlsever_conn);
                sql_conn.Open();
            }
            catch
            {
                MessageBox.Show("连接sql_sever数据库失败");
                Environment.Exit(0);
            }
                       
            this.refresh_access();

            if (dataGridView_name.Rows.Count == 0) {
          
                MessageBox.Show("没有这个时间段的本地数据！");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = null;
            //dt_name = new DataTable();
            //OleDbConnection access_conn = new OleDbConnection(str_access_conn);
            //string str_sql = "select Name as 姓名,QuestDate as 时间 from PatientInfo where QuestDate between #" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + " 00:00:00# and #" + dateTimePicker2.Value.ToString("yyyy/MM/dd") + " 23:59:59# order by QuestDate ASC";
            //OleDbDataAdapter da = new OleDbDataAdapter(str_sql, access_conn);

            //da.Fill(dt_name);
            //dataGridView1.DataSource = dt_name;
            this.refresh_access();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row == -1)
            {
                return;
            }
            textBox_code.Focus();
            row_name = row;
            int order = Convert.ToInt32(dataGridView_name.Rows[row].Cells[0].Value);
            String name = (String)dataGridView_name.Rows[row].Cells[1].Value;
            DateTime time = Convert.ToDateTime(dataGridView_name.Rows[row].Cells[2].Value);
            dt_item = new DataTable();
            dt_item.Columns.Add("项目");
            dt_item.Columns.Add("结果");
            dt_item.Columns.Add("结论");
            foreach (DataRow ro in ds_access.Tables["join"].Rows) {
                if (Convert.ToString(ro["pi.Name"]) == name && Convert.ToDateTime(ro["TestTime"]) == time&&Convert.ToInt32(ro["SampleID"])==order)
                {
                    dt_item.LoadDataRow(new Object[]{ro["ItemName"],ro["TestResult"],ro["ResDesc"]},true);
                }
            }
            dt_item.AcceptChanges();
            dataGridView_data.DataSource = null;
            dataGridView_data.DataSource = dt_item;
            dataGridView_data.Columns[0].FillWeight = 50;
            dataGridView_data.Columns[1].FillWeight = 30;
            dataGridView_data.Columns[2].FillWeight = 20;

        }


        private void refresh_access() {
            try
            {
                if (access_conn != null)
                {
                    if (access_conn.State != ConnectionState.Closed) access_conn.Close();
                    access_conn.Dispose();
                }
                int len = str_access_copy.LastIndexOf('\\');
                String directory = str_access_copy.Substring(0,len);
                if (!System.IO.Directory.Exists(directory))
                {
                    System.IO.Directory.CreateDirectory(directory);
                }
                System.IO.File.Copy(str_access_path,str_access_copy,true);

                access_conn = new OleDbConnection(str_access_conn);
                access_conn.Open();
            }
            catch
            {
                MessageBox.Show("连接Access数据库失败");
                Environment.Exit(0);
            }

            OleDbDataAdapter da;

            dt_name = new DataTable();
            string str_sql = "select sp.ID as 序号,pi.Name as 姓名,pi.QuestDate as 时间 from (PatientInfo as pi left join Sample as sp on sp.PatientID=pi.ID and sp.QuestDate=pi.QuestDate)where pi.QuestDate between #" + dateTimePicker_start.Value.ToString("yyyy/MM/dd") + " 00:00:00# and #" + dateTimePicker_end.Value.ToString("yyyy/MM/dd") + " 23:59:59# order by sp.ID ASC";
            da = new OleDbDataAdapter(str_sql, access_conn);
            da.Fill(dt_name);
            dataGridView_name.DataSource = null;
            dataGridView_name.DataSource = dt_name;
            dataGridView_name.Columns[0].FillWeight = 25;
            dataGridView_name.Columns[1].FillWeight = 30;
            dataGridView_name.Columns[2].FillWeight = 45;

            ds_access = new DataSet();

            string sql;

            //sql = "select TestTime,ItemID,ItemType,SampleID,TestResult,LowRef,HighRef from TestDetail";
            //da = new OleDbDataAdapter(sql, access_conn);
            //da.Fill(ds_access, "TestDetail");

            //sql = "select ID,Name from Doctor";
            //da = new OleDbDataAdapter(sql, access_conn);
            //da.Fill(ds_access, "Doctor");

            //sql = "select ID,QuestDate,Name,Sex,Age from PatientInfo ";
            //da = new OleDbDataAdapter(sql, access_conn);
            //da.Fill(ds_access, "PatientInfo");

            //sql = "select ID,QuestDate,PatientID,ExamDocID from Sample";
            //da = new OleDbDataAdapter(sql, access_conn);
            //da.Fill(ds_access, "Sample");

            sql = "select ID,FullName from TestDefine";
            da = new OleDbDataAdapter(sql, access_conn);
            da.Fill(ds_access, "TestDefine");

            sql = "select ID,FullName from TestManual";
            da = new OleDbDataAdapter(sql, access_conn);
            da.Fill(ds_access, "TestManual");

            sql = "select ID,FullName from TestCalc";
            da = new OleDbDataAdapter(sql, access_conn);
            da.Fill(ds_access, "TestCalc");

            sql = "select td.TestTime,td.ItemID,td.ItemType,td.SampleID,td.TestResult,td.LowRef,td.HighRef,pi.Name,pi.Sex,pi.Age,dt.Name from ((TestDetail as td left join Sample as sp on sp.ID=td.SampleID and td.TestTime=sp.QuestDate ) left join PatientInfo as pi on sp.QuestDate=pi.QuestDate and sp.PatientID=pi.ID)left join Doctor as dt on dt.ID = sp.ExamDocID where td.TestTime between #" + dateTimePicker_start.Value.ToString("yyyy/MM/dd") + " 00:00:00# and #" + dateTimePicker_end.Value.ToString("yyyy/MM/dd") + " 23:59:59# order by td.TestTime ASC";
            da = new OleDbDataAdapter(sql, access_conn);
            da.Fill(ds_access, "join");

            sql = "select 编码 as ItemCode,名称 as Name from 职业病体检_体检项目设置表 where 编码 like '17%'";
            SqlDataAdapter sqlda = new SqlDataAdapter(sql, sql_conn);
            DataTable dt_itemNo = new DataTable();
            sqlda.Fill(dt_itemNo);

            ds_access.Tables["join"].Columns.Add("ItemName");
            ds_access.Tables["join"].Columns.Add("ResDesc");
            ds_access.Tables["join"].Columns.Add("ItemCode");
            foreach (DataRow row in ds_access.Tables["join"].Rows)
            {
                int item_id = Convert.ToInt32(row["ItemID"]);
                switch (Convert.ToInt32(row["ItemType"]))
                {
                    case 0:
                        foreach (DataRow r in ds_access.Tables["TestDefine"].Rows) {
                            if (Convert.ToInt32(r["ID"])==item_id)
                            {
                                row["ItemName"] = r["FullName"];
                            }
                        }
                        break;
                    case 1:
                        foreach (DataRow r in ds_access.Tables["TestManual"].Rows)
                        {
                            if (Convert.ToInt32(r["ID"]) == item_id)
                            {
                                row["ItemName"] = r["FullName"];
                            }
                        }
                        break;
                    case 2:
                        foreach (DataRow r in ds_access.Tables["TestCalc"].Rows)
                        {
                            if (Convert.ToInt32(r["ID"]) == item_id)
                            {
                                row["ItemName"] = r["FullName"];
                            }
                        }
                        break;
                    default:
                        break;
                }

                string res = Convert.ToString(row["TestResult"]);
                double max = Convert.ToDouble(row["HighRef"]);
                double min = Convert.ToDouble(row["LowRef"]);

                switch (res)
                {
                    case "-1":
                        row["resDesc"] = "无结果";
                        break;
                    case "0":
                        row["resDesc"] = "阴性";
                        break;
                    case "1":
                        row["resDesc"] = "阳性";
                        break;
                    case "2":
                        row["resDesc"] = "弱阳性";
                        break;
                    default:
                        double res_d = Convert.ToDouble(res);
                        if (res_d > max)
                        {
                            row["resDesc"] = "偏高";
                        }
                        else if (res_d < min)
                        {
                            row["resDesc"] = "偏低";
                        }
                        else
                        {
                            row["resDesc"] = "正常";
                        }
                        break;
                }

                foreach (DataRow r_no in dt_itemNo.Rows) {
                    String item_name = (String)row["ItemName"];
                    String add="";
                    switch (item_name)
                    {
                        case "血沉":
                            item_name = "红细胞沉降率";
                            if (Convert.ToString(row["Sex"]) == "1")
                            {
                                add = "（女）";
                            }
                            else
                            {
                                add = "（男）";
                            }
                            
                            break;
                        case "钙":
                            if (Convert.ToInt32(row["Age"]) <18)
                            {
                                add = "（幼儿）";
                            }
                            else
                            {
                                add = "（成人）";
                            }
                            break;
                        default:
                            break;
                    }
                    item_name += add;
                    if (item_name == (String)r_no["Name"])
                    {
                        row["ItemCode"] = (String)r_no["ItemCode"];
                    }
                    
                }
            }
            if (dataGridView_name.Rows.Count > 0)
            {
                int order = Convert.ToInt32(dataGridView_name.Rows[0].Cells[0].Value);
                String name = (String)dataGridView_name.Rows[0].Cells[1].Value;
                DateTime time = Convert.ToDateTime(dataGridView_name.Rows[0].Cells[2].Value);
                dt_item = new DataTable();
                dt_item.Columns.Add("项目");
                dt_item.Columns.Add("结果");
                dt_item.Columns.Add("结论");
                foreach (DataRow ro in ds_access.Tables["join"].Rows)
                {
                    if (Convert.ToString(ro["pi.Name"]) == name && Convert.ToDateTime(ro["TestTime"]) == time && Convert.ToInt32(ro["SampleID"]) == order)
                    {
                        dt_item.LoadDataRow(new Object[] { ro["ItemName"], ro["TestResult"], ro["ResDesc"] }, true);
                    }
                }
                dt_item.AcceptChanges();
                dataGridView_data.DataSource = null;
                dataGridView_data.DataSource = dt_item;
                dataGridView_data.Columns[0].FillWeight = 50;
                dataGridView_data.Columns[1].FillWeight = 30;
                dataGridView_data.Columns[2].FillWeight = 20;
            }
            else
            {
                //MessageBox.Show("没有这个时间段的本地数据！");
            }



        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            String code = textBox_code.Text.Trim();
            if (code.Length != 15)
            {
                //MessageBox.Show("编码长度不对！");
                return;
            }
            try {
                Int64 temp = Convert.ToInt64(code);
            }
            catch
            {
                MessageBox.Show("编码必须为数字！");
                return;
            }
            //String sql = "select * from 职业病体检_结果信息_生化科 where 系统编号='"+code+"'";
            //SqlDataAdapter da = new SqlDataAdapter(sql, sql_conn);
            //DataTable dt = new DataTable();
            //try
            //{
            //    da.Fill(dt);
            //}
            //catch
            //{
            //    MessageBox.Show("SQL_SEVER服务器上没有本编号的数据！");
            //    return;
            //}
            //if (dt.Rows.Count == 0)
            //{
            //    MessageBox.Show("SQL_SEVER服务器上没有本编号的数据！");
            //    return;
            //}
            String sql = "select 姓名,年龄,性别,出生日期,单位名称 from 职业病体检_体检人员基本信息表 where 系统编号='" + code + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, sql_conn);
            DataTable dt = new DataTable();
            try
            {
                da.Fill(dt);
            }
            catch
            {
                MessageBox.Show("SQL_SEVER服务器上没有本编号的数据！");
                return;
            }
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("SQL_SEVER服务器上没有本编号的数据！");
                return;
            }

            dataGridView_person.DataSource = null;
            dataGridView_person.DataSource = dt;
            if (dataGridView_name.Rows.Count > 0)
            {
                for(int i = 0; i < dataGridView_name.Rows.Count; i++)
                {
                    if (dataGridView_name[i, 1].Value.ToString() == dataGridView_person[0,0].Value.ToString())
                    {
                        dataGridView_name.Rows[i].Selected=true;

                        int order = Convert.ToInt32(dataGridView_name.Rows[i].Cells[0].Value);
                        String name = (String)dataGridView_name.Rows[i].Cells[1].Value;
                        DateTime time = Convert.ToDateTime(dataGridView_name.Rows[i].Cells[2].Value);
                        dt_item = new DataTable();
                        dt_item.Columns.Add("项目");
                        dt_item.Columns.Add("结果");
                        dt_item.Columns.Add("结论");
                        foreach (DataRow ro in ds_access.Tables["join"].Rows)
                        {
                            if (Convert.ToString(ro["pi.Name"]) == name && Convert.ToDateTime(ro["TestTime"]) == time && Convert.ToInt32(ro["SampleID"]) == order)
                            {
                                dt_item.LoadDataRow(new Object[] { ro["ItemName"], ro["TestResult"], ro["ResDesc"] }, true);
                            }
                        }
                        dt_item.AcceptChanges();
                        dataGridView_data.DataSource = null;
                        dataGridView_data.DataSource = dt_item;
                        dataGridView_data.Columns[0].FillWeight = 50;
                        dataGridView_data.Columns[1].FillWeight = 30;
                        dataGridView_data.Columns[2].FillWeight = 20;
                    }
                }
            }    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox_code.Text.Trim() == "")
            {
                MessageBox.Show("请扫描条码");
                return;
            }

            if (dataGridView_name.SelectedRows==null)
            {
                MessageBox.Show("请选择要上传的数据");
                return;
            }

            int order = Convert.ToInt32(dataGridView_name.Rows[row_name].Cells[0].Value);
            String name = (String)dataGridView_name.Rows[row_name].Cells[1].Value;
            DateTime time = Convert.ToDateTime(dataGridView_name.Rows[row_name].Cells[2].Value);
            foreach (DataRow ro in ds_access.Tables["join"].Rows)
            {
                if (Convert.ToString(ro["pi.Name"]) == name && Convert.ToDateTime(ro["TestTime"]) == time && Convert.ToInt32(ro["SampleID"]) == order)
                {
                    String result = ro["TestResult"].ToString();
                    String res=result;
                    switch (result)
                    {
                        case "-1":
                            res = "无结果";
                            break;
                        case "0":
                            res = "阴性";
                            break;
                        case "1":
                            res = "阳性";
                            break;
                        case "2":
                            res = "弱阳性";
                            break;
                        default:
                            break;
                    }
                    String sql;
                    SqlCommand cmd;
                    sql = "select * from 职业病体检_结果信息_生化科 where 系统编号='"+textBox_code.Text.Trim() + "' and 体检项目='"+ro["ItemCode"]+"'";
                    cmd = new SqlCommand(sql, sql_conn);
                    SqlDataReader read = cmd.ExecuteReader();
                    if (!read.HasRows)
                    {
                        read.Close();
                        sql = "insert 职业病体检_结果信息_生化科(系统编号,体检项目,体检结果,体检医师,填写时间,单项结论) values('" + textBox_code.Text.Trim() + "','" + ro["ItemCode"] + "','" + res + "','" + ro["dt.Name"] + "','" + ro["TestTime"] + "','" + ro["ResDesc"] + "')";
                        cmd = new SqlCommand(sql, sql_conn);
                        cmd.ExecuteNonQuery();
                    }
                    else {
                        read.Close();
                        sql = "delete from 职业病体检_结果信息_生化科 where 系统编号='" + textBox_code.Text.Trim() + "';insert 职业病体检_结果信息_生化科(系统编号,体检项目,体检结果,体检医师,填写时间,单项结论) values('" + textBox_code.Text.Trim() + "','" + ro["ItemCode"] + "','" + res + "','" + ro["dt.Name"] + "','" + ro["TestTime"] + "','" + ro["ResDesc"] + "')";
                        //sql = "update 职业病体检_结果信息_生化科 set 体检结果='" + res + "',体检医师='" + ro["dt.Name"] + "',填写时间='" + ro["TestTime"] + "',单项结论='" + ro["ResDesc"] + "' where 系统编号='" + textBox_code.Text.Trim() + "' and 体检项目='" + ro["ItemCode"] + "'";
                        cmd = new SqlCommand(sql, sql_conn);
                        cmd.ExecuteNonQuery();
                        
                    }
                    

                }
            }
            DialogResult dialogRes = MessageBox.Show("上传成功");
            if (dialogRes == DialogResult.OK) {
                textBox_code.Clear();
                textBox_code.Focus();
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            access_conn.Close();
            sql_conn.Close();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            this.refresh_access();
        }

    
    }
}
