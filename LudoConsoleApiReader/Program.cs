using System;
using System.Collections.Generic;
using RestSharp;
using RestSharp.Serialization.Json;

namespace LudoConsoleApiReader
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new RestClient("http://localhost:53546/api/ludo/Game/");
            string nrOfPlayer = "";
            string gameName = "";
            List<string> answer = new List<string>();

            int choice = ReadInt("1: New game?\n2: Load game?");



            if (choice == 1)
            {
                nrOfPlayer = ReadString("How many players?");
                gameName = ReadString("What du you want to call Your game?");
                answer = ApiReader.NewGame(client, nrOfPlayer, gameName);
            }
            else
            {
                answer = ApiReader.ViewSavedGames(client);
                for (int i = 0; i < answer.Count; i++)
                {
                    Console.WriteLine($"{i + 1}: {answer[i]}");
                }



                answer = ApiReader.LoadGame(client, answer[ReadInt("What game do You want to load?") - 1]);
                Console.Clear();

            }

            while (true)
            {
                List<string> games = GameInfo(client);
                for (int i = 0; i < games.Count - 1; i++)
                {
                    Console.WriteLine(games[i]);
                }

                Console.WriteLine($"The dice showed {games[games.Count - 1].Substring(0, games[games.Count - 1].IndexOf(','))}.\nIt is {games[games.Count - 1].Substring(games[games.Count - 1].IndexOf(',') + 1)}'s turn to move.");
                answer = ApiReader.MovePiece(client, ReadString("What piece do You want to move?"));
                Console.Clear();
                Console.WriteLine($"Player {answer[0]}.{answer[1]}.");

                if (ReadString("To save, press y") != "")
                {
                    string save = ApiReader.SaveGame(client);
                    Console.WriteLine(save);
                }

            }

        }

        static int ReadInt(string promt)
        {
            Console.WriteLine(promt);
            return int.Parse(Console.ReadLine());

        }

        static string ReadString(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine();
        }

        static List<string> GameInfo(RestClient url)
        {
            return ApiReader.ShowGameInfo(url);
        }



    }
}
