using Microsoft.AspNetCore.Mvc;
using NTierProject1B.DATAACCESS.Context;
using NTierProject1B.DATAACCESS.Repositories.Concrete;
using NTierProject1B.ENTITIES.Entities;

namespace NTierProject1B.UI.Controllers
{
    public class ProductController : Controller
    {
        ProductRepository _productRepository;
        public ProductController(AppDbContext context)
        {
            _productRepository = new ProductRepository(context);
        }
        [HttpGet("[controller]/List")]
        public IActionResult List()
        {
            try
            {
                List<Product> products = _productRepository.GetActives();
                return Ok(products);
            }
            catch
            {
                return BadRequest("Beklenmedik bir hata oluştu");
            }
        }
        [HttpGet("[controller]/Get")]
        public IActionResult Get(Guid id)
        {
            try
            {
                return Ok(_productRepository.GetById(id));
            }
            catch
            {
                return BadRequest("Beklenmedik bir hata oluştu");
            }
        }
        [HttpPost("[controller]/Add")]
        public IActionResult Add([FromBody] Product product)
        {
            if (product != null)
            {
                try
                {
                    _productRepository.Add(product);
                    return NoContent();
                }
                catch
                {
                    return BadRequest("Beklenmedik bir hata oluştu");
                }
            }
            return BadRequest("Beklenmedik bir hata oluştu");
        }
        [HttpPut("[controller]/Update")]
        public IActionResult Update([FromBody] Product product)
        {
            try
            {
                _productRepository.Update(product);
                _productRepository.Activate(product.Id);
                return NoContent();
            }
            catch
            {
                return BadRequest("Beklenmedik bir hata oluştu");
            }
        }
        [HttpDelete("[controller]/Delete")]
        public IActionResult Delete([FromBody] Product product)
        {
            try
            {
                _productRepository.Remove(product);
                return NoContent();
            }
            catch
            {
                return BadRequest("Beklenmedik bir hata oluştu");
            }
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
