using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gingerbrich_backend.Models;
using Gingerbrich_backend.HelperModels;

namespace Gingerbrich_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ModelContext _context;

        public ProductsController(ModelContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
            return await _context.Product.ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Product.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpGet("getProductsData")]
        public async Task<ActionResult<ProductData>> getdata()
        {
            try
            {
                List<Brand> brandQuery = _context.Brand.ToList();
                List<Category> catelogQuery = _context.Category.ToList();
                //List<string> sizes = _context. .Select(x=>x.size).ToList();
                ProductData productData = new ProductData();
                //productData.brands = brandQuery;
                //productData.categories = catelogQuery;
                //productData.sizes = sizes;
                return Ok(new { productData });

            }
            catch(Exception e) {
                return BadRequest(new {message="check your connections" });
            }
        }

        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct([FromBody] ProductModel productModel)
        {
            try
            {
                var query = _context.Product.FirstOrDefault(x => x.brand_name == productModel.brand_name && x.name == productModel.name);
                if(query == null)
                {
                    Product product = new Product();
                    foreach (var item in productModel.sizesQuantity)
                    {
                        Size size = new Size() {
                            size = item.size,
                            left = item.left
                        };
                        _context.Size.Add(size);
                        Product_Size product_size = new Product_Size
                        {
                            product = product,
                            size = size
                        };
                        _context.Product_Size.Add(product_size);
                    }
                    foreach(var item in productModel.categories)
                    {
                        Category category = new Category();
                        category.name = item.name;
                        Product_Category product_Category = new Product_Category()
                        {
                            product = product,
                            category = category
                        };
                        _context.Category.Add(category);
                        _context.product_categories.Add(product_Category);
                    }
                    foreach(var item in productModel.images)
                    {
                        Image image = new Image();
                        image.Url = item.Url;
                        image.product =product;
                        _context.Image.Add(image);
                    }
                    _context.Product.Add(product);
                    await _context.SaveChangesAsync();
                    return Ok(new { product, message = "success" });
                }
                else
                {
                    return BadRequest(new { message = "the product already exist" });
                }
            }
            catch(Exception e)
            {
                return BadRequest(new { message = "check your connection"});
            }
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.Id == id);
        }
    }
}
