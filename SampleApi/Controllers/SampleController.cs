using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class SampleController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var samples = new List<SampleItem>
        {
            new SampleItem { Id = 1, Name = "Item A", Description = "Description A" },
            new SampleItem { Id = 2, Name = "Item B", Description = "Description B" },
            new SampleItem { Id = 3, Name = "Item C", Description = "Description C" },
        };

        return Ok(samples);
    }
}