﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GamesApp.Models
{
    public class Card
    {
        public string Value { get; set; }
        public string Code { get; set; }

        [JsonPropertyName("BackImage")]
        public string BackImage { get; set; }

        [JsonPropertyName("FrontImage")]
        public string FrontImage { get; set; }
        public int Order { get; set; }

        public List<string> Visible { get; set; }
        public List<string> Clickable { get; set; }

        public bool Matched { get; set; }

        //overriding and making our own toString method - do this for all is good practice
        public override string ToString() => JsonSerializer.Serialize<Card>(this);
      
    }
}
