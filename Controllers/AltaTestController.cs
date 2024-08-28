using AltaTest.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using System.Text;

namespace AltaTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AltaTestController : ControllerBase
    {
        private readonly BlogDbContext _context;

        private readonly ILogger<AltaTestController> _logger;

        public AltaTestController(ILogger<AltaTestController> logger, BlogDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name = "AltaTest")]
        public IActionResult Get()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select ROW_NUMBER() OVER (ORDER BY sum(b.point) DESC, max(b.DateTime), a.Name, b.PlayerId) AS STT, ");
            sb.Append("    b.PlayerId, a.Name, a.Gender, sum(b.point) as point, max(b.DateTime) as DateTime ");
            sb.Append("from Players a ");
            sb.Append("    left join Points b on a.Id = b.PlayerId ");
            sb.Append("group by b.PlayerId, a.Name, a.Gender ");
            sb.Append("order by point DESC, DateTime, Name, PlayerId ");
            FormattableString query = FormattableStringFactory.Create(sb.ToString());
            return Ok(_context.Database.ExecuteSql(query));
        }
    }
}
