using System;
namespace BurialSite.Models
{
    public class EFArcRepository : IArcRepository
    {
        /// <summary>
        /// The repository for our main db information. This is not used as much currently.
        /// </summary>
        private ArcDBContext _context;

        public EFArcRepository(ArcDBContext context)
        {
            _context = context;
        }

    }
}
