using ChessCompetetion.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ChessCompetetion
{
    public class CalculatingTotalScore
    {
        public List<Player> AddScore(Stream stream)
        {
            
            ReadMyFiles read = new ReadMyFiles();
            List<Player> listOfPlayerOfCurrentweek = read.ReadMyStuff(stream);
            
            foreach (var currentPlayer in listOfPlayerOfCurrentweek)
            {
                //regelvancurrentstand = naam van currentplayer zoeken in curent stand
                // score van current palyer toevoegen in score van regelvancurrentstand
                var context = new ChessContext();
                var regelvancurrentstand = (from p in context.Players
                                            where p.Name == currentPlayer.Name
                                            select p).FirstOrDefault();

                if (regelvancurrentstand == null)
                {
                    var newPlayer = currentPlayer;
                    context.AddRange(newPlayer);
                }
                else
                {
                    regelvancurrentstand.Score += currentPlayer.Score;
                }
                context.SaveChanges();
            }
            return listOfPlayerOfCurrentweek;
        }
    }
}
