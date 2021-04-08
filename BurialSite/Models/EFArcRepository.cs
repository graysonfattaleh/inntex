using System;
namespace BurialSite.Models
{
    public class EFArcRepository : IArcRepository
    {
        private ArcDBContext _context;

        public EFArcRepository(ArcDBContext context)
        {
            _context = context;
        }

    }
}
