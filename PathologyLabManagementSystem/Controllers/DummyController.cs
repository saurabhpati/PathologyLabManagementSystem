using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PathologyLabManagementSystem.Controllers
{
    public class DummyController : Controller
    {
        // GET: Dummy
        public ActionResult Index()
        {
            GiftViewModel lst = new GiftViewModel();
            return View(lst);
        }

        public ActionResult BlankEditorRow()
        {
            return PartialView("GiftEditorRow", new Gift());
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Index(IEnumerable<Gift> gifts)
        {

            List<Gift> lst = new List<Gift>(){
            new Gift { Name = "Tall Hat", Price = 39.95 },
                    new Gift { Name = "Long Cloak", Price = 120.00 }
            };

            return View(lst);
        }

        
    }
    public class Gift
    {
        public Gift()
        {
            //lstBrands = new List<Brands>()
            //{
            //    new Brands{Id =100, Text ="Sony"},
            //    new Brands{Id =200, Text = "LG"},
            //    new Brands {Id=300, Text= "Toshiba"},
            //    new Brands {Id=300, Text= "Toshiba5"},
            //    new Brands {Id=300, Text= "Toshiba9"}
            //};

            lstBrands = new List<string>()
            {
                "Sony",
                "LG",
                "Toshiba",
            };
        }

        [Required(ErrorMessage = "Enter Name")]
        public string Name { get; set; }

        public double Price { get; set; }

        public string Brand { get; set; }

        public List<string> lstBrands { get; set; }

        public string AccountSelectedId { get; set; }

    }
    public class GiftViewModel
    {

        public GiftViewModel()
        {
            lst = new List<Gift>(){
            new Gift { Name = "Tall Hat", Price = 39.95 },
                    new Gift { Name = "Long Cloak", Price = 120.00 }
            };
        }


        public List<Gift> lst { get; set; }
    }
}