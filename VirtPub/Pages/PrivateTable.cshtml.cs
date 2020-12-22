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
        public Guid TableId { get; set; }
        public void OnGet(Guid tableId)
        {
            if (tableId == Guid.Empty)
            {
                TableId = Guid.NewGuid();
            }
            else
            {
                TableId = tableId;
            }
        }



        //public string GetUrl()
        //{
        //    var hostPath = HttpContext.Request.Host.ToString();
        //    var path = HttpContext.Request.Path.ToString();
        //    return hostPath + path;
        //}
    }
}
