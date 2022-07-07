using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetFriendsService.Controllers.Seguridad
{
    
    public class LoginController : Controller
    {
      
        [HttpGet]
        [Route("Ping")]
        public ActionResult Ping()
        {
            return Ok(true);
        }
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Autenticar( )
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
