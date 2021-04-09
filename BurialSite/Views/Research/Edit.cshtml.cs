using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BurialSite.Models;

namespace BurialSite.Views.Research
{
    public class EditModel : PageModel
    {
        private readonly BurialSite.Models.ArcDBContext _context;

        public EditModel(BurialSite.Models.ArcDBContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Burial).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BurialExists(Burial.BurialID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BurialExists(int id)
        {
            return _context.Burials.Any(e => e.BurialID == id);
        }
    }
}
