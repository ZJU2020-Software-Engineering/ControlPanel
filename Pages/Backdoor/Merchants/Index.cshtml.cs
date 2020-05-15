#region snippet_All
using ControlPanel.Data;
using ControlPanel.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlPanel.Pages.Merchants
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

        public PaginatedList<Merchant> Merchants { get; set; }

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

            IQueryable<Merchant> merchantsIQ = from s in _context.MerchantUserInfo
                                            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                merchantsIQ = merchantsIQ.Where(s => s.Name.Contains(searchString)
                                       || s.Username.Contains(searchString)
                                       || s.PhoneNumber.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    merchantsIQ = merchantsIQ.OrderByDescending(s => s.Name);
                    break;
                default:
                    merchantsIQ = merchantsIQ.OrderBy(s => s.Name);
                    break;
            }

            int pageSize = 9;
            Merchants = await PaginatedList<Merchant>.CreateAsync(
                merchantsIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
#endregion