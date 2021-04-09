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
    public class DetailsModel : PageModel
    {
        private readonly BurialSite.Models.ArcDBContext _context;

        public DetailsModel(BurialSite.Models.ArcDBContext context)
        {
            _context = context;
        }

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
    }
}
