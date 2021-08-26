using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioElettronica
{
    public class PCRepository : IPcDbManager
    {
        const string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;" +
                                            "Initial Catalog = NegozioElettronica;" +
                                            "Integrated Security = true;";

        const string _discriminator = "PC";

        public void Delete(PC pc)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "delete from Product where Id = @id";
                command.Parameters.AddWithValue("@id", pc.Id);

                command.ExecuteNonQuery();
            }
        }

        public List<PC> Fetch()
        {
            List<PC> pcs = new List<PC>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Product where Discriminator = @discriminator";
                command.Parameters.AddWithValue("@discriminator", _discriminator);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var brand = (string)reader["Brand"];
                    var model = (string)reader["Model"];
                    var quantity = (int)reader["Quantity"];
                    var operativeSystem = (OperativeSystem)reader["OperativeSystem"];
                    var isTouch = (bool)reader["IsTouch"];
                    var id = (int)reader["Id"];

                    PC pc = new PC(brand, model, quantity, operativeSystem, isTouch, id);
                    pcs.Add(pc);
                }
            }
            return pcs;
        }

        public PC GetById(int? id)
        {
            PC pc = new PC();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Product where Id = @id";
                command.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var brand = (string)reader["Brand"];
                    var model = (string)reader["Model"];
                    var quantity = (int)reader["Quantity"];
                    var operativeSystem = (OperativeSystem)reader["OperativeSystem"];
                    var isTouch = (bool)reader["IsTouch"];


                   pc = new PC(brand, model, quantity, operativeSystem, isTouch, id);
                }
            }
            return pc;
        }

        public void Insert(PC pc)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;

               
                command.CommandText = "insert into Product values (@brand, @model, @quantity, @operativeSystem, @isTouch, @memory, @inches, @discriminator)";
                command.Parameters.AddWithValue("@brand", pc.Brand);
                command.Parameters.AddWithValue("@model", pc.Model);
                command.Parameters.AddWithValue("@quantity", pc.Quantity);
                command.Parameters.AddWithValue("@operativeSystem", pc.OS);
                command.Parameters.AddWithValue("@isTouch", pc.IsTouch);
                command.Parameters.AddWithValue("@memory", DBNull.Value);
                command.Parameters.AddWithValue("@inches", DBNull.Value);
                command.Parameters.AddWithValue("@discriminator", _discriminator);

                command.ExecuteNonQuery();
            }
        }

        public void Update(PC pc)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "update Product " +
                                      "set Brand = @brand, Model = @model, Quantity = @quantity, " +
                                      "OperativeSystem = @operativeSystem, IsTouch = @isTouch, Memory = @memory, Inches = @inches, Discriminator = @discriminator" +
                                      "where Id = @id";
                command.Parameters.AddWithValue("@brand", pc.Brand);
                command.Parameters.AddWithValue("@model", pc.Model);
                command.Parameters.AddWithValue("@quantity", pc.Quantity);
                command.Parameters.AddWithValue("@operativeSystem", pc.OS);
                command.Parameters.AddWithValue("@isTouch", pc.IsTouch);
                command.Parameters.AddWithValue("@memory", DBNull.Value);
                command.Parameters.AddWithValue("@inches", DBNull.Value);
                command.Parameters.AddWithValue("@discriminator", _discriminator);

                command.ExecuteNonQuery();
            }
        }
    }
}