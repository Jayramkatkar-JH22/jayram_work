using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ModelBinding.Models
{
    public class Employees
    {
        [Key]
        public int EmpNo { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage ="enter the name")]
        public string Name { get; set; }
        public decimal Basic { get; set; }
        public int DeptNo { get; set; }

        public static List<Employees> GetAllEmployees()
        {
            List<Employees> emps = new List<Employees>();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JKJuly2022;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmdSelect = new SqlCommand();
                cmdSelect.Connection = cn;
                cmdSelect.CommandType = CommandType.Text;
                cmdSelect.CommandText = "Select * from Employees";
                SqlDataReader dr = cmdSelect.ExecuteReader();

                while (dr.Read())
                {
                    emps.Add(new Employees  { EmpNo= (int)dr[0], Name= (string)dr[1], Basic= (decimal)dr[2], DeptNo= (int)dr[3] }) ;   
                }
                dr.Close();
                return emps;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
            return emps;
        }

        public static Employees GetDetails(int id)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JKJuly2022;Integrated Security=True";
            try
            {
                Console.WriteLine("hiiiii0");
                Employees emp=new Employees();
                emp.EmpNo = id;

                cn.Open();
                SqlCommand cmdSelect = new SqlCommand();
                cmdSelect.Connection = cn;
                cmdSelect.CommandType = CommandType.Text;
                cmdSelect.CommandText = "Select * from Employees where EmpNo=@EmpNo";
                cmdSelect.Parameters.AddWithValue("@EmpNo", emp.EmpNo);
               
                SqlDataReader dr = cmdSelect.ExecuteReader();


                while (dr.Read()) {
                    emp = new Employees { EmpNo = (int)dr[0], Name = (string)dr[1], Basic = (decimal)dr[2], DeptNo = (int)dr[3] };
                }

                dr.Close();


                /*                emp.Name = (string)dr[1];
                                emp.Basic = (decimal)dr[2];
                                emp.DeptNo = (int)dr[3] ;*/
                /*
                                    Console.WriteLine(emp.Name + emp.Basic + emp.DeptNo);
                */
                return emp;
            }
            catch (Exception ex)
            { 

            Console.WriteLine("hiiiii2");
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);

            }
            finally
            {
                cn.Close();
            }
            Console.WriteLine("hiiiii3");
            return null;
        }

        public static void DeleteEmployee(int id)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JKJuly2022;Integrated Security=True";
            try
            {
                Console.WriteLine("hiiiii0");
                Employees emp = new Employees();
                emp.EmpNo = id;

                cn.Open();
                SqlCommand cmddelete = new SqlCommand();
                cmddelete.Connection = cn;
                cmddelete.CommandType = CommandType.StoredProcedure;
                cmddelete.CommandText = "DeleteEmployee10";
                cmddelete.Parameters.AddWithValue("@EmpNo", emp.EmpNo);

            cmddelete.ExecuteNonQuery();
               
               
            }
            catch (Exception ex)
            {

                Console.WriteLine("hiiiii2");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        public static void AddNewEmployee(Employees obj)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JKJuly2022;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = cn;
            cmdInsert.CommandType = CommandType.StoredProcedure;
            cmdInsert.CommandText = "InsertEmployee";

            cmdInsert.Parameters.AddWithValue("@EmpNo", obj.EmpNo);
            cmdInsert.Parameters.AddWithValue("@Name", obj.Name);
            cmdInsert.Parameters.AddWithValue("@Basic", obj.Basic);
            cmdInsert.Parameters.AddWithValue("@DeptNo", obj.DeptNo);

            cmdInsert.ExecuteNonQuery();
            
        }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        public static void UpdateEmployees(int EmpNo, string Name, decimal Basic, int DeptNo)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JKJuly2022;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = CommandType.StoredProcedure;
                cmdInsert.CommandText = "UpdateEmployee10";

                cmdInsert.Parameters.AddWithValue("@EmpNo", EmpNo);
                cmdInsert.Parameters.AddWithValue("@Name", Name);
                cmdInsert.Parameters.AddWithValue("@Basic", Basic);
                cmdInsert.Parameters.AddWithValue("@DeptNo", DeptNo);

                cmdInsert.ExecuteNonQuery();
              
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }
    }
}