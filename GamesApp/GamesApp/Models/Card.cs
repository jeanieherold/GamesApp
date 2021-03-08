﻿using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GamesApp.Models
{
    public class Card
    {
        public string Value { get; set; }
        public string Code { get; set; }
        [JsonPropertyName("img")]
        public string Image { get; set; }

        //overriding and making our own toString method - do this for all is good practice
        public override string ToString() => JsonSerializer.Serialize<Card>(this);
      
    }
}
