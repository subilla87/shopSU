namespace shopSU.Web.Data
{
    using System.Linq;
    using System.Threading.Tasks;
    using shopSU.Web.Data.Entities;
    public interface IProductRepository : IGenericRepository<Product>
    {
        IQueryable GetAllWithUsers();
    }
}
