using BurialSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BurialSite.Infrstructure
{
    public class DynamicFieldManager
    {
        private ArcDBContext _context { get; set; }
        public DynamicFieldManager(ArcDBContext arcDbContext)
        {
            _context = arcDbContext;
        }

       /// <summary>
       /// This makes a dynamic field
       /// </summary>
       /// <param name="field">The field they want to add</param>
       /// <returns>True if it was successful, false if not successful.</returns>
        public bool CreateField(OneToOneField field)
        {
            try
            {
                _context.OneToOneFields.Add(field);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public IQueryable<OneToOneField> DynamicFields => (_context.OneToOneFields);

        public bool SaveValueForBurial(int onetoonefieldid, int burialid, string value)
        {
            OneToOneValue possiblevalue = await _context.OneToOneValues.Where(v => v.BurialId == burialid && v.OneToOneFieldId == onetoonefieldid).FirstOrDefault();

            if (possiblevalue != null)
            {
                _context.Update(possiblevalue);
                _context.SaveChanges();
            }
            Console.Out.WriteLine("yo, here!");

            OneToOneValue newOneToOneValue = new OneToOneValue()
            {
                OneToOneFieldId = onetoonefieldid,
                BurialId = burialid,
                Value = value
            };
            //if (ModelState.IsValid)
            _context.Add(newOneToOneValue);

            return false;
        }

    }
}
