using AltaTest.Data;
using AltaTest.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public IEnumerable<View01> Get()
        {
            IEnumerable<View01> view01s = new List<View01>();
            StringBuilder query = new StringBuilder();
            query.Append("select ROW_NUMBER() OVER (ORDER BY sum(b.point) DESC, max(b.DateTime), a.Name, b.PlayerId) AS STT, ");
            query.Append("    b.PlayerId, a.Name, a.Gender, sum(b.point) as point, max(b.DateTime) as DateTime ");
            query.Append("from Players a ");
            query.Append("    left join Points b on a.Id = b.PlayerId ");
            query.Append("group by b.PlayerId, a.Name, a.Gender ");
            query.Append("order by point DESC, DateTime, Name, PlayerId ");
            view01s = _context.Database.ExecuteSql(query.ToString());
            return view01s;
        }
    }
}
