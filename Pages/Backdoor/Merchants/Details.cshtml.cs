using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ControlPanel.Data;
using ControlPanel.Models;

namespace ControlPanel.Pages.Merchants
{
    public class DetailsModel : PageModel
    {
        private readonly ControlPanel.Data.BackdoorContext _context;

        public DetailsModel(ControlPanel.Data.BackdoorContext context)
        {
            _context = context;
        }

        public Merchant Merchant { get; set; }

        #region snippet_OnGetAsync
        // public async Task<IActionResult> OnGetAsync(int? id)
        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            this.Merchant = await _context.MerchantUserInfo
                // .Include(s => s.Enrollments)  // Join
                // .ThenInclude(e => e.Course)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Username == id);

            if (this.Merchant == null)
            {
                return NotFound();
            }
            return Page();
        }
        #endregion
    }
}
