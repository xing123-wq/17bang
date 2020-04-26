using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _17bnag.Data;
using _17bnag.Entitys;
using _17bnag.Layout;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace _17bnag
{
    public class indexsModel : _LayoutModel
    {
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string MovieGenre { get; set; }
        public IList<HelpRelease> Release { get; set; }

        public indexsModel(_17bnagContext context) : base(context)
        {
            _context = context;
        }
        public async Task OnGet()
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.HelpRelease
                                            orderby m.Keywords
                                            select m.Keywords;



            var movies = from m in _context.HelpRelease
                         select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.Title.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(MovieGenre))
            {
                movies = movies.Where(x => x.Keywords == MovieGenre);
            }
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Release = await movies.ToListAsync();
        }

    }
}