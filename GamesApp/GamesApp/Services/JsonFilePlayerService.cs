using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.Json;
using GamesApp.Models;
using Microsoft.AspNetCore.Hosting;

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
                return JsonSerializer.Deserialize<Player[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }

        //add players
        public void updatePlayer(string playerId, string username, int score)
        {
            var players = GetPlayers();

            var query = players.First(x => x.Id == playerId);

            if (query.UserName == null)
            {
                query.UserName = username;
                query.Score = score;
            }
            else
            {
                query.Score = score;
            }

            //this should prolly go in its own class or method but here for now
            //want to write/update the json player file

            using (var outputStream = File.OpenWrite(JsonFileName))
            {
                JsonSerializer.Serialize<IEnumerable<Player>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {
                        SkipValidation = true,
                        Indented = true
                    }),
                    players
                );
            }
        }

        //update player score
        public void updatePlayerScore(string playerId, int score)
        {
            var players = GetPlayers();

            var query = players.First(x => x.Id == playerId);

            if (query.Id == null)
            {
                query.Score = score;
            }
            else
            {
                query.Score = score;
            }

            //this should prolly go in its own class or method but here for now
            //want to write/update the json player file

            using (var outputStream = File.OpenWrite(JsonFileName))
            {
                JsonSerializer.Serialize<IEnumerable<Player>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {
                        SkipValidation = true,
                        Indented = true
                    }),
                    players
                );
            }
        }

    }
}
