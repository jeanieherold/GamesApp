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
    public class JsonFilePlayerService
    {
        public JsonFilePlayerService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "players.json"); }
        }

        //using IEnumerable so I can loop over 
        public IEnumerable<Player> GetPlayers()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonConvert.DeserializeObject<Player[]>(File.ReadAllText(JsonFileName));
            }
        }

        //add players
        public void AddUpdatePlayerName(string playerId, string username)
        {
            var players = GetPlayers();

            var query = players.First(x => x.Id == playerId);

            if (username == null)
            {
                query.UserName = "Player One";
            }
            else
            {
                query.Id = playerId;
                query.UserName = username;
            }

            JsonSerializer(players, JsonFileName);
        }

        //update player score
        public void updatePlayerScore(string playerId, int pointsEarned)
        {
            var players = GetPlayers();

            var query = players.First(x => x.Id == playerId);

            if (pointsEarned == -1)
            {
                query.Score = 0;
            } else
            {
                query.Score += pointsEarned;
            }

            JsonSerializer(players, JsonFileName);

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

    }
}
