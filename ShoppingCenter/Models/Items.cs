using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCenter.Models
{
    public class Items

    {
        private Products product = new Products();
        private int quantity;
        private string methodPayment;
        private string reception;


        public  Items()
        { }

        public Items (Products product, int count, string method,string reception)
        {
            this.product = product;
            this.quantity = count;
            this.methodPayment = method;
            this.reception = reception;
        }

        public Items(Products product, int count)
        {
            this.product = product;
            this.quantity = count;
           
        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        public Products Product

        {
            get { return product; }
            set { product = value; }
        }

        public string MethodPayment
        {
            get
            {
                return methodPayment;
            }

            set
            {
                methodPayment = value;
            }
        }


        public string Reception
        {
            get
            {
                return reception;
            }

            set
            {
                reception = value;
            }
        }
    }
}