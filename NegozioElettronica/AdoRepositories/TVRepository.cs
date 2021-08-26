using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioElettronica
{
    public class TVRepository : ITvDbManager
    {
        const string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;" +
                                            "Initial Catalog = NegozioElettronica;" +
                                            "Integrated Security = true;";

        const string _discriminator = "TV";

        public void Delete(TV tv)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "delete from Product where Id = @id";
                command.Parameters.AddWithValue("@id", tv.Id);

                command.ExecuteNonQuery();
            }
        }

        public List<TV> Fetch()
        {
            List<TV> tvs = new List<TV>();
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
                    var inches = (int)reader["Inches"];
                    var id = (int)reader["Id"];

                    TV tv = new TV(brand, model, quantity, inches, id);
                    tvs.Add(tv);
                }
            }
            return tvs;
        }

        public TV GetById(int? id)
        {
            TV tv = new TV();
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
                    var inches = (int)reader["Inches"];

                     tv = new TV(brand, model, quantity, inches, id);
                }
            }
            return tv;
        }

        public void Insert(TV tv)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;

                //  insert into Vehicle values('Brand di prova', 'Model di prova', 1111, null, null, null, 'Motocycle')
                command.CommandText = "insert into Product values (@brand, @model, @quantity, @operativeSystem, @isTouch, @memory, @inches, @discriminator)";
                command.Parameters.AddWithValue("@brand", tv.Brand);
                command.Parameters.AddWithValue("@model", tv.Model);
                command.Parameters.AddWithValue("@quantity", tv.Quantity);
                command.Parameters.AddWithValue("@operativeSystem", DBNull.Value);
                command.Parameters.AddWithValue("@isTouch", DBNull.Value);
                command.Parameters.AddWithValue("@memory", DBNull.Value);
                command.Parameters.AddWithValue("@inches", tv.Inches );
                command.Parameters.AddWithValue("@discriminator", _discriminator);

                command.ExecuteNonQuery();
            }
        }

        public void Update(TV tv)
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
                command.Parameters.AddWithValue("@brand", tv.Brand);
                command.Parameters.AddWithValue("@model", tv.Model);
                command.Parameters.AddWithValue("@quantity", tv.Quantity);
                command.Parameters.AddWithValue("@operativeSystem", DBNull.Value);
                command.Parameters.AddWithValue("@isTouch", DBNull.Value);
                command.Parameters.AddWithValue("@memory", DBNull.Value);
                command.Parameters.AddWithValue("@inches", tv.Inches);
                command.Parameters.AddWithValue("@discriminator", _discriminator);


                command.ExecuteNonQuery();
            }
        }
    }
}