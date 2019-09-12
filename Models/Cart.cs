using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineStore.Models
{
    public class Cart
    {
        private List<ProductLine> lineCollection = new List<ProductLine>();

        public void AddItem(Product prod, int quantity)
        {
            ProductLine line = lineCollection
                .Where(g => g.Product.Id == prod.Id)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new ProductLine
                {
                    Product = prod,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(int id)
        {
            lineCollection.RemoveAll(l => l.Product.Id == id);
        }

        public void ReduceAmount(int id)
        {
            ProductLine pl = lineCollection.Where(l => l.Product.Id == id).FirstOrDefault();

            if (pl != null)
            {
                pl.Quantity -= 1;
            }
        }

        public double ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Product.Price * e.Quantity);

        }
        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<ProductLine> Lines
        {
            get { return lineCollection; }
        }
    }

    public class ProductLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
