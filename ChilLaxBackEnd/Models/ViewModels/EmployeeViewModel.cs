using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ChilLaxBackEnd.Models.ViewModels
{
    public class EmployeeViewModel
    {
        private Employee _employee;

        public EmployeeViewModel()
        {
            _employee = new Employee();
        }
        public Employee empvm
        {
            get { return _employee; }
            set { _employee = value; }
        }

        [DisplayName("狀態")]
        public bool available
        {
            get { return _employee.available; }
            set { _employee.available = value; }
        }

        [DisplayName("編號")]
        public int emp_id
        {
            get { return _employee.emp_id; }
            set { _employee.emp_id = value; }
        }

        [DisplayName("權限")]
        [Required(ErrorMessage = "權限必須填寫")]
        public bool emp_permission
        {
            get { return _employee.emp_permission; }
            set { _employee.emp_permission = value; }
        }

        [DisplayName("姓名")]
        [Required(ErrorMessage = "客戶名稱必須填寫")]
        public string emp_name
        {
            get { return _employee.emp_name; }
            set { _employee.emp_name = value; }
        }

        [DisplayName("帳號")]
        [Required(ErrorMessage = "帳號必須填寫")]
        public string emp_account
        {
            get { return _employee.emp_account; }
            set { _employee.emp_account = value; }
        }

        [DisplayName("密碼")]
        [Required(ErrorMessage = "密碼必須填寫")]
        public string emp_password
        {
            get { return _employee.emp_password; }
            set { _employee.emp_password = value; }
        }

        public Employee GetEmployee()
        {
            return _employee;
        }

        public List<Employee> queryBySql(string sql, List<SqlParameter> paras)
        {
            List<Employee> list = new List<Employee>();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source =.; Initial Catalog = ChilLax; Integrated Security = True;";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            if (paras != null)
                cmd.Parameters.AddRange(paras.ToArray());

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Employee x = new Employee();
                x.emp_id = (int)reader["emp_id"];
                x.emp_permission = Convert.ToBoolean(reader["emp_permission"]);
                x.emp_account = reader["emp_account"].ToString();
                x.emp_password = reader["emp_password"].ToString();
                x.emp_name = reader["emp_name"].ToString();
                list.Add(x);
            }
            con.Close();
            return list;
        }


        public bool is驗證帳號與密碼(string txtAccount, string txtPassword)
        {
            string sql = "SELECT * FROM Employee WHERE ";
            sql += "emp_account = @K_ACCOUNT ";
            sql += "AND emp_password = @K_PASSWORD";

            List<SqlParameter> paras = new List<SqlParameter>();
            paras.Add(new SqlParameter("K_ACCOUNT", (object)txtAccount));
            paras.Add(new SqlParameter("K_PASSWORD", (object)txtPassword));
            List<Employee> datas = queryBySql(sql, paras);//queryBySql為sql的查詢語法。
            if (datas.Count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}