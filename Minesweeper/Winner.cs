using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Minesweeper
{
    public class Winner
    {
        private static string winnersFilePath = "Winners.txt";

        private string name = string.Empty;
        
        private int time = 0;

        public Winner(string name, int time)
        {
            this.name = name;
            this.time = time;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public int Time
        {
            get
            {
                return this.time;
            }
        }

        /// <summary>
        /// Get all Winners from file.
        /// </summary>
        /// <returns>Winners array.</returns>
        public static Winner[] GetWinnersList()
        {
            List<Winner> winnersList = new List<Winner>();

            if (File.Exists(winnersFilePath))
            {
                string winnersString = File.ReadAllText(winnersFilePath);

                string[] winnersArray = winnersString.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string winner in winnersArray)
                {
                    string[] winnerOptions = winner.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    winnersList.Add(new Winner(winnerOptions[0], int.Parse(winnerOptions[1])));
                }
            }

            return winnersList.ToArray<Winner>();
            //return winnersList.OrderBy(i => i.Time).Take(10).ToArray<Winner>();
        }

        /// <summary>
        /// Update winners list with new item.
        /// </summary>
        /// <param name="winner">New Winner object.</param>
        public static void AddWinner(Winner winner)
        {
            File.AppendAllText(winnersFilePath, string.Format("{0}\t{1}{2}", winner.Name, winner.Time, Environment.NewLine));
        }

    }
}
