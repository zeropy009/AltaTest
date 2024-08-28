using AltaTest.Data;
using AltaTest.ViewModels;
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
        public IActionResult Get(DateOnly? date, int page = 1, int pageSize = 10)
        {
            if (date == null)
            {
                return BadRequest("Please enter date !!!");
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("select ROW_NUMBER() OVER (ORDER BY sum(b.point) DESC, max(b.DateTime), a.Name, b.PlayerId) AS STT, ");
            sb.Append("    b.PlayerId, a.Name, a.Gender, sum(b.point) as Point, max(b.DateTime) as DateTime ");
            sb.Append("from Players a ");
            sb.Append("    left join Points b on a.Id = b.PlayerId ");
            sb.Append("where MONTH(b.DateTime) = {0} and YEAR(b.DateTime) = {1} ");
            sb.Append("group by b.PlayerId, a.Name, a.Gender ");
            FormattableString query = FormattableStringFactory.Create(sb.ToString(), [date?.Month, date?.Year]);
            return Ok(_context.Database.SqlQuery<View01>(query).Skip(pageSize*(page - 1)).Take(pageSize));
        }
    }
}
