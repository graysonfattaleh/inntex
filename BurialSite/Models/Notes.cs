using System;
namespace BurialSite.Models
{
    /// <summary>
    /// Represents the notes (which a burial can be associated with many notes) for a burial
    /// </summary>
    public class Notes
    {
        public int NotesId { get; set; }
        public string Type { get; set; }
        public string Data { get; set; }
        public long BurialID { get; set; }
        public virtual Burial Burial { get; set; }
    }
}
