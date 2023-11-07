using WebAPIDemo.Entities;

namespace WebAPIDemo.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext context;

        public ProductRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
           
        public int AddProduct(Product product)
        {
            int result = 0;
            product.IsActive = 1;
            context.Products.Add(product);
            result = context.SaveChanges();
            return result;
        }

        public int DeleteProduct(int id)
        {
            int result = 0;
            var pro = context.Products.Where(x => x.Id == id).FirstOrDefault();
            if (pro != null)
            {
                pro.IsActive = 0;
                result = context.SaveChanges();
            }
            return result;

        }

        public Product GetProductById(int id)
        {
            int result = 0;
            var product = context.Products.Where(x => x.Id == id).FirstOrDefault();
            return product;
        }

        public IEnumerable<Product> GetProducts()
        {
            return context.Products.Where(x => x.IsActive == 1).ToList();
        }

        public int UpdateProduct(Product product)
        {
            int result = 0;
            var b = context.Products.Where(x => x.Id == product.Id).FirstOrDefault();
            if (b != null)
            {
                b.Name = product.Name;
                b.Price = product.Price;
                b.Cname = product.Cname;
                b.IsActive = 1;
                result = context.SaveChanges();
            }
            return result;

        }

       
    }
}
