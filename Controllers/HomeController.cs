using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EticaretShoes.Interface;
using EticaretShoes.Models;
using EticaretShoes.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EticaretShoes.Controllers
{
    public class HomeController : Controller
    {
        //public SepetViewModel swm = new SepetViewModel();
        //public List<Shoes> secilenler = new List<Shoes>();
        //public List<Shoes> all = new List<Shoes>();
        private ICart cart;
        private IShoes repo;
        private ICartItem cartItem;
        private IUser user;
        public HomeController(IShoes _repo, ICart _cart, ICartItem _cartItem,IUser _user)
        {
            repo = _repo;
            cart = _cart;
            cartItem = _cartItem;
            user = _user;
        }
        public IActionResult Index()
        {
            var x = cart.CreateCart();
            var y = cart.UpdateCart(Convert.ToInt32(x));
            //Create Cartitems with both cartid and cartitemsid (insert)
            //SepetViewModel yenimodel = new SepetViewModel();
            //yenimodel.ListShoes = repo.Shoes.ToList();
            ViewBag.username = this.User.Identity.Name;

            return View(repo.Shoes);
        }
        public IActionResult ListProduct()
        {
            var a = repo.Shoes.ToList();
            return View(a);
        }
        public IActionResult Index2()
        {
            
            ViewBag.username = this.User.Identity.Name;

            return View("Index", repo.Shoes);
        }
        public IActionResult AddtoCart(int ShoesId)
        {

            cartItem.AddToCart(ShoesId, cart.AddCart());
           // SepetViewModel yenimodel = new SepetViewModel();
            //yenimodel.ListShoes = repo.Shoes.ToList();

            return RedirectToAction("Index2");
        }
        public IActionResult AddtoCart2(int ShoesId)
        {

            cartItem.AddToCart(ShoesId, cart.AddCart());
            // SepetViewModel yenimodel = new SepetViewModel();
            //yenimodel.ListShoes = repo.Shoes.ToList();
            var xx = cartItem.CartItems.Where(x => x.CartId == cart.AddCart());
            List<Shoes> liste = new List<Shoes>();
            SepetViewModel yenimod = new SepetViewModel();
            double total = 0;
            foreach (var item in xx)
            {
                int ayakkabiid = item.ShoesId;
                Shoes a = repo.Shoes.Where(x => x.ShoesId == ayakkabiid).FirstOrDefault();
                total += a.Price;
                liste.Add(a);
            }
            yenimod.totalamount = total;
            yenimod.ListShoes = liste;

            return View("SepetGetir",yenimod);
        }
        public IActionResult Details(int ShoesId)
        {
            return View(repo.Shoes.First(x=> x.ShoesId== ShoesId));
        }


        [Authorize]
        public IActionResult Finish()
        {
            var x = cart.CreateCart();
            var y = cart.UpdateCart(Convert.ToInt32(x));


            return View();
        }
        public IActionResult Delete(int id)
        {
          var a=  repo.Shoes.Where(x => x.ShoesId == id).FirstOrDefault();
            repo.DelProduct(a);
            return RedirectToAction("ListProduct");
        }



        //[HttpGet]
        //public IActionResult SepetGetir(SepetViewModel sepet)
        //{
        //    return View(sepet);
        //}



        public IActionResult SepetGetir()
        {
            var xx = cartItem.CartItems.Where(x => x.CartId == cart.AddCart());
            List<Shoes> liste = new List<Shoes>();
            SepetViewModel yenimod = new SepetViewModel();
            double total = 0;
            foreach (var item in xx)
            {
                int ayakkabiid = item.ShoesId;
                Shoes a = repo.Shoes.Where(x => x.ShoesId == ayakkabiid).FirstOrDefault();
                total += a.Price;
                liste.Add(a);
            }
            yenimod.totalamount = total;
            yenimod.ListShoes = liste;
            return View("SepetGetir", yenimod);
        }
        public IActionResult RemovefromCart(int shoesId)
        {
            cartItem.DelCartitem(cart.AddCart(), shoesId);
            var xx = cartItem.CartItems.Where(x => x.CartId == cart.AddCart());
            List<Shoes> liste = new List<Shoes>();
            SepetViewModel yenimod = new SepetViewModel();
            double total = 0;
            foreach (var item in xx)
            {
                int ayakkabiid = item.ShoesId;
                Shoes a = repo.Shoes.Where(x => x.ShoesId == ayakkabiid).FirstOrDefault();
                total += a.Price;
                liste.Add(a);
            }
            yenimod.totalamount = total;
            yenimod.ListShoes = liste;
            return View("SepetGetir",yenimod);
        }
       
        public IActionResult CreateUser(int UserId, string Name, string surName, string Country, string stretAdress, string Town, string Postcode, string Phone, string Email)
        {
            User yeniuser = new User();
           
            yeniuser.Name = Name;
            yeniuser.surName = surName;
            yeniuser.Country = Country;
            yeniuser.stretAdress = stretAdress;
            yeniuser.Town = Town;
            yeniuser.PostCode = Postcode;
            yeniuser.Phone = Phone;
            yeniuser.Email = Email;
             yeniuser.CartNo = cart.AddCart();
            user.AddUser(yeniuser);
            return RedirectToAction("Checkout");
        }
       


         //[HttpGet]
         //public IActionResult Sepet()
         //{
         //    swm.SelectedShoesItems = secilenler;
         //    swm.ListShoes = repo.Shoes.ToList();
         //    return View("SepetGetir",swm);
         //}
         [Authorize]
        public IActionResult Checkout()
        {
            var xx = cartItem.CartItems.Where(x => x.CartId == cart.AddCart());
            List<Shoes> liste = new List<Shoes>();
            SepetViewModel yenimod = new SepetViewModel();
            double total = 0;
            foreach (var item in xx)
            {
                int ayakkabiid = item.ShoesId;
                Shoes selected = repo.Shoes.Where(x => x.ShoesId == ayakkabiid).FirstOrDefault();
                total += selected.Price;
                liste.Add(selected);
            }
            yenimod.totalamount = total;
            yenimod.ListShoes = liste;
            //user model ve authorize eklenecek loginsiz checkout yaptırmayacak dbye user bilgisi girilecek
            //toplam tutar hesaplama eklenecek sepet görüntüsü değişecek

            return View("Checkout",yenimod);
        }

        [Authorize]
        public IActionResult AdminPage()

        {
            return View();
        }
        public IActionResult CreateProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateProduct(Shoes s)
        {
            var newproduct = new Shoes()
            {
                ShoesName = s.ShoesName,
                imageUrl = s.imageUrl,
                Price = s.Price,
                Gender = s.Gender,
                CategoryNo = s.CategoryNo,


            };
            var x = repo.AddProduct(newproduct);
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
    }
}