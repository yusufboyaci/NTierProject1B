using Microsoft.AspNetCore.Mvc;
using NTierProject1B.DATAACCESS.Context;
using NTierProject1B.DATAACCESS.Repositories.Concrete;
using NTierProject1B.ENTITIES.Entities;

namespace NTierProject1B.UI.Controllers
{
    public class CategoryController : Controller
    {
        CategoryRepository _categoryRepository;
        public CategoryController(AppDbContext context)
        {
            _categoryRepository= new CategoryRepository(context);
        }
        [HttpGet("[controller]/List")]
        public IActionResult List()
        {
            try
            {
                List<Category> categories = _categoryRepository.GetActives();
                return Ok(categories);
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
                return Ok(_categoryRepository.GetById(id));
            }
            catch
            {
                return BadRequest("Beklenmedik bir hata oluştu");
            }
        }
        [HttpPost("[controller]/Add")]
        public IActionResult Add([FromBody] Category category)
        {
            try
            {
                _categoryRepository.Add(category);
                return NoContent();
            }
            catch
            {
                return BadRequest("Beklenmedik bir hata oluştu");
            }
        }
        [HttpGet("[controller]/Update")]
        public IActionResult Update([FromBody] Category category)
        {
            try
            {
                _categoryRepository.Update(category);
                _categoryRepository.Activate(category.Id);
                return NoContent();
            }
            catch
            {
                return BadRequest("Beklenmedik bir hata oluştu");
            }
        }
        [HttpGet("[controller]/Delete")]
        public IActionResult Delete([FromBody] Category category)
        {
            try
            {
                _categoryRepository.Remove(category);
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
