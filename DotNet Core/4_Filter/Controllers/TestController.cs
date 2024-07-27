using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace _4_Filter.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class TestController : ControllerBase {
    [HttpGet]
    public string Test1() {
        return  System.IO.File.ReadAllText("D://text.txt");
    }

    [HttpGet]
    public string Test2() {
        Console.WriteLine("Test2 执行");
        return "success";
    }

    /// <summary>
    /// test3
    /// </summary>
    [HttpGet]
    public string Test3(string p1, string p2) {
        Console.WriteLine(p1);
        Console.WriteLine(p2);
        return "test3";
    }
}