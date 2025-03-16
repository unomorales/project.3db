using System;
using OOP.ManageProduct;

class MainProgram
{
    public static void Main()
    {
        InsertNewProduct newProduct = new InsertNewProduct();

        // Insert a product with complete details
        newProduct.InsertData("Laptop Acer", 500, "High-performance laptop", "Electronics", 10);
    }
}
