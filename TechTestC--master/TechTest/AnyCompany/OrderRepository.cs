using System.Collections.Generic;
using System.Data.SqlClient;

namespace AnyCompany
{
    internal class OrderRepository
    {
        private static readonly string ConnectionString = @"Data Source=(local);Database=Customer;Integrate Security=True";

        // public void Save(Order order)
        // {
        //     SqlConnection connection = new SqlConnection(ConnectionString);
            

        //     SqlCommand command = new SqlCommand("INSERT INTO Orders VALUES (@OrderId, @Amount, @VAT)", connection);
        //     command.CommandType = CommandType.StoredProcedure;
        //     command.Parameters.AddWithValue("@OrderId", order.OrderId);
        //     command.Parameters.AddWithValue("@Amount", order.Amount);
        //     command.Parameters.AddWithValue("@VAT", order.VAT);
        //     connection.Open();
        //     int i = command.ExecuteNonQuery();
        //     connection.Close();

        //     command.ExecuteNonQuery();

        //     connection.Close();
        // }
        
        
        
        
        public void SaveOrder(Order order)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            SqlCommand command = new SqlCommand("INSERT INTO Order VALUES (@CustomerId, @Amount, @VAT)", connection);

            command.Parameters.AddWithValue("@CustomerId", order.CustomerId);
            command.Parameters.AddWithValue("@Amount", order.Amount);
            command.Parameters.AddWithValue("@VAT", order.VAT);

            command.ExecuteNonQuery();

            connection.Close();
        }

       //We used List<Order> because we can multiple orders belonging to one customer
        public static List<Order> LoadOrders(int customerId){
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            
            List<Order> orders = new List<Order>();
            SqlCommand command = new SqlCommand("SELECT * FROM Order WHERE CustomerId = " + customerId,connection);
            var reader = command.ExecuteReader();

            while (reader.Read()) 
            {
                Order order = new Order
                {
                    CustomerId = (int)reader["CustomerId"],
                    Amount = (double)reader["Amount"],
                    OrderId = (int)reader["OrderId"],
                    VAT = (double)reader["VAT"]
                };
                orders.Add(order);
            }

            
            connection.Close();

            return orders;

        }
    }
}
