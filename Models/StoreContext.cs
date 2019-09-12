using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;

namespace OnlineStore.Models
{
    public class StoreContext : DbContext
    {
        static StoreContext()
        {
            Database.SetInitializer<StoreContext>(new StoreContextInitializer());
        }

        public DbSet<Product> Products { get; set; }
    }

    class StoreContextInitializer : DropCreateDatabaseIfModelChanges<StoreContext>
    {
        protected override void Seed(StoreContext db)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "Content\\img\\product.jpg";

            using (FileStream fstream = File.OpenRead(path))
            {
                byte[] array = new byte[fstream.Length];
                fstream.Read(array, 0, array.Length);

                Product p1 = new Product { Balance = 100, Name = "Nokia", Price = 100.5, Image = array, Category = "Phones" };
                Product p2 = new Product { Balance = 50, Name = "Samsung", Price = 50.0, Image = array, Category = "Phones" };
                Product p3 = new Product { Balance = 30, Name = "IPhone", Price = 75.0, Image = array, Category = "Phones" };
                Product p4 = new Product { Balance = 15, Name = "Xiaomi", Price = 125.5, Image = array, Category = "Phones" };
                Product p5 = new Product { Balance = 70, Name = "LG", Price = 87.3, Image = array, Category = "Phones" };
                Product p6 = new Product { Balance = 60, Name = "Lenovo", Price = 150.4, Image = array, Category = "Phones" };
                Product p7 = new Product { Balance = 50, Name = "Huawei", Price = 110.1, Image = array, Category = "Phones" };
                Product p8 = new Product { Balance = 50, Name = "Huawei", Price = 110.1, Image = array, Category = "Computers" };
                Product p9 = new Product { Balance = 50, Name = "Xiaomi", Price = 110.1, Image = array, Category = "Computers" };
                Product p10 = new Product { Balance = 50, Name = "Huawei", Price = 110.1, Image = array, Category = "Computers" };
                Product p11 = new Product { Balance = 50, Name = "Samsung", Price = 110.1, Image = array, Category = "Computers" };
                Product p12 = new Product { Balance = 50, Name = "Samsung", Price = 110.1, Image = array, Category = "Computers" };
                Product p13 = new Product { Balance = 50, Name = "Xiaomi", Price = 110.1, Image = array, Category = "Watches" };
                Product p14 = new Product { Balance = 50, Name = "Huawei", Price = 110.1, Image = array, Category = "Watches" };
                Product p15 = new Product { Balance = 50, Name = "Samsung", Price = 110.1, Image = array, Category = "Watches" };
                Product p16 = new Product { Balance = 50, Name = "Huawei", Price = 110.1, Image = array, Category = "Watches" };
                Product p17 = new Product { Balance = 50, Name = "Huawei", Price = 110.1, Image = array, Category = "Watches" };
                Product p18 = new Product { Balance = 50, Name = "Samsung", Price = 110.1, Image = array, Category = "Tablets" };
                Product p19 = new Product { Balance = 50, Name = "Huawei", Price = 110.1, Image = array, Category = "Tablets" };

                db.Products.AddRange(new List<Product> { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10,
                    p11, p12, p13, p14, p15, p16, p17, p18, p19 });
                db.SaveChanges();

            }

        }
    }
}