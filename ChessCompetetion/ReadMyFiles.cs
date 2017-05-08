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
        public string ReadMyStuff(Stream uploadedFileStream)
        {
            using (var reader = new StreamReader(uploadedFileStream))
            {
                using (var context = new ChessContext())
                {
                    string titelline = reader.ReadLine();   //read title
                    reader.ReadLine(); //   reads empty line

                    while (!reader.EndOfStream)
                    {
                        string bordline = reader.ReadLine();    // bordline can be discarded

                        var player = new Player();
                        string readname1 = reader.ReadLine();    // read name
                        player.Name = readname1;

                        var player2 = new Player();
                        string readname2 = reader.ReadLine();    //read name
                        player2.Name = readname2;

                        string readScoreline = reader.ReadLine();

                        if (readScoreline.Contains("1/2"))
                        {
                            double n = 0.5;                       //read score
                            player.Score = n;
                        }
                        else
                        {
                            string scorePlayer1 = readScoreline.Substring(0, readScoreline.IndexOf('-'));
                            double n2 = Convert.ToInt64(scorePlayer1);                        //read score
                            player.Score = n2;
                        }

                        string readEmptyLine = reader.ReadLine();
                        context.Players.Add(player);
                        context.Players.Add(player2);
                    }
                    context.SaveChanges();
                    return titelline;
                }

            }
        }
        public IActionResult ReadNameAndScore(Stream uploadedFileStream)
        {
            ReadMyStuff(uploadedFileStream);
            return new NoContentResult();
        }
    }
}
