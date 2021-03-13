using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamesApp.Models;
using GamesApp.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GamesApp.Controllers
{
    //Be sure to add controller to startup under configure services
    //And then add to endpoint in startup under app.UseEndpoints

    //route below is /cards but could also make /foo/[controller] - whatever you want
    [Route("[controller]")]
    [ApiController]
    public class CardsController : Controller
    {
        public CardsController(JsonFileCardService cardService)
        {
            this.CardService = cardService;
        }

        public JsonFileCardService CardService { get; }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Card> Get()
        {
            return CardService.GetCards();
        }

    }
}
