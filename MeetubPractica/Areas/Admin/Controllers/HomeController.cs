using MeetubPractica.DAL;
using MeetubPractica.Models;
using MeetubPractica.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MeetubPractica.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController(MeetubContext _context) : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<Speakers> speakers = await _context.Speakers.ToListAsync();
            return View(speakers);
        }
        public async Task<IActionResult> Create()
        { 

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateMeetubVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            await _context.Speakers.AddAsync(new Speakers
            {
                Name = vm.Name,
                Subtitle = vm.Subtitle,
                ImageUrl = vm.ImageUrl,
                Icons = vm.Icons,

            });
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null || id < 1) return BadRequest();
            Speakers aa=await _context.Speakers.FirstOrDefaultAsync(x => x.Id == id);
            if (aa == null) return NotFound();
            return View(aa);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int? id ,CreateMeetubVM vM)
        {
            if (id == null || id < 1) return BadRequest();
            Speakers existed = await _context.Speakers.FirstOrDefaultAsync(x => x.Id == id);
            if (existed == null) return NotFound();
            existed.Name = vM.Name;
            existed.Subtitle = vM.Subtitle;
            existed.ImageUrl = vM.ImageUrl;
            existed.Icons = vM.Icons;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id < 1) return BadRequest();
            Speakers bb = await _context.Speakers.FindAsync(id);
            if (bb == null) return NotFound();
            _context.Remove(bb);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            
        }

    }
}
