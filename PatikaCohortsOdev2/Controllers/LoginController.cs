using Microsoft.AspNetCore.Mvc;
using PatikaCohortsOdev2.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PatikaCohortsOdev2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    [HttpPost]
    public IActionResult Post([FromBody] User user)
    {
        return Ok(" Giriş Başarılı ");
    }
}
