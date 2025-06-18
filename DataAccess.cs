using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dms
{
    public class DataAccess
    {
        private void ShowError(string message, Exception ex)
        {
            MessageBox.Show($"{message}: {ex.Message}", "数据库错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private DataTable ExecuteQuery(string sql, List<SqlParameter> parameters = null)
        {
            try
            {
                using (SqlConnection conn = ConnectDB.getInstance().getConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters.ToArray());
                        }
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        return ds.Tables.Count > 0 ? ds.Tables[0] : null;
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError("执行查询时出错", ex);
                return null;
            }
        }

        private int ExecuteNonQuery(string sql, List<SqlParameter> parameters = null)
        {
            try
            {
                using (SqlConnection conn = ConnectDB.getInstance().getConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters.ToArray());
                        }
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError("执行更新时出错", ex);
                return -1;
            }
        }

        public DataTable QueryDormitories(string dormNumber)
        {
            string sql = "SELECT * FROM dormitory WHERE 1=1";
            List<SqlParameter> parameters = new List<SqlParameter>();
            
            if (!string.IsNullOrEmpty(dormNumber))
            {
                sql += " AND dorm_num LIKE @dormNumber";
                parameters.Add(new SqlParameter("@dormNumber", "%" + dormNumber + "%"));
            }
            
            return ExecuteQuery(sql, parameters);
        }

        public DataTable QueryStudents(string studentId, string studentName)
        {
            string sql = "SELECT * FROM student WHERE 1=1";
            List<SqlParameter> parameters = new List<SqlParameter>();
            
            if (!string.IsNullOrEmpty(studentId))
            {
                sql += " AND stu_id LIKE @studentId";
                parameters.Add(new SqlParameter("@studentId", "%" + studentId + "%"));
            }
            
            if (!string.IsNullOrEmpty(studentName))
            {
                sql += " AND stu_name LIKE @studentName";
                parameters.Add(new SqlParameter("@studentName", "%" + studentName + "%"));
            }
            
            return ExecuteQuery(sql, parameters);
        }

        public DataTable QueryVisitors(string visitorId, string visitorName)
        {
            string sql = "SELECT * FROM visitor WHERE 1=1";
            List<SqlParameter> parameters = new List<SqlParameter>();
            
            if (!string.IsNullOrEmpty(visitorId))
            {
                sql += " AND vis_id LIKE @visitorId";
                parameters.Add(new SqlParameter("@visitorId", "%" + visitorId + "%"));
            }
            
            if (!string.IsNullOrEmpty(visitorName))
            {
                sql += " AND vis_name LIKE @visitorName";
                parameters.Add(new SqlParameter("@visitorName", "%" + visitorName + "%"));
            }
            
            return ExecuteQuery(sql, parameters);
        }

        public int EmptyRoom(string dormNumber)
        {
            string sql = "UPDATE dormitory SET empty=1 WHERE dorm_num=@dormNumber";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@dormNumber", dormNumber)
            };
            return ExecuteNonQuery(sql, parameters);
        }

        public DataTable GetDormitoryDetails(string dormNumber)
        {
            string sql = "SELECT * FROM dormitory WHERE dorm_num = @dormNumber";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@dormNumber", dormNumber)
            };
            return ExecuteQuery(sql, parameters);
        }

        public int UpdateDormitoryStatus(string dormNumber, bool isEmpty)
        {
            string sql = "UPDATE dormitory SET empty = @isEmpty WHERE dorm_num = @dormNumber";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@dormNumber", dormNumber),
                new SqlParameter("@isEmpty", isEmpty ? 1 : 0)
            };
            return ExecuteNonQuery(sql, parameters);
        }

        public DataTable GetAllStudents()
        {
            string sql = "SELECT * FROM student";
            return ExecuteQuery(sql);
        }

        public DataTable GetStudentById(string studentId)
        {
            string sql = "SELECT * FROM student WHERE stu_id = @studentId";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@studentId", studentId)
            };
            return ExecuteQuery(sql, parameters);
        }

        public int AddStudent(string id, string name, string gender, string dormNumber)
        {
            string sql = "INSERT INTO student (stu_id, stu_name, stu_sex, dorm_num) VALUES (@id, @name, @gender, @dormNumber)";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@id", id),
                new SqlParameter("@name", name),
                new SqlParameter("@gender", gender),
                new SqlParameter("@dormNumber", dormNumber)
            };
            return ExecuteNonQuery(sql, parameters);
        }

        public int UpdateStudent(string id, string name, string gender, string dormNumber)
        {
            string sql = "UPDATE student SET stu_name = @name, stu_sex = @gender, dorm_num = @dormNumber WHERE stu_id = @id";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@id", id),
                new SqlParameter("@name", name),
                new SqlParameter("@gender", gender),
                new SqlParameter("@dormNumber", dormNumber)
            };
            return ExecuteNonQuery(sql, parameters);
        }

        public int DeleteStudent(string id)
        {
            string sql = "DELETE FROM student WHERE stu_id = @id";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@id", id)
            };
            return ExecuteNonQuery(sql, parameters);
        }

        public DataTable GetAllVisitors()
        {
            string sql = "SELECT * FROM visitor";
            return ExecuteQuery(sql);
        }

        public int AddVisitor(string id, string name, string gender, string dormNumber, DateTime visitTime)
        {
            string sql = "INSERT INTO visitor (vis_id, vis_name, vis_sex, dorm_num, vis_time) VALUES (@id, @name, @gender, @dormNumber, @visitTime)";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@id", id),
                new SqlParameter("@name", name),
                new SqlParameter("@gender", gender),
                new SqlParameter("@dormNumber", dormNumber),
                new SqlParameter("@visitTime", visitTime)
            };
            return ExecuteNonQuery(sql, parameters);
        }

        public int DeleteVisitor(string id)
        {
            string sql = "DELETE FROM visitor WHERE vis_id = @id";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@id", id)
            };
            return ExecuteNonQuery(sql, parameters);
        }
    }
}
