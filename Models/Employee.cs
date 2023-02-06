using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace EMS.Models
{
    public class Employee
    {
        public static string ConnectionString;

        [Key] public int EmployeeId { get; set; }

        [Required(ErrorMessage = "First name is required!")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required!")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Eamil is required!")]
        [EmailAddress]
        public string EmailId { get; set; }

        [ScaffoldColumn(false)]
        public DateTime CreatedDate { get; set; }

        [ScaffoldColumn(false)]
        public DateTime UpdatedDate { get; set; }

        public static List<Employee> GetAllEmployees()
        {
            List<Employee> list = new List<Employee>();

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Employee.ConnectionString;

            try
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Employees;";

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Employee
                    {
                        EmployeeId = reader.GetInt32("EmployeeId"),
                        FirstName = reader.GetString("FirstName"),
                        LastName = reader.GetString("LastName"),
                        EmailId = reader.GetString("EmailId")
                    });
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                conn.Close();
            }

            return list;
        }

        public static Employee GetSingleEmployee(int id)
        {
            Employee emp = null;

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Employee.ConnectionString;

            try
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Employees WHERE EmployeeId=@Id;";
                cmd.Parameters.AddWithValue("@Id", id);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    emp = new Employee
                    {
                        EmployeeId = reader.GetInt32("EmployeeId"),
                        FirstName = reader.GetString("FirstName"),
                        LastName = reader.GetString("LastName"),
                        EmailId = reader.GetString("EmailId")
                    };
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                conn.Close();
            }

            return emp;
        }

        public static void InsertEmployee(Employee emp)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Employee.ConnectionString;

            try
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO Employees VALUES (@Id, @FirstName, @LastName, @EmailId, @CreatedDate, @UpdatedDate);";
                cmd.Parameters.AddWithValue("@Id", emp.EmployeeId);
                cmd.Parameters.AddWithValue("@FirstName", emp.FirstName);
                cmd.Parameters.AddWithValue("@LastName", emp.LastName);
                cmd.Parameters.AddWithValue("@EmailId", emp.EmailId);
                cmd.Parameters.AddWithValue("@CreatedDate", emp.CreatedDate);
                cmd.Parameters.AddWithValue("@UpdatedDate", emp.UpdatedDate);

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                conn.Close();
            }
        }

        public static void UpdateEmployee(Employee emp)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Employee.ConnectionString;

            try
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE Employees SET FirstName=@FirstName, LastName=@LastName, EmailId=@EmailId, UpdatedDate=@UpdatedDate WHERE EmployeeId=@EmployeeId;";
                cmd.Parameters.AddWithValue("@EmployeeId", emp.EmployeeId);
                cmd.Parameters.AddWithValue("@FirstName", emp.FirstName);
                cmd.Parameters.AddWithValue("@LastName", emp.LastName);
                cmd.Parameters.AddWithValue("@EmailId", emp.EmailId);
                cmd.Parameters.AddWithValue("@UpdatedDate", emp.UpdatedDate);

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                conn.Close();
            }
        }

        public static void DeleteEmployee(int id)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Employee.ConnectionString;

            try
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM Employees WHERE EmployeeId=@Id;";
                cmd.Parameters.AddWithValue("@Id", id);

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
