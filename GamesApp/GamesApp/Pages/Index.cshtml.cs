using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using GamesApp.Models;

namespace GamesApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        //use properties when you want to pass data
        //this can be read by the index page for display using @Model
        //use [BindProperty] to make writeable.
        //to be able to put the value in the url on submit need to add supportsGet = true)
        [BindProperty(SupportsGet = true)]
        public string UserName { get; set; }

        //properties
        [BindProperty]
        public PlayerModel Player { get; set; }

        //dont pass data directly using get or post - use properties as above
        //get - when you want to show the page but not post anything to it
        public void OnGet()
        {
            //change the following to get username from the api
            if (string.IsNullOrWhiteSpace(UserName))
            {
                UserName = "Gamer!";
            }
        }

        //typical output from a post - action when a form is submitted
        public IActionResult OnPost()
        {
            //some validation
            if (ModelState.IsValid == false)
            {
                return Page();
            }
            else
            {
                //save model to database here!
                //give to a class library and have it save to an api

                //going to pass page using specified route obj (pass anonymous obj)
                return RedirectToPage("/Games/Memory", new { UserName = Player.UserName });
            }
        }
    }
}
