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
        public void OnGet()
        {
        }
    }
}
