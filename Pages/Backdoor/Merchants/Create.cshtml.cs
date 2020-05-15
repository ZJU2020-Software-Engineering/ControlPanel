using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ControlPanel.Data;
using ControlPanel.Models;

namespace ControlPanel.Pages.Merchants
{
    // [Authorize]
    public class CreateModel : PageModel
    {
        private readonly ControlPanel.Data.BackdoorContext _context;

        public CreateModel(ControlPanel.Data.BackdoorContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Merchant Merchant { get; set; }

        #region snippet_OnPostAsync
        public async Task<IActionResult> OnPostAsync()
        {
            #region snippet_TryUpdateModelAsync
            var emptyMerchant = new Merchant();

            if (await TryUpdateModelAsync<Merchant>(
                emptyMerchant,
                "merchant",   // Prefix for form value.
                s => s.Username, s => s.Password, s => s.Name, s => s.Address,
                s => s.BusinessLicense, s => s.CorporateIdentity, s => s.Category,
                s => s.PhoneNumber, s => s.Email, s => s.CollectionInformation))
            {
                _context.MerchantUserInfo.Add(emptyMerchant);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            #endregion

            return Page();
        }
        #endregion
    }
}