using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PatikaCohortsOdev2.Model;


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
