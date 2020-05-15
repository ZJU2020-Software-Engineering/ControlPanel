#region snippet_All
using ControlPanel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ControlPanel.Pages.Merchants
{
    public class DeleteModel : PageModel
    {
        private readonly ControlPanel.Data.BackdoorContext _context;

        public DeleteModel(ControlPanel.Data.BackdoorContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Merchant Merchant { get; set; }
        public string ErrorMessage { get; set; }

        // public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        public async Task<IActionResult> OnGetAsync(string id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            this.Merchant = await _context.MerchantUserInfo
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Username == id);

            if (this.Merchant == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = "Delete failed. Try again";
            }

            return Page();
        }

        // public async Task<IActionResult> OnPostAsync(int? id)
        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var merchant = await _context.MerchantUserInfo.FindAsync(id);

            if (merchant == null)
            {
                return NotFound();
            }

            try
            {
                _context.MerchantUserInfo.Remove(merchant);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction("./Delete",
                                     new { id, saveChangesError = true });
            }
        }
    }
}
#endregion