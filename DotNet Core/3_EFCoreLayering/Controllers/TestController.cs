using EFCoreBooks;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreLayering.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase {
    private readonly MyDbContext _myDbContext;

    public TestController(MyDbContext myDbContext) {
        _myDbContext = myDbContext;
    }

    [HttpGet("/test")]
    public string Test() {
        return "hello";
    }
}