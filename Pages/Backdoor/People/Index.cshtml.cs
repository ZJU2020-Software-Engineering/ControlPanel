#region snippet_All
using ControlPanel.Data;
using ControlPanel.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlPanel.Pages.People
{
    public class IndexModel : PageModel
    {
        private readonly BackdoorContext _context;

        public IndexModel(BackdoorContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<Person> People { get; set; }

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Person> peopleIQ = from s in _context.PersonalUserInfo
                                            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                peopleIQ = peopleIQ.Where(s => s.Name.Contains(searchString)
                                       || s.IdentityCardNumber.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    peopleIQ = peopleIQ.OrderByDescending(s => s.Name);
                    break;
                case "Date":
                    peopleIQ = peopleIQ.OrderBy(s => s.UpdateTime);
                    break;
                case "date_desc":
                    peopleIQ = peopleIQ.OrderByDescending(s => s.UpdateTime);
                    break;
                default:
                    peopleIQ = peopleIQ.OrderBy(s => s.Name);
                    break;
            }

            int pageSize = 3;
            People = await PaginatedList<Person>.CreateAsync(
                peopleIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
#endregion