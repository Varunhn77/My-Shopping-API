﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShoppingEntity;
using MyShoppingRepository.Data;

namespace MyShoppingRepository.Repositories
{
    public class ProductRepository : IProductRepository
    {
        //set dbcontext instance to make CRUD operation
        MyshoppingDbContext _context;

        public ProductRepository(MyshoppingDbContext dbcontext) //Constructor //Dependency Injection
        {
            //getting instance from container and assign to local variable
            _context = dbcontext;
        }
        public void AddProduct(Product product)
        {
            //insert into products values(product id,product,name,product.desc,product.price)
            _context.Products.Add(product);
            _context.SaveChanges(); //execute the query

        }
        public void UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }
        public void DeleteProduct(int id)
        {
           Product product = _context.Products.Find(id);
            //delete from products where id=1
            _context.Products.Remove(product);  
            _context.SaveChanges();
        }
       public Product GetProductById(int id)
        {
            //select * from prodcuts where id=1
            Product obj = _context.Products.Find(id);
            return obj;
        }
        public List<Product> GetAll()
        {
            //select * from products
            var list = _context.Products.ToList();
            return list;
        }

       
    }
}
