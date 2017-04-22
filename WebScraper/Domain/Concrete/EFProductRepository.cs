using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstract;
using Domain.Entities;


//talk to the database
namespace Domain.Concrete
{
    public class EFProductRepository : IProductRepository
    {
        private EFDbContext context= new EFDbContext();
        public IEnumerable<Product> Products
        {
            get { return context.Products; }
        }

        public void SaveProduct(Product product, Price price)
        {
            if (product.ProductID == 0)
            {
                context.Products.Add(product);
                context.Prices.Add(price);

            }
            else
            {
                Product dbEntry =
                    context.Products.Find(product.ProductID);
                if (dbEntry != null)
                {
                    dbEntry.Title = product.Title;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = product.Price;
                    dbEntry.Platform = product.Platform;
                    dbEntry.ImageData = product.ImageData;
                    dbEntry.ImageMimeType = product.ImageMimeType;

                }
                Price dbPrice = context.Prices.Find(product.ProductID);
                if (dbPrice != null)
                {
                    dbPrice.PriceUsed = price.PriceUsed;
                    dbPrice.PriceNew = price.PriceNew;
                }

            }
            context.SaveChanges();
        }

        public Product DeleteProduct(int productID)
        {
            Product dbEntry = context.Products.Find(productID);
            if (dbEntry != null)
            {
                context.Products.Remove(dbEntry);
                context.SaveChanges();
            }
            Price dbPrice = context.Prices.Find(productID);
            if (dbPrice != null)
            {
                context.Prices.Remove(dbPrice);
                context.SaveChanges();
            }
            return dbEntry;
        }

    }
}
