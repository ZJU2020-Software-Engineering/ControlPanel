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

namespace ControlPanel.Pages.People
{
    public class EditModel : PageModel
    {
        private readonly ControlPanel.Data.BackdoorContext _context;

        public EditModel(ControlPanel.Data.BackdoorContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Person Person { get; set; }

        #region snippet_OnGetPost
        // public async Task<IActionResult> OnGetAsync(int? id)
        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            this.Person = await _context.PersonalUserInfo.FindAsync(id);

            if (this.Person == null)
            {
                return NotFound();
            }
            return Page();
        }

        // public async Task<IActionResult> OnPostAsync(int id)
        public async Task<IActionResult> OnPostAsync(string id)
        {
            var personToUpdate = await _context.PersonalUserInfo.FindAsync(id);

            if (personToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Person>(
                personToUpdate,
                "person",
                s => s.Username, s => s.Name, s => s.Gender, s => s.IdentityCardNumber,
                s => s.Status, s => s.PhoneNumber, s => s.Email, s => s.Password,
                s => s.HealthStatus, s => s.HealthCode, s => s.Visitedplaces,
                s => s.PaymentInformation, s => s.PersonalCenterLink))
            {
                
                personToUpdate.UpdateTime = DateTime.Now;
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
        #endregion

        // private bool StudentExists(int id)
        private bool PersionExists(string id)
        {
            return _context.PersonalUserInfo.Any(e => e.Username == id);
        }
    }
}
