using System;
using System.Linq;

namespace BurialSite.Models.ViewModels
{
    public class EditNoteViewModel
    {
        public EditNoteViewModel(ArcDBContext _context, int NoteId, int burialId)
        {
            Note = _context.Notes.Where(n => n.NotesId == NoteId).FirstOrDefault();
            BurialId = burialId;

        }

        public Notes Note { get; set; }
        public int BurialId {get;set;}
    }
}
