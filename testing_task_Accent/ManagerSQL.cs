using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testing_task_Accent
{
    public class ManagerSQL
    {
        private string _connectionString;

        public void connectDB(SaveSystem setting) 
        {
            string server = setting.ServerSQL;
            string nameDB = setting.NameDB;
            string user = setting.NameUser;
            string password = setting.PasswordUser;

            _connectionString = $"Server={server};Database={nameDB};User Id={user};Password={password};";

            Debug.WriteLine(_connectionString);

            testConnect();
        }

        public bool testConnect() 
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open(); 
                    connection.Close();
                    MessageBox.Show("Подключение успешно!", "Статус подключения", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения: {ex.Message}", "Статус подключения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public DataTable selectViewTable() 
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand("cp_persons_get", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            if (reader != null)
            {
                dt.Load(reader);
            }
            else 
            {
                dt = null;
            }

                connection.Close();
            return dt;
        }

        public DataTable selectSortAndFilterViewTable(string fullName, string status, string depo, string post, string dir, string sortColumn) 
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand("cp_persons_get_filter_and_sort", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            //фильтры
            cmd.Parameters.AddWithValue("@full_name", fullName ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@status_name", status ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@department_name", depo ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@post_name", post ?? (object)DBNull.Value);
            //сортировка
            cmd.Parameters.AddWithValue("@sortDir", dir ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@sortColumn", sortColumn ?? (object)DBNull.Value);


            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            if (reader != null)
            {
                dt.Load(reader);
            }
            else
            {
                dt = null;
            }
            connection.Close();
            return dt;
        }

        public DataTable selectDepsTableColumnName()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand("cp_deps_get", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            if (reader != null)
            {
                dt.Load(reader);
            }
            else
            {
                dt = null;
            }

            connection.Close();
            return dt;
        }

        public DataTable selectPostTableColumnName()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand("cp_post_get", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            if (reader != null)
            {
                dt.Load(reader);
            }
            else
            {
                dt = null;
            }

            connection.Close();
            return dt;
        }

        public DataTable selectStatusTableColumnName()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand("cp_status_get", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            if (reader != null)
            {
                dt.Load(reader);
            }
            else
            {
                dt = null;
            }

            connection.Close();
            return dt;
        }

        public int countStatusPerson(string status) 
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand("cp_count_persons_by_status", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", status ?? (object)DBNull.Value);
            SqlDataReader reader = cmd.ExecuteReader();
            int count;
            if (reader != null) 
            {
                reader.Read();
                count = reader.GetInt32(0);
            }
            else 
            {
                return 0;
            }
            connection.Close();
            return count;
        }

        public DataTable timePeriodPerson(string status, DateTime start, DateTime end)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand("cp_count_dismissed_hired_by_date", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@startDate", start);
            cmd.Parameters.AddWithValue("@endDate", end);
            cmd.Parameters.AddWithValue("@statusType", status ?? (object)DBNull.Value);
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            if (reader != null)
            {
                dt.Load(reader);
            }
            else
            {
                dt = null;
            }

            connection.Close();
            return dt;
        }

    }
}
