using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BurialSite.Models.ViewModels
{
    public class BurialDetailsViewModels
    {
        private readonly ArcDBContext _context;
        public BurialDetailsViewModels(ArcDBContext context, int BurialId)
        {
            _context = context;
            burial = _context.Burials.Include(b => b.BurialLocation).Where(b => b.BurialID == BurialId).FirstOrDefault(); ;
            BurialPhotos = _context.FileUrls.Where(b => b.Burial.BurialID == BurialId).ToList();
            Notes = _context.Notes.Where(n => n.BurialID == BurialId).ToList();

        }

        public Burial burial { get; set; }
        public List<FileUrl> BurialPhotos {get;set;}
        public List<Notes> Notes { get; set; }
    }
}
