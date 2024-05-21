using MeetubPractica.DAL;
using MeetubPractica.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MeetubPractica.Controllers
{
    public class HomeController(MeetubContext _context) : Controller
    {
        public async Task< IActionResult >Index()
        {
            List<Speakers> speakers = await _context.Speakers.ToListAsync();
            return View(speakers);
        }

        
    }
}
