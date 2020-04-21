using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ControlPanel.Data;
using ControlPanel.Models;
// using Microsoft.AspNetCore.Authorization;

namespace ControlPanel.Pages.People
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
        public Person Person { get; set; }

        #region snippet_OnPostAsync
        public async Task<IActionResult> OnPostAsync()
        {
            #region snippet_TryUpdateModelAsync
            var emptyPerson = new Person();

            if (await TryUpdateModelAsync<Person>(
                emptyPerson,
                "person",   // Prefix for form value.
                s => s.Username, s => s.Name, s => s.Sex, s => s.IdentityCardNumber,
                s => s.Status,s => s.PhoneNumber, s => s.Email))
            {
                emptyPerson.CreationTime = DateTime.Now;
                emptyPerson.UpdateTime = DateTime.Now;
                _context.PersonalUserInfo.Add(emptyPerson);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            #endregion

            return Page();
        }
        #endregion
    }
}