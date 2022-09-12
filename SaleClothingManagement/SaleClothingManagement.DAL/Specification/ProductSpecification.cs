using SaleClothingManagement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaleClothingManagement.DAL.Specification
{
    public static class ProductSpecification
    {
        public static List<Func<Product, bool>> GetListCondition(Dictionary<string, string> param)
        {
            List<Func<Product, bool>> funcs = new List<Func<Product, bool>>();

            if (param.ContainsKey("containName"))
                funcs.Add(ProductSpecification.ContainName(param["containName"].ToLower()));

            if (param.ContainsKey("equalName"))
                funcs.Add(ProductSpecification.EqualName(param["equalName"].ToLower()));

            if (param.ContainsKey("lessThanPrice"))
                funcs.Add(ProductSpecification.LessThanPrice(param["lessThanPrice"].ToLower()));

            if (param.ContainsKey("greaterThanPrice"))
                funcs.Add(ProductSpecification.GreaterThanPrice(param["greaterThanPrice"].ToLower()));

            if (param.ContainsKey("lessThanRemaining"))
                funcs.Add(ProductSpecification.LessThanPrice(param["lessThanRemaining"].ToLower()));

            if (param.ContainsKey("greaterThanRemaining"))
                funcs.Add(ProductSpecification.GreaterThanPrice(param["greaterThanRemaining"].ToLower()));

            return funcs;
        }

        // NAME
        public static Func<Product, bool> ContainName(string name)
        {
            return s => s.Name.ToLower().Contains(name) && s.Name != null;
        }

        public static Func<Product, bool> EqualName(string name)
        {
            return s => s.Name.ToLower().Equals(name) && s.Name != null;
        }

        // PRICE
        public static Func<Product, bool> LessThanPrice(string priceStr)
        {
            decimal price = decimal.Parse(priceStr);
            return s => s.Price <= price && s.Price != null;
        }

        public static Func<Product, bool> GreaterThanPrice(string priceStr)
        {
            decimal price = decimal.Parse(priceStr);
            return s => s.Price >= price && s.Price != null;
        }

        // REMAINING
        public static Func<Product, bool> LessThanRemaining(string remainingStr)
        {
            decimal reamining = decimal.Parse(remainingStr);
            return s => s.Remaining <= reamining && s.Price != null;
        }

        public static Func<Product, bool> GreaterThanRemaining(string remainingStr)
        {
            decimal reamining = decimal.Parse(remainingStr);
            return s => s.Remaining >= reamining && s.Price != null;
        }

    }
}
