namespace AnyCompany
{
    public class CustomerService
    {
        //private readonly CustomerRepository CustomerRepository = new CustomerRepository();
        public bool SaveCustomer(Customer customer)
        {
            //The name valid excpects the object customer to be valid, otherwise we return null
            if (string.IsNullOrWhiteSpace( customer.Name))
            {
                return false;
            }
            else if (customer.DateOfBirth == null)
            {
                return false;
            }
            else if (string.IsNullOrWhiteSpace(customer.Country))
            {
                return false;
            }
            else
            {
                CustomerRepository.SaveCustomer(customer);
                return true;
            }
        }
    }
}