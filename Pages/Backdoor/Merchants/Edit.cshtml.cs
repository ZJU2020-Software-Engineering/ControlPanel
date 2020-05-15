using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControlPanel.Data;
using ControlPanel.Models;

namespace ControlPanel.Pages.Merchants
{
    public class EditModel : PageModel
    {
        private readonly ControlPanel.Data.BackdoorContext _context;

        public EditModel(ControlPanel.Data.BackdoorContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Merchant Merchant { get; set; }

        #region snippet_OnGetPost
        // public async Task<IActionResult> OnGetAsync(int? id)
        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            this.Merchant = await _context.MerchantUserInfo.FindAsync(id);

            if (this.Merchant == null)
            {
                return NotFound();
            }
            return Page();
        }

        // public async Task<IActionResult> OnPostAsync(int id)
        public async Task<IActionResult> OnPostAsync(string id)
        {
            var merchantToUpdate = await _context.MerchantUserInfo.FindAsync(id);

            if (merchantToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Merchant>(
                merchantToUpdate,
                "merchant",
                s => s.Username, s => s.Password, s => s.Name, s => s.Address,
                s => s.BusinessLicense, s => s.CorporateIdentity, s => s.Category,
                s => s.PhoneNumber, s => s.Email, s => s.CollectionInformation))
            {
                
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
        #endregion

        // private bool StudentExists(int id)
        private bool PersionExists(string id)
        {
            return _context.MerchantUserInfo.Any(e => e.Username == id);
        }
    }
}
