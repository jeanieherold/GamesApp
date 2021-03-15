using System;
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

            return cards;
        }

        //update card visibility
        public void updateVisibilty(string code, List<string> visible)
        {
            var cards = GetCards();

            var query = cards.First(x => x.Code == code);
            query.Visible.Clear();

            foreach (string cls in visible)
            {
                query.Visible.Add(cls);
            }

            //this should prolly go in its own class or method but here for now
            //want to write/update the json player file

            JsonSerializer(cards, JsonFileName);
        }

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

        public object JsonDeserialize(Type dataType, string filePath)
        {
            JObject obj = null;
            JsonSerializer jsonSerializer = new JsonSerializer();
            if(File.Exists(filePath))
            {
                StreamReader sr = new StreamReader(filePath);
                JsonReader jsonReader = new JsonTextReader(sr);
                obj = jsonSerializer.Deserialize(jsonReader) as JObject;
                jsonReader.Close();
                sr.Close();
            }
            return obj.ToObject(dataType);
        }

    }
}
