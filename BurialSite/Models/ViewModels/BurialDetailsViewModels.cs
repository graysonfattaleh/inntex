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
            CustomFields = getOnetoOneDict();
        }

        public Burial burial { get; set; }
        public List<FileUrl> BurialPhotos {get;set;}
        public List<Notes> Notes { get; set; }
        public Dictionary<OneToOneField, OneToOneValue> CustomFields { get; set; }

        private Dictionary<OneToOneField, OneToOneValue> getOnetoOneDict()
        {
            Dictionary<OneToOneField, OneToOneValue> returndict = new Dictionary<OneToOneField, OneToOneValue>();
            foreach (OneToOneField field in _context.OneToOneFields.ToList())
            {
                returndict.Add( field, _context.OneToOneValues.Where(val => val.BurialId == burial.BurialID && val.OneToOneFieldId == field.OneToOneFieldId).FirstOrDefault()) ;
            }
            return returndict;
        }
    }
}
