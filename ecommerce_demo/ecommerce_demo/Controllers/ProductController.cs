using ecommerce_demo.Datas;
using ecommerce_demo.DTOs;
using ecommerce_demo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ProductController(ApplicationDbContext context)
        {
            _context = context;
            
        }
        [HttpGet]
        public async Task<IActionResult>GetProducts()
        {
            var products = await _context.Products.Include(c => c.Category).ToListAsync();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>GetProductById(int id)
        {
            var product=await _context.Products.Include(_ => _.Category).FirstOrDefaultAsync(e=>e.ProductId==id);
            if(product==null) return NotFound();
            return Ok(product);
        }
        [HttpPost]
        public async Task<IActionResult>CreateProduct(ProductDto dto)
        {
            var product = new Product
            {
                ProductName = dto.ProductName,
                Description = dto.Description,
                Price = dto.Price,
                Stock = dto.StockQuantity,
                ImageUrl = dto.ImageUrl,
                CategoryId = dto.CategoryId
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return Ok(product);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult>UpdateProduct(int id,Product product)
        {
            if (id != product.ProductId) return BadRequest("Invalid Product id");
            var existingProduct = await _context.Products.FindAsync(id);
            if (existingProduct == null) return NotFound();
            existingProduct.ProductName=product.ProductName;
            existingProduct.Description=product.Description;
            existingProduct.Price=product.Price;
            existingProduct.Stock=product.Stock;
            existingProduct.ImageUrl=product.ImageUrl;
            existingProduct.CategoryId = product.CategoryId;
            await _context.SaveChangesAsync();
            return Ok(existingProduct);


            
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return Ok("Product deleted successfully");
        }
    }
}
