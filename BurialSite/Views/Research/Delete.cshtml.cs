using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BurialSite.Models;

namespace BurialSite.Views.Research
{
    public class DeleteModel : PageModel
    {
        private readonly BurialSite.Models.ArcDBContext _context;

        public DeleteModel(BurialSite.Models.ArcDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Burial Burial { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Burial = await _context.Burials.FirstOrDefaultAsync(m => m.BurialID == id);

            if (Burial == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Burial = await _context.Burials.FindAsync(id);

            if (Burial != null)
            {
                _context.Burials.Remove(Burial);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
