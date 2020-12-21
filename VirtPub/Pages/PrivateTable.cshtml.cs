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
        [BindProperty]
        public string Text { get; set; }
        public void OnGet()
        {
          Text = GetUrl();
        }



        public string GetUrl()
        {
            var hostPath = HttpContext.Request.Host.ToString();
            var path = HttpContext.Request.Path.ToString();
            return hostPath + path;
        }
    }
}
