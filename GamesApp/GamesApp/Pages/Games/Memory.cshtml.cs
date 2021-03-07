using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GamesApp.Models;

namespace GamesApp.Pages.Games
{
    public class MemoryModel : PageModel
    {
        //properties
        [BindProperty(SupportsGet = true)]
        public string UserName { get; set; }

        [BindProperty]
        public PlayerModel Player { get; set; }

        //get post
        public void OnGet()
        {
            //change the following to get username from the api
            if (string.IsNullOrWhiteSpace(UserName))
            {
                UserName = "Gamer!";
            }
        }


    }
}
