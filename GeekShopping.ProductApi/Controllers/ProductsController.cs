using GeekShopping.ProductApi.Data.ValueObject;
using GeekShopping.ProductApi.Repository;
using GeekShopping.ProductApi.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductRepository _repository;

        public ProductsController(IProductRepository repository)
        {
            _repository = repository ??  throw new ArgumentNullException(nameof(repository));
        }
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductVO>>> FindAll()
        {
            var products = await _repository.FindAll();
            return Ok(products);
        }
        [Authorize]
        [HttpGet ("{id}")]
        public async Task<ActionResult<ProductVO>> FindById(long id)
        {
            var product = await _repository.FindById(id);
            if(product.Id <= 0) return NotFound();

            return Ok(product);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<ProductVO>> Create([FromBody] ProductVO vo)
        {

            if (vo == null) return BadRequest();
            var product = await _repository.Create(vo);
            return Ok(product);

        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult<ProductVO>> Update([FromBody] ProductVO vo)
        {

            if (vo == null) return BadRequest();
            var product = await _repository.Update(vo);
            return Ok(product);

        }

        [HttpDelete("{id}")]
        [Authorize(Roles = Role.Admin)]
        public async Task<ActionResult<ProductVO>> Delete (long id)
        {
            var status = await _repository.Delete(id);
            if(!status) return BadRequest();
            return Ok(status);

        }




    }
}
