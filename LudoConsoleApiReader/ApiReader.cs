using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;
using RestSharp.Serialization.Json;
using Newtonsoft.Json;

namespace LudoConsoleApiReader
{
    static public class ApiReader
    {

        public static List<string> NewGame(RestClient url, string numberOfPlayers, string gameName)
        {
            var jsonDeserializer = new JsonDeserializer();


            var request = new RestRequest("creategame/", Method.POST);
            request.RequestFormat = DataFormat.Json;
            url.AddHandler("application/json", jsonDeserializer);
            request.AddJsonBody(new string[] { numberOfPlayers, gameName, "1" });
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            var response = url.Execute(request);
            string answer = response.Content;

            var answerArray = JsonConvert.DeserializeObject<List<string>>(answer);

            return answerArray;

        }

        public static List<string> ViewSavedGames(RestClient url)
        {
            var jsonDeserializer = new JsonDeserializer();


            var request = new RestRequest("games/", Method.GET);
            request.RequestFormat = DataFormat.Json;
            url.AddHandler("application/json", jsonDeserializer);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            var response = url.Execute(request);
            string answer = response.Content;

            var answerList = JsonConvert.DeserializeObject<List<string>>(answer);

            return answerList;

        }

        public static List<string> MovePiece(RestClient url, string PieceNr)
        {
            var jsonDeserializer = new JsonDeserializer();


            var request = new RestRequest("updatepieceposition/" + PieceNr, Method.PUT);
            request.RequestFormat = DataFormat.Json;
            url.AddHandler("application/json", jsonDeserializer);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            var response = url.Execute(request);
            string answer = response.Content;

            var answerList = JsonConvert.DeserializeObject<List<string>>(answer);

            return answerList;

        }

        public static string SaveGame(RestClient url)
        {
            var jsonDeserializer = new JsonDeserializer();


            var request = new RestRequest("savegame/", Method.POST);
            request.RequestFormat = DataFormat.Json;
            url.AddHandler("application/json", jsonDeserializer);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            var response = url.Execute(request);
            string answer = response.Content;

            var answerList = JsonConvert.DeserializeObject<string>(answer);

            return answerList;
        }

        public static List<string> LoadGame(RestClient url, string gameName)
        {
            var jsonDeserializer = new JsonDeserializer();


            var request = new RestRequest("loadgame/"+gameName, Method.POST);
            request.RequestFormat = DataFormat.Json;
            url.AddHandler("application/json", jsonDeserializer);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            var response = url.Execute(request);
            string answer = response.Content;

            var answerList = JsonConvert.DeserializeObject<List<string>>(answer);

            return answerList;

        }

        public static List<string> ShowGameInfo(RestClient url)
        {
            var jsonDeserializer = new JsonDeserializer();


            var request = new RestRequest("gameinfo/", Method.GET);
            request.RequestFormat = DataFormat.Json;
            url.AddHandler("application/json", jsonDeserializer);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            var response = url.Execute(request);
            string answer = response.Content;

            var answerList = JsonConvert.DeserializeObject<List<string>>(answer);

            return answerList;
        }
    }
}
