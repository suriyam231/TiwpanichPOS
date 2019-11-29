using Database.API.Interface;
using Database.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database.API.Service
{
    public class WarehouseService : WarehouseInterface
    {
        public readonly SRM_DEVContext Context;

        public WarehouseService(SRM_DEVContext context)
        {
            Context = context;
        }

        public List<TypeProduct> getTypeProduct()
        {
            List<TypeProduct> res = (from data in Context.TypeProduct
                                     select new TypeProduct
                                     {
                                         TypeId = data.TypeId,
                                         TypeName = data.TypeName
                                     }).ToList();
            return res;
        }
        public List<Product> getProducts()
        {
            List<Product> product = (from data in Context.Product
                                     select new Product
                                     {
                                         ProductId = data.ProductId,
                                         ProductName = data.ProductName,
                                         ProductAmount = data.ProductAmount,
                                         ProductPrice = data.ProductPrice,
                                         ProductDetail = data.ProductDetail,
                                         CostPrice = data.CostPrice,
                                         ProductReference = data.ProductReference,
                                         TypeId = data.TypeId
                                     }).ToList();
            return product;
        }

        public string addProduct(Product[] values)
        {
            Product ProValues = new Product();
            ProValues.ProductId = values[0].ProductId;
            ProValues.ProductName = values[0].ProductName;
            ProValues.ProductAmount = values[0].ProductAmount;
            ProValues.ProductPrice = values[0].ProductPrice;
            ProValues.ProductDetail = values[0].ProductDetail;
            ProValues.CostPrice = values[0].CostPrice;
            ProValues.ProductReference = values[0].ProductReference;
            ProValues.TypeId = values[0].TypeId;
            Context.Product.Add(ProValues);
            Context.SaveChanges();
            return "success";

        }
    }
}
