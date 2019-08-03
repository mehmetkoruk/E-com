using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EticaretShoes.ViewComponents
{
    public class UserViewComponent: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            ViewBag.User = (this.User.Identity.IsAuthenticated) ? this.User.Identity.Name.ToString() : null;
            return View();
        }
    }
}
