﻿namespace ShoppingCartProject.Models
{
    public class ShoppingCart
    {
        private readonly List<Product> _products;

        public ShoppingCart()
        {
            _products = new List<Product>();
        }

        public int ProductCount => _products.Count;

        //TODO Készítse el a ShoppingCart osztályban azokat a metódusokat, amelyekkel sikeresen lefutnak a tesztesetek!
        public void AddProduct (string productName, double price)
        {
            Product newProd = new(productName, price);
            _products.Add(newProd);
        }

        public bool RemoveProduct(string productName)
        {
            var res = _products.Find(prod => prod.Name == productName);
            return res != null ? _products.Remove(res) : throw new InvalidOperationException("nincs cucc");
        }

        public double GetTotalPrice()
        {
            double totalPrice = 0;
            _products.ForEach(x => totalPrice += x.Price);
            return totalPrice;
        }

        public List<Product> GetProducts()
        {
            return _products;
        }
    }
}
