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

        //Going to do a get that results in an action for my beginner level
        //but technically should be a put or post etc
        //[HttpPatch] "[FromBody]" - will learn this a bit later

        //update player
        [Route("update")]  //so this will be at /players/update
        [HttpGet]
        public ActionResult Get(
                [FromQuery] string PlayerId,
                [FromQuery] string UserName,
                [FromQuery] int Score
            )
        {
            PlayerService.AddUpdatePlayer(PlayerId, UserName, Score);
            return Ok(); //return is a 200 ok and hides http from us
        }

        //update score
        [Route("Score")]  //so this will be at /players/score
        [HttpGet]
        public ActionResult Get(
                [FromQuery]  string PlayerId,
                [FromQuery] int Score
            )
        {
            PlayerService.updatePlayerScore(PlayerId, Score);
            return Ok(); //return is a 200 ok and hides http from us
        }

    }
}
