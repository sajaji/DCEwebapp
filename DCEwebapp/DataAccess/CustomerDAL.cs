using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DCEwebapp.Models;

namespace DCEwebapp.DataAccess
{
    public class CustomerDAL
    {
        private readonly string _connectionString;

        public CustomerDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            var customers = new List<Customer>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand("SELECT * FROM Customer", connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var customer = new Customer
                        {
                            UserId = reader.GetGuid(reader.GetOrdinal("UserId")),
                            Username = reader.GetString(reader.GetOrdinal("Username")),
                            Email = reader.GetString(reader.GetOrdinal("Email")),
                            FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                            LastName = reader.GetString(reader.GetOrdinal("LastName")),
                            CreatedOn = reader.GetDateTime(reader.GetOrdinal("CreatedOn")),
                            IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive"))
                        };

                        customers.Add(customer);
                    }
                }
            }

            return customers;
        }
    }
}
