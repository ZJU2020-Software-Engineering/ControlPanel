#region snippet_All
using ControlPanel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ControlPanel.Pages.People
{
    public class DeleteModel : PageModel
    {
        private readonly ControlPanel.Data.BackdoorContext _context;

        public DeleteModel(ControlPanel.Data.BackdoorContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Person Person { get; set; }
        public string ErrorMessage { get; set; }

        // public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        public async Task<IActionResult> OnGetAsync(string id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            this.Person = await _context.PersonalUserInfo
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Username == id);

            if (this.Person == null)
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

            var person = await _context.PersonalUserInfo.FindAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            try
            {
                _context.PersonalUserInfo.Remove(person);
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