using Microsoft.AspNetCore.Mvc;
using PatikaCohortsOdev2.Configurations.Extensions;
using PatikaCohortsOdev2.Configurations.Response;
using PatikaCohortsOdev2.Model;
using System.Diagnostics;

namespace PatikaOdev2.Controllers;

[Route("api/[controller]s")] // Best Practice
[ApiController]

public class CustomerController : ControllerBase
{
    public CommandResponse Response { get; set; }
    public CustomerController(CommandResponse commandResponse)
    {
        this.Response = commandResponse;
    }

    private static List<Customer> customers = new()
    {
            new Customer()
            {
                Id = 1,
                Name = "Ahmet",
                Surname = "Yýlmaz",
                Email = "ahmet.yilmaz@example.com",
                PhoneNumber = "+905551234567",
                DateOfBirth = new DateTime(1990, 5, 15)
            },
            new Customer()
            {
                Id = 2,
                Name = "Elif",
                Surname = "Demir",
                Email = "elif.demir@example.com",
                PhoneNumber = "+905554567890",
                DateOfBirth = new DateTime(1995, 8, 22)
            },
            new Customer()
            {
              Id = 3,
              Name = "Mert",
              Surname = "Kaya",
              Email = "mert.kaya@example.com",
              PhoneNumber = "+905558765432",
              DateOfBirth = new DateTime(1987, 11, 3)
            },

            new Customer(){
                Id = 4,
                Name = "Ahmet",
                Surname = "Þahin",
                Email = "ahmet.sahin@example.com",
                PhoneNumber = "+905356789900",
                DateOfBirth = new DateTime(1995, 3, 12)
            },
    };

    // Tüm Müþterileri Listeler.
    [HttpGet]
    public IActionResult Get()
    {
        try
        {
            
            var response = customers.IsNull();

            if (response.Status == false)
                return BadRequest(Response);

            Response.Status = true;
            Response.Value = customers;
            // Dönen yanýtý loglama yapýlacak.
            return Ok(Response);
        }
        catch (Exception ex)
        {
            // Burada Loglama Yapýlacak.
            Debug.WriteLine($" HATA FIRLATILDI Post: {ex.Message}");
            Response.Status = false;
            Response.Message = ex.Message;
            return StatusCode(500, Response);
        }
    }

    // Ýsme göre Z den A ya Müþterileri listeler.
    [HttpGet("NameList")]
    public IActionResult GetAllCustomerName([FromQuery] string name)
    {
        try
        {
            var result = customers.Where(x => x.Name.Contains(name)).OrderByDescending(x => x.Name).ToList();

            if (result.Count <= 0)
            {
                Response.Status = false;
                Response.Message = " The requested feature was not found ";
                return BadRequest(Response);
            }

            Response.Status = true;
            Response.Value = result;
            return Ok(result);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($" HATA FIRLATILDI Post: {ex.Message}");
            Response.Status = false;
            Response.Message = ex.Message;
            return StatusCode(500, Response);
        }

    }

    // Id ye göre müþterinin bilgilerini getirir. 
    [HttpGet("{id}")]
    public ActionResult<Customer> Get(int id)
    {
        try
        {
            if (id <= 0)
            {
                Response.Status = false;
                Response.Message = "Id must be greater than 0";
                return BadRequest(Response);
            }

            var customer = customers.SingleOrDefault(x => x.Id == id);

            var response = customers.IsNull();

            if (response.Status == false)
                return NotFound(response);


            Response.Status = true;
            Response.Value = customer;
            return Ok(Response);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($" HATA FIRLATILDI Post: {ex.Message}");
            Response.Status = false;
            Response.Message = ex.Message;
            return StatusCode(500, Response);
        }

    }

    // Yeni bir müþteri kaydeder.
    [HttpPost]
    public IActionResult Post([FromBody] Customer customer)
    {
        try
        {
            var response = customer.IsNull();

            if (response.Status == false)
                return BadRequest(Response);

            // Ayný Id ile 1 de fazla kayýt olamaz
            if (customer.Id >= 1 && customer.Id <= 4)
            {
                Response.Status = false;
                Response.Message = "Customer already exist";
                return NotFound(Response);
            }

            customers.Add(customer);
            Response.Status = true;
            Response.Value = customer;
            return StatusCode(201, Response);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($" HATA FIRLATILDI Post: {ex.Message}");
            Response.Status = false;
            Response.Message = ex.Message;
            return StatusCode(500, Response);
        }
    }

    // Müþteriyi günceller.
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Customer customer)
    {
        Customer cust = new();
        try
        {
            var response = customer.IsNull();

            if (response.Status == false)
                return BadRequest(Response);


            var result = customers.SingleOrDefault(x => x.Id == id);

            if (result == null)
            {
                Response.Status = false;
                Response.Message = "Customer is not found";
                return NotFound();
            }

            result = customers[1];
            result.Name = customer.Name != null ? customer.Name : result.Name;
            result.Surname = customer.Surname != null ? customer.Surname : result.Surname;
            result.Email = customer.Email != null ? customer.Email : result.Email;
            result.PhoneNumber = customer.PhoneNumber != null ? customer.PhoneNumber : result.PhoneNumber;
            result.DateOfBirth = customer.DateOfBirth == DateTime.MinValue ? customer.DateOfBirth : result.DateOfBirth;

            Response.Status = true;
            Response.Message = "Update is success";
            return StatusCode(204, Response);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($" HATA FIRLATILDI Post: {ex.Message}");
            Response.Status = false;
            Response.Message = ex.Message;
            return StatusCode(500, Response);
        }
    }

    // Müþteriyi siler.
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            if (id <= 0)
            {
                Response.Status = false;
                Response.Message = "Id must be greater than 0";
                return BadRequest(Response);
            }

            var result = customers.SingleOrDefault(x => x.Id == id);

            if (result == null)
            {
                Response.Status = false;
                Response.Message = "Customer is not found";
                return NotFound(Response);
            }

            customers.Remove(result);
            Response.Status = true;
            Response.Message = "Deleted is success";
            return Ok(Response);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($" HATA FIRLATILDI Post: {ex.Message}");
            Response.Status = false;
            Response.Message = ex.Message;
            return StatusCode(500, Response);
        }

    }
}
