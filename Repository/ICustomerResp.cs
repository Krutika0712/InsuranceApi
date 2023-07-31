using InsuranceApi.Models;
using System.Net.Http.Headers;

namespace InsuranceApi.Repository
{
    public interface ICustomerResp<Customer>
    {
        //int add(int a, int b);
        //bool check(int a);
        List<Customer> GetAllCustomers();
        string AddNewCustomer(Customer customer);
        Task UpdateCustomer(int id, Customer customer);
        Task<Customer> DeleteCustomer(int id);
        Task<Customer> GetCustomerById(int id);
       
    }
}
