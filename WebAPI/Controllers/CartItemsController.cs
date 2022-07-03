using Businness.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemsController : ControllerBase
    {
        ICartItemService _cartService;

        public CartItemsController(ICartItemService cartItemService)
        {
            _cartService = cartItemService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _cartService.GetAll();

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _cartService.GetById(id);

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(CartItem cartItem)
        {
            var result = _cartService.Insert(cartItem);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("update")]
        public IActionResult Update(CartItem cartItem)
        {
            var result = _cartService.Update(cartItem);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(CartItem cartItem)
        {
            var result = _cartService.Delete(cartItem);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
