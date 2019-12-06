using Database.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database.API.Interface
{
    public interface WarehouseInterface
    {
        List<TypeProduct> getTypeProduct();
        List<Product> getProducts();
        string addProduct(Product[] values);
        string updateProduct( string ModalType, string ProductID, float number);
        string Productupdate(Product values);
        string deleteProduct(string values);
    }
}
