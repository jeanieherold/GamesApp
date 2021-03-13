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

    //route below is /players but could also make /foo/[controller] - whatever you want
    [Route("[controller]")]
    [ApiController]
    public class PlayersController : Controller
    {
        public PlayersController(JsonFilePlayerService playerService)
        {
            this.PlayerService = playerService;
        }

        public JsonFilePlayerService PlayerService { get; }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Player> Get()
        {
            return PlayerService.GetPlayers();
        }

    }
}
