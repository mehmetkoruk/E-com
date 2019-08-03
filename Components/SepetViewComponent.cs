using EticaretShoes.Interface;
using EticaretShoes.Models;
using EticaretShoes.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EticaretShoes.Components
{
    public class SepetViewComponent:ViewComponent
    {
        private IShoes shoes;
        public SepetViewComponent(IShoes _shoes)
        {
            shoes = _shoes;
        }
        //public IViewComponentResult Invoke()
        //{
        //    var result = shoes.Shoes;
        //    SepetViewModel yenimodel = new SepetViewModel();
        //    yenimodel.SelectedID = RouteData.Values["ShoesId"].ToString();
        //    yenimodel.ListShoes = result.ToList();
        //    Shoes secilen = shoes.Shoes.Where(x => x.ShoesId ==Convert.ToInt32(  yenimodel.SelectedID)).FirstOrDefault();
        //    yenimodel.SelectedSepetItems.Add(secilen);
        //    return View(yenimodel);
        //}
    }
}
