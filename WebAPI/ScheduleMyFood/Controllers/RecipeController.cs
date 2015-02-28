using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using SharedSchema;

namespace ScheduleMyFood.Controllers
{
    [RoutePrefix("recipes")]
    public class RecipeController : ApiController
    {
        private static readonly List<Recipe> _recipes = new List<Recipe>
            {
                new Recipe() { Name = "Lasagna"},
                new Recipe() { Name = "Croque monsieur"},
                new Recipe() { Name = "WAP"},
                new Recipe() { Name = "Puree"},
                new Recipe() { Name = "Waterzooi"},
                new Recipe() { Name = "Frieten met stoofvlees"},
                new Recipe() { Name = "Tonijn"},
                new Recipe() { Name = "Kabeljouw"},
                new Recipe() { Name = "Rijst"}
            };
        [Route("")]
        public IEnumerable<Recipe> Get()
        {
            return _recipes;
        }
        [Route("{name}")]
        public IHttpActionResult Get(string name)
        {
            var recipe = _recipes.SingleOrDefault(rec => rec.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
            if (recipe == null)
            {
                return NotFound();
            }
            return Ok(recipe);
        }
        //[Authorize]
        [Route("")]
        public IHttpActionResult Post(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                if(_recipes.Any(rec => rec.Name.Equals(recipe.Name, StringComparison.InvariantCultureIgnoreCase)))
                {
                    return BadRequest("a recipe with this name already exists");
                }
                _recipes.Add(recipe);
                return Created("api/recipes/" + recipe.Name, recipe);
            }
            return BadRequest(ModelState);
        }
    }
}
