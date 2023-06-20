using AnyCompany;


// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

CustomerService customerService = new CustomerService();
Customer customer = new Customer()
{
    Country = "SA",
    DateOfBirth = new DateTime(2000, 6, 20),
    Name = "Phakamani"
};
 customerService.SaveCustomer(customer);
