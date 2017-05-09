using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ChessCompetetion.Model;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace ChessCompetetion
{
    public class ReadMyFiles
    {
        public static void CreateMyDatabase()
        {
            using (var context = new ChessContext())
            {
                context.Database.EnsureCreated();

            }
        }
        public List<Player> ReadMyStuff(Stream uploadedFileStream)
        {
            using (var reader = new StreamReader(uploadedFileStream))
            {

                List<Player> listOfPlayer = new List<Player>();
                string titelline = ReadUpperTwoLines(reader);

                while (!reader.EndOfStream)
                {
                    ReadBord(reader);
                    Player player, player2;
                    ReadPlayerName(reader, out player, out player2);

                    string readScoreline = reader.ReadLine();

                    ReadOnlyScore(player, player2, readScoreline);
                    ReadABlankLine(reader);

                    listOfPlayer.Add(player);
                    listOfPlayer.Add(player2);
                }
                return listOfPlayer;

            }
        }

        public void ReadPlayerName(StreamReader reader, out Player player, out Player player2)
        {
            player = new Player();
            string readname1 = reader.ReadLine();    // read name
            player.Name = readname1;

            player2 = new Player();
            string readname2 = reader.ReadLine();    //read name
            player2.Name = readname2;
        }

        private static void ReadBord(StreamReader reader)
        {
            string bordline = reader.ReadLine();    // bordline can be discarded
        }

        private static string ReadUpperTwoLines(StreamReader reader)
        {
            string titelline = reader.ReadLine();   //read title
            reader.ReadLine(); //   reads empty line
            return titelline;
        }

        private static void ReadABlankLine(StreamReader reader)
        {
            string readEmptyLine = reader.ReadLine();
        }

        public void ReadOnlyScore(Player player,Player player2, string readScoreline)
        {
            if (readScoreline.Contains("1/2"))
            {
                double n = 0.5;                       //read score
                player.Score = n;
                player2.Score = n;
            }
            else
            {
                string scorePlayer1 = readScoreline.Substring(0, readScoreline.IndexOf('-'));
                string scorePlayer2 = readScoreline.Substring(readScoreline.IndexOf('-') + 1);
                double n1 = Convert.ToInt64(scorePlayer1);
                double n2 = Convert.ToInt64(scorePlayer2);
                //read score
                player.Score = n1;
                player2.Score = n2;
            }
        }

        public IActionResult ReadNameAndScore(Stream uploadedFileStream)
        {
            CalculatingTotalScore cal = new CalculatingTotalScore();
            cal.AddScore(uploadedFileStream);
          //  ReadMyStuff(uploadedFileStream);
            return new NoContentResult();
        }
    }
}
