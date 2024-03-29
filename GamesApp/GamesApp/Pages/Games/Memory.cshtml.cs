﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using GamesApp.Models;
using GamesApp.Services;

namespace GamesApp.Pages.Games
{
    public class MemoryModel : PageModel
    {
        private readonly ILogger<MemoryModel> _logger;

        public JsonFileCardService CardService;
        public IEnumerable<Card> Cards { get; private set; } //only this class can set the cards

        //Add all the services I need onn the page here
        public MemoryModel(ILogger<MemoryModel> logger, JsonFileCardService cardService)
        {
            _logger = logger;
            CardService = cardService;
        }

        //properties
        [BindProperty(SupportsGet = true)]
        public string UserName { get; set; }

        [BindProperty]
        public Player Player { get; set; }

        [BindProperty]
        public int Score { get; set; }

        // get/post
        public void OnGet()
        {
            //change the following to get username from the api
            if (string.IsNullOrWhiteSpace(UserName))
            {
                UserName = "You";
            }

        }


    }
}
