using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GamesApp.Models
{
    public class Player
    {
        //properties
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public int Score { get; set; }

        //overriding and making our own toString method - do this for all is good practice
        public override string ToString() => JsonSerializer.Serialize<Player>(this);
    }

}
