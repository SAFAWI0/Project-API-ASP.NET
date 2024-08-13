using Microsoft.AspNetCore.Mvc;
using project.Data;
using project.DTOs;
using project.Models;


namespace project.Controllers
{
    [Route("api/v1/categori")]
    [ApiController]
    public class CategoriControllers : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoriControllers(ApplicationDbContext context)
        {
            _context = context;
        }


        // GetTest
        [HttpGet]
        [Route("gettest")]
        public IActionResult GetTest()
        {
            return Ok("Hi Safaa");
        }




        // Get
        [HttpGet]
        [Route("getallcategori")]
        public IActionResult GetAllCategori()
        {
            var AllCategori = _context.Categorias.ToList();
            if (AllCategori == null)
            {
                return NotFound("No Categori Founded !");
            }
            return Ok(AllCategori);
        }


        // GetById
        [HttpGet]
        [Route("getcategoribyid")]
        public IActionResult GetCategoriById([FromQuery] int id)
        {
            var categori = _context.Categorias.FirstOrDefault(el => el.Id == id);
            if (categori == null)
            {
                return NotFound("Categori No Founded !");
            }
            return Ok(categori);
        }



        // post
        [HttpPost]
        [Route("addcategori")]
        public IActionResult AddCategori([FromBody] CatgorieDTO catgorieDTO )
        {
            var categori = new Categorie
            {
                Name = catgorieDTO.Name,
                Description = catgorieDTO.Description,
              
            };
            _context.Categorias.Add(categori);
            _context.SaveChanges();
            var result = new
            {
                Message = "Categori Created Succesfully !",
                Categori = categori,
            };
            return Ok(result);
        }




        // delete
        [HttpDelete]
        [Route("deletecategori")]
        public IActionResult DeleteCategori(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid categori ID.");
            }
            var categori = _context.Categorias.FirstOrDefault(el => el.Id == id);
            if (categori == null)
            {
                return NotFound("Categori with the given ID does not exist.");
            }
            _context.Categorias.Remove(categori);
            _context.SaveChanges();
            var result = new
            {
                Message = "Categori Deleted Succesfully",
                Categori = categori,
            };
            return Ok(result);
        }




        // put
        [HttpPut]
        [Route("upatecategori")]
        public IActionResult UpateCategori(int id, CatgorieDTO catgorieDTO)
        {
            var categori = _context.Categorias.FirstOrDefault(el => el.Id == id);

            categori.Name = catgorieDTO.Name;
            categori.Description = catgorieDTO.Description;
          

            _context.Categorias.Update(categori);
            _context.SaveChanges();
            var result = new
            {
                Message = "Categori Update Succesfully !",
                Categori = categori,
            };
            return Ok(result);
        }
    }
}
