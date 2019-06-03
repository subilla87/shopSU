namespace shopSU.Web.Data
{
    using shopSU.Web.Data.Entities;
    public class CountryRepositorty : GenericRepository<Country>, ICountryRepositorty
    {
        public CountryRepositorty(DataContext context) : base(context)
        {
        }
    }
}
