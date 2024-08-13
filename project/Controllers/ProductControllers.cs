using Microsoft.AspNetCore.Mvc;
using project.Data;
using project.DTOs;
using project.Models;

namespace project.Controllers
{
    [Route("api/v1/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GETTest
        [HttpGet]
        [Route("gettest")]
        public IActionResult GetTest()
        {
            return Ok("Hi Safaa");
        }
  

        // Get
        [HttpGet]
        [Route("getallproduct")]
        public IActionResult GetAllProduct()
        {
            var AllProduct = _context.Products.ToList();
            if (AllProduct == null)
            {
                return NotFound("No User Founded !");
            }
            return Ok(AllProduct);
        }




        // GetById
        [HttpGet]
        [Route("getproductbyid")]
        public IActionResult GetpProductById([FromQuery] int id)
        {
            var product = _context.Products.FirstOrDefault(el => el.Id == id);
            if (product == null)
            {
                return NotFound("Product No Founded !");
            }
            return Ok(product);
        }





        // post
        [HttpPost]
        [Route("addproduct")]
        public IActionResult AddProducts([FromBody] ProductDTO productDTO)
        {
            var product = new Product
            {
                Name = productDTO.Name,
                Price = productDTO.Price,
                Description = productDTO.Description,
                Photo = productDTO.Photo,
                CategorieId = productDTO.CategorieId,


            };
            _context.Products.Add(product);
            _context.SaveChanges();
            var result = new
            {
                Message = "User Created Succesfully !",
                Product = product,
            };
            return Ok(result);
        }
        // delete
        [HttpDelete]
        [Route("deleteproduct")]
        public IActionResult DeleteProduct(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid product ID.");
            }
            var product = _context.Products.FirstOrDefault(el => el.Id == id);
            if (product == null)
            {
                return NotFound("Product with the given ID does not exist.");
            }
            _context.Products.Remove(product);
            _context.SaveChanges();
            var result = new
            {
                Message = "Product Deleted Succesfully",
                Product = product,
            };
            return Ok(result);
        }




        // put
        [HttpPut]
        [Route("upateproduct")]
        public IActionResult UpateProduct(int id, ProductDTO productDTO)
        {
            var product = _context.Users.FirstOrDefault(el => el.Id == id);

            productDTO.Name = productDTO.Name;
            productDTO.Price = productDTO.Price;
            productDTO.Description = productDTO.Description;
            productDTO.Photo = productDTO.Photo;
            productDTO.CategorieId = productDTO.CategorieId;

            _context.Users.Update(product);
            _context.SaveChanges();
            var result = new
            {
                Message = "User Update Succesfully !",
                Users = product,
            };
            return Ok(result);

        }
    }
}
