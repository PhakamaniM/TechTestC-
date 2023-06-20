using System;
using System.Data.SqlClient;

namespace AnyCompany
{
    public static class CustomerRepository
    {
        private static readonly string ConnectionString = @"Data Source=(local);Database=Customer;Integrate Security=True;";

        public static Customer Load(int customerId)
        {
            Customer customer = new Customer();

            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT * FROM Customer WHERE CustomerId = " + customerId,
                connection);
            var reader = command.ExecuteReader();

            while (reader.Read()) 
            {
                customer.CustomerId = (int)reader["CustomerId"];
                customer.Name = reader["Name"].ToString();
                customer.DateOfBirth = DateTime.Parse(reader["DateOfBirth"].ToString());
                customer.Country = reader["Country"].ToString();
            }

            connection.Close();

            return customer;
        }

        public static void SaveCustomer(Customer Customer)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            SqlCommand command = new SqlCommand("INSERT INTO Customers VALUES (@Country, @DateOfBirth, @Name)", connection);

            command.Parameters.AddWithValue("@Country", Customer.Country);
            command.Parameters.AddWithValue("@DateOfBirth", Customer.DateOfBirth);
            command.Parameters.AddWithValue("@Name", Customer.Name);

            command.ExecuteNonQuery();

            connection.Close();
        }
    }
}
