using System;
using System.Collections.Generic;

namespace InsuranceApi.Models
{
    public partial class Customer
    {
        public Customer()
        {
            TransactionDetails = new HashSet<TransactionDetail>();
        }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = null!;
        public string? CustomerAddress { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Phone { get; set; }
        public int Age { get; set; }
        public string? Gender { get; set; }
        public string? Country { get; set; }

        public virtual ICollection<TransactionDetail> TransactionDetails { get; set; }

        public Customer(int id , string name,string address,DateTime Dob,string phno,int age,string gender,string country)
        {
                CustomerId = id;
                CustomerName = name;
                CustomerAddress = address;
                BirthDate = Dob;
                Phone = phno;
                Age = age;
                Gender = gender;
                Country = country;
        }

    }
}
