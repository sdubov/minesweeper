using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Minesweeper
{
    public class Game
    {
        private int bombsCounter = GameSettings.GameSettingsInstance.BombsNumber;

        private string timerValue;
        
        /// <summary>
        /// Game Instance.
        /// </summary>
        private static Game _game;

        /// <summary>
        /// Delegate for Game class.
        /// </summary>
        public Action TimerStopDelegate;

        public Action UpdateBombsNumberDelegate;

        /// <summary>
        /// Default protected constructor.
        /// </summary>
        private Game()
        { }

        /// <summary>
        /// Gets or sets bombs counter value.
        /// </summary>
        public int BombsCounter
        {
            get
            {
                return bombsCounter;
            }
            set
            {
                bombsCounter = value;
            }
        }

        /// <summary>
        /// Gets or sets timer value. 
        /// </summary>
        public string TimerValue
        {
            get
            {
                return timerValue;
            }

            set
            {
                timerValue = value;
            }
        }
        
        /// <summary>
        /// Start game method.
        /// </summary>
        public void StartGame(Graphics g)
        {
            Cell cell = new Cell(); // TODO: Probably need to move it somewhere. 
                                    // It is placed here because not clear where we should create an array with opened cells.
            
            // Inicialization of game settings and re-creation of Playfield arrays.
            GameSettings gameSettings = GameSettings.GameSettingsInstance;
            Playfield field = new Playfield(gameSettings);

            // Drawing playfield.
            Playfield.DrawPlayfield(g);

            // Reset all variables.

        }

        /// <summary>
        /// End game method.
        /// </summary>
        public void EndGame(bool isWin)
        {
            // Stop the timer.
            if (TimerStopDelegate != null)
            {
                TimerStopDelegate();
            }

            // Invoke winners table if all mines were opened.
            if (isWin)
            {
                // TODO: !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                Winners winnersForm = new Winners();
                winnersForm.Show();
                winnersForm.UpdateWinnersTable();
            }
        }

        /// <summary>
        /// TODO:
        /// </summary>
        public void DisplayBombsNumber()
        {
            if (UpdateBombsNumberDelegate != null)
            {
                UpdateBombsNumberDelegate();
            }
        }

        // Public property to get Game instance.
        public static Game GameInstance
        {
            get
            {
                if (_game == null)
                {
                    _game = new Game();
                }

                return _game;
            }
        }
    }
}
