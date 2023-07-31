using InsuranceApi.Models;
using log4net.Config;
using log4net.Core;
using log4net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.Data.SqlClient;

namespace InsuranceApi.Repository
{
    public class CustomerResp : ICustomerResp<Customer>
    {
        private readonly InsManagementContext db;

        public CustomerResp()
        {
            
        }
        public CustomerResp(InsManagementContext _db)
        {
            db = _db;
        }

        //public async Task AddNewCustomer(Customer customer)
        //{
        //    db.Customers.Add(customer);
        //    await db.SaveChangesAsync();
        //}

        public async Task<Customer> DeleteCustomer(int id)
        {
           
            Customer customer = db.Customers.Where(x => x.CustomerId == id).SingleOrDefault();
                if (customer != null)
                {
                    db.Customers.Remove(customer);
                    await db.SaveChangesAsync();
                }

                return customer;

        }

        public  List<Customer> GetAllCustomers()
        {
           
            return   db.Customers.ToList();
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            Customer customer = await db.Customers.FirstOrDefaultAsync(a => a.CustomerId == id);
            return customer;

        }

        public async Task UpdateCustomer(int id, Customer customer)
        {
            db.Customers.Update(customer);
            await db.SaveChangesAsync();
        }
        
        //public int add(int a,int b)
        //{
        //    bool result = check(a);
        //    if (result == true)
        //    {
        //        return a + b;
        //    }
        //    return 0;
           
        //}

        //public bool check(int a)
        //{
        //    if (a > 5)
        //    {
        //        return true;
        //    }
        //    else { return false; }
            

        //}

        public string AddNewCustomer(Customer customer)
        {
            string message;
            if (customer != null) 
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                message = "Record Added";
                return message;
            }
            else
            {
                message = "Error";
                return message;
            }
        }

       
    }
}
