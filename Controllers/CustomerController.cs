using InsuranceApi.Models;
using InsuranceApi.Repository;
using log4net.Config;
using log4net.Core;
using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Castle.Core.Resource;

namespace InsuranceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerResp<Customer> custrepo;
        private void LogError(string message)
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
            ILog _logger = LogManager.GetLogger(typeof(LoggerManager));
            _logger.Info(message);
        }
        public CustomerController(ICustomerResp<Customer> _cust)
        {
            custrepo = _cust;
        }
        [HttpGet]
        public ActionResult<List<Customer>> GetAllCustomer()
        {
            try
            {
                LogError("Get All Customer is called");
                List<Customer> Cust = custrepo.GetAllCustomers();
                return Ok(Cust);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult AddCustomer(Customer customer)
        {
            try
            {
                LogError($"Customer Added #:{customer.CustomerName}");
                custrepo.AddNewCustomer(customer);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPut]
        public async Task<ActionResult> EditCustomer(int id, Customer customer)
        {
            try
            {
                LogError($"Customer Edit #:{id},{customer.CustomerName}");
                custrepo.UpdateCustomer(id, customer);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteCustomer(int id)
        {
           
            try
            {
                LogError($"Customer Delete #:{id}");
                Customer customer = await custrepo.DeleteCustomer(id);
                if (customer == null)
                    return NotFound();
                else
                    //custrepo.DeleteCustomer(id);
                    return Ok();
            }
            catch (DbUpdateException)
            {
                return BadRequest("Unable to delete the record. It is referenced by another entity.");
            }


        }
        [HttpGet]
        [Route("GetCustomerById")]
        public async Task<ActionResult> GetCustByID(int id)
        {
            try
            {
                LogError(+id + " is retrieved");
                Customer c = await custrepo.GetCustomerById(id);
                if (c == null)
                    return NotFound();
                else
                    return Ok(c);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
     
    }
}
