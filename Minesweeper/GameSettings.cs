using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper
{
    public class GameSettings
    {
        private static GameSettings _gameSettings;
        
        private static int difficulty = 0;

        private int fieldSize;
        private int bombsNumber;

        // TODO: Can be removed.
        /// <summary>
        /// Gets field size.
        /// </summary>
        public int FieldSize
        {
            get
            {
                return fieldSize;
            }
        }

        // TODO: Can be removed.
        /// <summary>
        /// Gets bombs number.
        /// </summary>
        public int BombsNumber
        {
            get
            {
                return bombsNumber;
            }
        }

        // TODO: Can be removed.
        /// <summary>
        /// Default constructor.
        /// </summary>
        private GameSettings()
        {
            this.fieldSize = 10;
            this.bombsNumber = 10;
        }

        /// <summary>
        /// Default constructor contains difficulty parameter.
        /// </summary>
        /// <param name="difficulty">Int number determined the game difficulty.</param>
        private GameSettings(int difficulty)
        {
            switch (difficulty)
            {
                case 0:
                    this.fieldSize = 10;
                    this.bombsNumber = 10;
                    break;

                case 1:
                    this.fieldSize = 16;
                    this.bombsNumber = 40;
                    break;

                case 2:
                    this.fieldSize = 22;
                    this.bombsNumber = 99;
                    break;
            }
        }

        /// <summary>
        /// SINGLETON for GameSettings class. NOT COMPLETED
        /// </summary>
        public static GameSettings GameSettingsInstance
        {
            get
            {
                if (_gameSettings == null)
                {
                    _gameSettings = new GameSettings(difficulty);
                }

                return _gameSettings;
            }
        }

        // TODO: Can be removed.
        /// <summary>
        /// Change difficulty.
        /// </summary>
        /// <param name="difficulty">Int32 number that determine difficulty.</param>
        public static void ChangeDifficulty(int difficultyValue)
        {
            _gameSettings = new GameSettings(difficultyValue);
        }
    }
}
