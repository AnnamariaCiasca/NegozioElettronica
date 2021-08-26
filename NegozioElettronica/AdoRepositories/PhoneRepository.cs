using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioElettronica
{
    public class PhoneRepository : IPhoneDbManager
    {
        const string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;" +
                                           "Initial Catalog = NegozioElettronica;" +
                                           "Integrated Security = true;";

        const string _discriminator = "Phone";

        public void Delete(Phone phone)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "delete from Product where Id = @id";
                command.Parameters.AddWithValue("@id", phone.Id);

                command.ExecuteNonQuery();
            }
        }

        public List<Phone> Fetch()
        {
            List<Phone> phones = new List<Phone>();
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
                    var memory = (int)reader["Memory"];
                    var id = (int)reader["Id"];

                    Phone phone = new Phone(brand, model, quantity, memory, id);
                    phones.Add(phone);
                }
            }
            return phones;
        }

        public Phone GetById(int? id)
        {
            Phone phone = new Phone();
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
                    var memory = (int)reader["Memory"];
                 

                    phone = new Phone(brand, model, quantity, memory, id);
                }
            }
            return phone;
        }

        public void Insert(Phone phone)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;

          
                command.CommandText = "insert into Product values (@brand, @model, @quantity, @operativeSystem, @isTouch, @memory, @inches, @discriminator)";
                command.Parameters.AddWithValue("@brand", phone.Brand);
                command.Parameters.AddWithValue("@model", phone.Model);
                command.Parameters.AddWithValue("@quantity", phone.Quantity);
                command.Parameters.AddWithValue("@operativeSystem", DBNull.Value);
                command.Parameters.AddWithValue("@isTouch", DBNull.Value);
                command.Parameters.AddWithValue("@memory", phone.Memory);
                command.Parameters.AddWithValue("@inches", DBNull.Value);
                command.Parameters.AddWithValue("@discriminator", _discriminator);

                command.ExecuteNonQuery();
            }
        }

        public void Update(Phone phone)
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
                command.Parameters.AddWithValue("@brand", phone.Brand);
                command.Parameters.AddWithValue("@model", phone.Model);
                command.Parameters.AddWithValue("@quantity", phone.Quantity);
                command.Parameters.AddWithValue("@operativeSystem", DBNull.Value);
                command.Parameters.AddWithValue("@isTouch", DBNull.Value);
                command.Parameters.AddWithValue("@memory", phone.Memory);
                command.Parameters.AddWithValue("@inches", DBNull.Value);
                command.Parameters.AddWithValue("@discriminator", "Phone");

                command.ExecuteNonQuery();
            }
        }

        public List<Phone> Filtra(int memory)
        {
            List<Phone> phones = new List<Phone>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select p.Brand, p.Model, p.Quantity, p.Id from dbo.Product p where Memory>@memory AND Discriminator = 'Phone'";
                command.Parameters.AddWithValue("@memory", memory);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var brand = (string)reader["Brand"];
                    var model = (string)reader["Model"];
                    var quantity = (int)reader["Quantity"];
              
                    var id = (int)reader["Id"];

                    Phone phone = new Phone(brand, model, quantity, memory, id);
                    phones.Add(phone);
                }
            }
            return phones;
        }
    }
}