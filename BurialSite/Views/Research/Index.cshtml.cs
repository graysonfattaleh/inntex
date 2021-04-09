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
    public class IndexModel : PageModel
    {
        private readonly BurialSite.Models.ArcDBContext _context;

        public IndexModel(BurialSite.Models.ArcDBContext context)
        {
            _context = context;
        }

        public IList<Burial> Burial { get;set; }

        public async Task OnGetAsync()
        {
            Burial = await _context.Burials.ToListAsync();
        }
    }
}
