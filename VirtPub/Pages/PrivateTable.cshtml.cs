using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;



namespace VirtPub.Pages
{
    [Authorize]
    public class PrivateTableModel : PageModel
    {
        [BindProperty(SupportsGet =true)]
        public Guid Id { get; set; }

        public IActionResult OnGet()
        {
            if(Id== Guid.Empty)
                return RedirectToPage("/Index");
            return Page();
        }

    }
}
