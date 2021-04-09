using System;
namespace BurialSite.Models
{
    public class Notes
    {
        public int NotesId { get; set; }
        public string Type { get; set; }
        public string Data { get; set; }
        public long BurialID { get; set; }
        public virtual Burial Burial { get; set; }
    }
}
