

namespace shopSU.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using shopSU.Web.Data;
    using shopSU.Web.Data.Entities;
    using shopSU.Web.Helpers;
    using System.Threading.Tasks;
    public class ProductsController : Controller
    {
        private readonly IRepository repository;
        private readonly IUserHelper userHelper;

        public ProductsController(IRepository repository, IUserHelper userHelper)
        {
            this.repository = repository;
            this.userHelper = userHelper;
        }

        // GET: Products
        public IActionResult Index()
        {
            return View(this.repository.GetProducts());
        }

        // GET: Products/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = this.repository.GetProduct(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                product.User = await this.userHelper.GetUserByEmailAsync("subilla@gmail.com");
                this.repository.AddProduct(product);
                await this.repository.SaveAllAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var product = this.repository.GetProduct(id.Value);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    product.User = await this.userHelper.GetUserByEmailAsync("subilla@gmail.com");
                    this.repository.UpdateProduct(product);
                    await this.repository.SaveAllAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.repository.ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = this.repository.GetProduct(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = this.repository.GetProduct(id);
            this.repository.RemoveProduct(product);
            await this.repository.SaveAllAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}
