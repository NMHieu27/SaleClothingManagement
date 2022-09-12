using SaleClothingManagement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaleClothingManagement.DAL.Specification
{
    public static class SupplierSpecification
    {
        public static List<Func<Supplier, bool>> GetListCondition(Dictionary<string, string> param)
        {
            List<Func<Supplier, bool>> funcs = new List<Func<Supplier, bool>>();

            if (param.ContainsKey("name"))
                funcs.Add(SupplierSpecification.ContainName(param["name"].ToLower()));

            if (param.ContainsKey("phone"))
                funcs.Add(SupplierSpecification.ContainPhone(param["phone"].ToLower()));

            if (param.ContainsKey("country"))
                funcs.Add(SupplierSpecification.ContainCountry(param["country"].ToLower()));

            if (param.ContainsKey("description"))
                funcs.Add(SupplierSpecification.ContainDescription(param["description"].ToLower()));

            return funcs;
        }

        public static Func<Supplier, bool> ContainName(string name)
        {
            return s => s.Name.ToLower().Contains(name) && s.Name != null;
        }

        public static Func<Supplier, bool> EqualName(string name)
        {
            return s => s.Name.ToLower().Equals(name) && s.Name != null;
        }

        public static Func<Supplier, bool> ContainPhone(string phone)
        {
            return s => s.Phone.ToLower().Contains(phone) && s.Phone != null;
        }

        public static Func<Supplier, bool> ContainCountry(string country)
        {
            return s => s.Country.ToLower().Contains(country) && s.Country != null;
        }

        public static Func<Supplier, bool> EqualCountry(string country)
        {
            return s => s.Country.ToLower().Equals(country) && s.Country != null;
        }

        public static Func<Supplier, bool> ContainDescription(string description)
        {
            return s => s.Description.ToLower().Contains(description) && s.Description != null;
        }

    }
}
