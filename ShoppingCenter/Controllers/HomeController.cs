using ShoppingCenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ShoppingCenter.Controllers
{
    public class HomeController : Controller
    {
        ProductsDBC DB = new ProductsDBC();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult add_product(Products product)
        {
            if (!ModelState.IsValid)
            {
                return View("Index",product);
            }
            else
            {
               
                DB.productsList.Add(product);
                DB.SaveChanges();
                return View("Index");
            }
        }

        public ActionResult Main()
        {
            return View("Main");
        }

        [HttpGet]
        public ActionResult Offer()
        {
            var productList = DB.productsList.ToList();         
            return View("Offer",productList);
           
        }
       

        public ActionResult Order(int id,int quantity)
        {
            var count = quantity;
            var productList = DB.productsList.ToList();


            if (isProductAvailable(productList, id,quantity) != true)
                return View("Order");


            if (Session["Order"] == null)
            {
                List<Items> productsCart = new List<Items>();
                productsCart.Add(new Items(DB.productsList.Find(id),count));
                Session["Order"] = productsCart;
            }
            else
            {
                List<Items> productsCart = (List<Items>)Session["Order"];
                int productIndex = isExisting(id);

                    if (productIndex == -1)
                    {
                        productsCart.Add(new Items(DB.productsList.Find(id), count));
                    }
                    else
                    {
                        productsCart[productIndex].Quantity+=count;
                        Session["Order"] = productsCart;
                    }
            }
          
            return View ("Order");
        }

        private int isExisting (int id)
        {
            List<Items> productsCart = (List<Items>)Session["Order"];
            for (int i=0; i<productsCart.Count;i++)
            
                if (productsCart[i].Product.productID == id)
                    return i;

                return -1;
            
        }

        private bool isProductAvailable(List<Products> product, int id, int quantity)

        {
            if (product[id - 1].productAmount > 0)
            {
                product[id - 1].productAmount -= quantity;
                DB.SaveChanges();
                return true;
            }
            else
            return false;
        }

        public ActionResult CompleteOrder ()
        {
            var productList = DB.productsList.ToList();
            return View("CompleteOrder",productList);
        }
        
        public ActionResult CompletedOrder(string methodPayment,string reception)
        {
            List<Items> productsCart = (List<Items>)Session["Order"];
            productsCart[0].MethodPayment = methodPayment;
            productsCart[0].Reception = reception;
            Session["CompletedOrder"] = productsCart;

            return View("CompletedOrder",productsCart);
        }
       
    }
}