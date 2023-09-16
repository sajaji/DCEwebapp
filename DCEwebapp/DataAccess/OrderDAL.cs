using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DCEwebapp.Models;

namespace DCEwebapp.DataAccess
{
    public class OrderDAL
    {
        private readonly string _connectionString;

        public OrderDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Orders> GetAllOrders()
        {
            var orders = new List<Orders>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand("SELECT * FROM Orders", connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var order = new Orders
                        {
                            OrderId = reader.GetGuid(reader.GetOrdinal("OrderId")),
                            ProductId = reader.GetGuid(reader.GetOrdinal("ProductId")),
                            OrderStatus = reader.GetInt32(reader.GetOrdinal("OrderStatus")),
                            OrderType = reader.GetInt32(reader.GetOrdinal("OrderType")),
                            OrderBy = reader.GetGuid(reader.GetOrdinal("OrderBy")),
                            OrderedOn = reader.GetDateTime(reader.GetOrdinal("OrderedOn")),
                            ShippedOn = reader.GetDateTime(reader.GetOrdinal("ShippedOn")),
                            IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive"))
                        };

                        orders.Add(order);
                    }
                }
            }

            return orders;
        }
    }
}
