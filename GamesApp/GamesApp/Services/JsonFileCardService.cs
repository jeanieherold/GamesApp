﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.Json;
using GamesApp.Models;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace GamesApp.Services
{
    public class JsonFileCardService
    {
        public JsonFileCardService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "beginnercardset.json"); }
        }

        //using IEnumerable so I can loop over 
        public IEnumerable<Card> GetCards()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonConvert.DeserializeObject<Card[]>(File.ReadAllText(JsonFileName));
            }

        }

        //update card.Order
        public IEnumerable<Card> updateCardOrder()
        {
            var cards = GetCards();

            var random = new Random();

            foreach (var card in cards)
            {
                card.Order = random.Next(100);
            }

            JsonSerializer(cards, JsonFileName);

            return cards;
        }

        //update card visibility in database
        public void updateVisibilty(string code, List<string> visible)
        {
            var cards = GetCards();

            var query = cards.First(x => x.Code == code);
            query.Visible.Clear();

            foreach (string cls in visible)
            {
                query.Visible.Add(cls);
            }

            JsonSerializer(cards, JsonFileName);
        }

        //update card clickable in database
        public void updateClickable(string code, List<string> clickable)
        {
            var cards = GetCards();

            var query = cards.First(x => x.Code == code);
            query.Clickable.Clear();

            foreach (string cls in clickable)
            {
                query.Clickable.Add(cls);
            }

            JsonSerializer(cards, JsonFileName);
        }

        //serializer
        public void JsonSerializer(object data, string filePath)
        {
            JsonSerializer jsonSerializer = new JsonSerializer();
            if (File.Exists(filePath)) File.Delete(filePath);
            StreamWriter sw = new StreamWriter(filePath);
            JsonWriter jsonWriter = new JsonTextWriter(sw);

            jsonSerializer.Serialize(jsonWriter, data);

            jsonWriter.Close();
            sw.Close();

        }

    }
}
