using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BurialSite.Models.ViewModels
{
    public class EditBurialViewModel
    {
        protected ArcDBContext _context { get; set; }
        public EditBurialViewModel(ArcDBContext context)
        {
            // get options for lists that are vairables 
            List<SelectListItem> CranialOptions = new List<SelectListItem>();
            CranialOptions.Add(new SelectListItem { Text = "Closed", Value = "Closed" });
            CranialOptions.Add(new SelectListItem { Text = "Open", Value = "Open" });
            CranialOptions.Add(new SelectListItem { Text = "Partially Open", Value = "Partially Open" });
            List<SelectListItem> BasilOptions = new List<SelectListItem>();
            BasilOptions.Add(new SelectListItem { Text = "Closed", Value = "Closed" });
            BasilOptions.Add(new SelectListItem { Text = "Open", Value = "Open" });

            BasilList = BasilOptions;
            CranialStructureList = CranialOptions;
            _context = context;
            configureLocations();
            CustomFields = getOnetoOneDict();
        }
        public IEnumerable<SelectListItem> BasilList { get; set; }
        public IEnumerable<SelectListItem> CranialStructureList { get; set; }
        public Burial Burial { get; set; }
        public int LocationId { get; set; }
        public Dictionary<string, int> LocationStrings { get; set; }
        public Dictionary<int, string> AreaStrings { get; set; } = Area.Areas;
        List<BurialLocation> Locations { get; set; }

        public Dictionary<OneToOneField, OneToOneValue> CustomFields { get; set; }

        private Dictionary<OneToOneField, OneToOneValue> getOnetoOneDict()
        {
            Dictionary<OneToOneField, OneToOneValue> returndict = new Dictionary<OneToOneField, OneToOneValue>();
            foreach (OneToOneField field in _context.OneToOneFields.ToList())
            {
                OneToOneValue? that;
                try
                {
                    that = _context.OneToOneValues.Where(val => val.BurialId == Burial.BurialID && val.OneToOneFieldId == field.OneToOneFieldId).FirstOrDefault();
                }
                catch (Exception)
                {
                    that = null;
                }
                returndict.Add(field, that);
            }
            return returndict;
        }
        private void configureLocations()
        {
            Locations = _context.BurialLocations.ToList();
            Dictionary<string, int> locationvalues = new Dictionary<string, int>();

            //locationvalues["All"] = -1;//TODO FIX THIS??
            foreach (BurialLocation bl in Locations) { 
            
                if (bl.Area == null || bl.Area == "")  
                {
                    bl.Area = "1";
                }
            
                string area = Area.Areas[Int32.Parse(bl.Area)];
                string namestring = $"{bl.Dig_Site_Name} NS: {bl.N_S_Grid_Site_Lower}/ {bl.N_S_Grid_Site_Upper} EW: {bl.E_W_Grid_Site_Lower}/ {bl.E_W_Grid_Site_Upper} / Area: {area}"; 
                locationvalues[namestring] = bl.BurialLocationId;
            }
            LocationStrings = locationvalues;
            
            return;
        }
    }

    
}
