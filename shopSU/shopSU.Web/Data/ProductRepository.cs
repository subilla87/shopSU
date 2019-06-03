namespace shopSU.Web.Data
{
    using shopSU.Web.Data.Entities;
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(DataContext context) : base(context)
        {
        }

    }
}
