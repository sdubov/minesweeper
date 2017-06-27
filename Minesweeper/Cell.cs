using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Reflection;

namespace Minesweeper
{
    public class Cell
    {
        /// <summary>
        /// Bool array with flags for opened/closed cessls indcation.
        /// </summary>
        private static bool[,] isOpenedCellsArray;

        /// <summary>
        /// Bool array with flags for seet Flag icons.
        /// </summary>
        private static bool[,] isFlagSetArray;

        /// <summary>
        /// Count of opened cells.
        /// Need to determine if all non-bombs cells were opened to stop the game.
        /// </summary>
        private static int openedCellsCounter;
                
        // TODO: Probably can be removed.
        /// <summary>
        /// Gets opened cells counter value.
        /// </summary>
        public int OpenedCellsCounter
        {
            get
            {
                return openedCellsCounter;
            }
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Cell()
        {
            openedCellsCounter = 0;
            isOpenedCellsArray = GenerateOpenedCellArray();
            isFlagSetArray = new bool[GameSettings.GameSettingsInstance.FieldSize, GameSettings.GameSettingsInstance.FieldSize];
        }

        /// <summary>
        /// Generating array with opened cells.
        /// </summary>
        /// <param name="gameSettings">Game settings.</param>
        /// <returns>Returns the array with opened/closed cells.</returns>
        private static bool[,] GenerateOpenedCellArray()
        {
            // Creating GameSettings object to get field size for creating array.
            GameSettings gameSettings = GameSettings.GameSettingsInstance;
            
            isOpenedCellsArray = new bool[gameSettings.FieldSize, gameSettings.FieldSize];

            // Generate array with default 'false' values.
            for (int row = 0; row < gameSettings.FieldSize; row++)
            {
                for (int col = 0; col < gameSettings.FieldSize; col++)
                {
                    isOpenedCellsArray[row, col] = false;
                }
            }

            return isOpenedCellsArray;
        }

        /// <summary>
        /// Method to open cell.
        /// </summary>
        /// <param name="row">X coordinate.</param>
        /// <param name="col">Y coordinate.</param>
        public static void OpenCell(int row, int col, Graphics g)
        {
            // Creating GameSettings object to get field size.
            GameSettings gameSettings = GameSettings.GameSettingsInstance;

            // Creating Game instance for invoking EndGame method.
            Game game = Game.GameInstance;

            int[,] fieldArray = Playfield.GetFieldArray();

            // Check if bomb is opened. Finish game.
            if (fieldArray[row, col] == -1)
            {
                // END GAME!
                // Stop timer.
                game.EndGame(false);

                // Opening all cells with boombs.
                Pointer[] bombs = Playfield.GetBombsArray();

                foreach (Pointer bomb in bombs)
                {
                    DrawCell(-1, bomb.X, bomb.Y, g);
                }
            }

            // Proceed with opened cell.
            switch (fieldArray[row, col])
            {
                case 0:
                    // case 0 is here.

                    // Check if cell is closed and if flag is not set in the cell.
                    if (!isOpenedCellsArray[row, col] && !isFlagSetArray[row, col])
                    {
                        // Increment number of opened cells.
                        openedCellsCounter++;
                        
                        // Drawing empty cell.
                        DrawCell(0, row, col, g);

                        // Set flag that cell is opened.
                        isOpenedCellsArray[row, col] = true;

                        // TODO: !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                        // Check if all avaliable cells (cells without bombs) were opened. If all cells were opened finish the game.
                        if (openedCellsCounter == (gameSettings.FieldSize * gameSettings.FieldSize - gameSettings.BombsNumber))
                        {
                            // End Game.
                            game.EndGame(true);
                        }

                        // Open recursively all adjacent cells.

                        // v - -
                        // - x -
                        // - - -
                        OpenCell(row - 1 < 0 ? 0 : row - 1, col - 1 < 0 ? 0 : col - 1, g);

                        // - - -
                        // v x -
                        // - - -
                        OpenCell(row, col - 1 < 0 ? 0 : col - 1, g);

                        // - - -
                        // - x -
                        // v - -
                        OpenCell(row + 1 > gameSettings.FieldSize - 1 ? row : row + 1, col - 1 < 0 ? 0 : col - 1, g); // TODO: Need to replace this settings with value from GameSettings

                        // - v -
                        // - x -
                        // - - -
                        OpenCell(row - 1 < 0 ? 0 : row - 1, col, g);

                        // - - -
                        // - x -
                        // - v -
                        OpenCell(row + 1 > gameSettings.FieldSize - 1 ? row : row + 1, col, g);

                        // - - v
                        // - x -
                        // - - -
                        OpenCell(row - 1 < 0 ? 0 : row - 1, col + 1 > gameSettings.FieldSize - 1 ? col : col + 1, g);

                        // - - -
                        // - x v
                        // - - -
                        OpenCell(row, col + 1 > gameSettings.FieldSize - 1 ? col : col + 1, g);

                        // - - -
                        // - x -
                        // - - v
                        OpenCell(row + 1 > gameSettings.FieldSize - 1 ? row : row + 1, col + 1 > gameSettings.FieldSize - 1 ? col : col + 1, g);
                    }

                    break;

                case 1:
                    // case 1 is here.
                    if (!isOpenedCellsArray[row, col] && !isFlagSetArray[row, col])
                    {
                        openedCellsCounter++;

                        // Check if all avaliable cells (cells without bombs) were opened. If all cells were opened finish the game.
                        if (openedCellsCounter == (gameSettings.FieldSize * gameSettings.FieldSize - gameSettings.BombsNumber))
                        {
                            // End Game.
                            game.EndGame(true);
                        }

                        DrawCell(1, row, col, g);

                        // Set flag that cell is opened.
                        isOpenedCellsArray[row, col] = true;
                    }
                    
                    break;

                case 2:
                    // case 2 is here.
                    if (!isOpenedCellsArray[row, col] && !isFlagSetArray[row, col])
                    {
                        openedCellsCounter++;

                        // Check if all avaliable cells (cells without bombs) were opened. If all cells were opened finish the game.
                        if (openedCellsCounter == (gameSettings.FieldSize * gameSettings.FieldSize - gameSettings.BombsNumber))
                        {
                            // End Game.
                            game.EndGame(true);
                        }

                        DrawCell(2, row, col, g);

                        // Set flag that cell is opened.
                        isOpenedCellsArray[row, col] = true;
                    }
                    
                    break;

                case 3:
                    // case 3 is here.
                    if (!isOpenedCellsArray[row, col] && !isFlagSetArray[row, col])
                    {
                        openedCellsCounter++;

                        // Check if all avaliable cells (cells without bombs) were opened. If all cells were opened finish the game.
                        if (openedCellsCounter == (gameSettings.FieldSize * gameSettings.FieldSize - gameSettings.BombsNumber))
                        {
                            // End Game.
                            game.EndGame(true);
                        }

                        DrawCell(3, row, col, g);

                        // Set flag that cell is opened.
                        isOpenedCellsArray[row, col] = true;
                    }
                    
                    break;

                case 4:
                    // case 4 is here.
                    if (!isOpenedCellsArray[row, col] && !isFlagSetArray[row, col])
                    {
                        openedCellsCounter++;

                        // Check if all avaliable cells (cells without bombs) were opened. If all cells were opened finish the game.
                        if (openedCellsCounter == (gameSettings.FieldSize * gameSettings.FieldSize - gameSettings.BombsNumber))
                        {
                            // End Game.
                            game.EndGame(true);
                        }

                        DrawCell(4, row, col, g);

                        // Set flag that cell is opened.
                        isOpenedCellsArray[row, col] = true;
                    }
                    
                    break;

                case 5:
                    // case 5 is here.
                    if (!isOpenedCellsArray[row, col] && !isFlagSetArray[row, col])
                    {
                        openedCellsCounter++;

                        // Check if all avaliable cells (cells without bombs) were opened. If all cells were opened finish the game.
                        if (openedCellsCounter == (gameSettings.FieldSize * gameSettings.FieldSize - gameSettings.BombsNumber))
                        {
                            // End Game.
                            game.EndGame(true);
                        }

                        DrawCell(5, row, col, g);

                        // Set flag that cell is opened.
                        isOpenedCellsArray[row, col] = true;
                    }
                    
                    break;

                case 6:
                    // case 6 is here.
                    if (!isOpenedCellsArray[row, col] && !isFlagSetArray[row, col])
                    {
                        openedCellsCounter++;

                        // Check if all avaliable cells (cells without bombs) were opened. If all cells were opened finish the game.
                        if (openedCellsCounter == (gameSettings.FieldSize * gameSettings.FieldSize - gameSettings.BombsNumber))
                        {
                            // End Game.
                            game.EndGame(true);
                        }

                        DrawCell(6, row, col, g);

                        // Set flag that cell is opened.
                        isOpenedCellsArray[row, col] = true;
                    }

                    break;

                case 7:
                    // case 7 is here.
                    if (!isOpenedCellsArray[row, col] && !isFlagSetArray[row, col])
                    {
                        openedCellsCounter++;

                        // Check if all avaliable cells (cells without bombs) were opened. If all cells were opened finish the game.
                        if (openedCellsCounter == (gameSettings.FieldSize * gameSettings.FieldSize - gameSettings.BombsNumber))
                        {
                            // End Game.
                            game.EndGame(true);
                        }

                        DrawCell(7, row, col, g);

                        // Set flag that cell is opened.
                        isOpenedCellsArray[row, col] = true;
                    }
                    
                    break;

                case 8:
                    // case 8 is here.
                    if (!isOpenedCellsArray[row, col] && !isFlagSetArray[row, col])
                    {
                        openedCellsCounter++;

                        // Check if all avaliable cells (cells without bombs) were opened. If all cells were opened finish the game.
                        if (openedCellsCounter == (gameSettings.FieldSize * gameSettings.FieldSize - gameSettings.BombsNumber))
                        {
                            // End Game.
                            game.EndGame(true);
                        }

                        DrawCell(8, row, col, g);

                        // Set flag that cell is opened.
                        isOpenedCellsArray[row, col] = true;
                    }

                    break;
            }
        }
        
        /// <summary>
        /// Draw a cell.
        /// </summary>
        /// <param name="number">Number to draw in the opened cell.</param>
        /// <param name="row">X coordinate.</param>
        /// <param name="col">Y coordinate.</param>
        /// <param name="g">Graphic object.</param>
        public static void DrawCell(int number, int row, int col, Graphics g)
        {
            // TODO...
            string imagePath = string.Empty;

            switch (number)
            {
                case 0:
                    imagePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\images\cell_open_zero.bmp";
                    break;

                case 1:
                    imagePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\images\cell_open_one.bmp";
                    break;

                case 2:
                    imagePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\images\cell_open_two.bmp";
                    break;

                case 3:
                    imagePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\images\cell_open_three.bmp";
                    break;

                case 4:
                    imagePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\images\cell_open_four.bmp";
                    break;

                case 5:
                    imagePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\images\cell_open_five.bmp";
                    break;

                case 6:
                    imagePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\images\cell_open_six.bmp";
                    break;

                case 7:
                    imagePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\images\cell_open_seven.bmp";
                    break;

                case 8:
                    imagePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\images\cell_open_eight.bmp";
                    break;

                // Should be rewriten to match other checking for END GAME case.
                case -1:
                    imagePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\images\bomb.bmp";
                    break;

                case 9:
                    imagePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\images\cell_closed.bmp";
                    break;

                // Draw flag.
                case 10:
                    imagePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\images\flag.bmp";
                    break;
            }

            Image imgCell = Image.FromFile(imagePath);

            Point point = new Point(row * 20, col * 20);
            g.DrawImage(imgCell, point);
        }

        /// <summary>
        /// Set flag on the playfield.
        /// </summary>
        /// <param name="row">X coordinate.</param>
        /// <param name="col">Y coordinate.</param>
        /// <param name="g">Graphics object.</param>
        public static void SetFlag(int row, int col, Graphics g)
        {
            Game game = Game.GameInstance;

            // Check if flag was not already set in the cell, if cell was not already opented, and if bomb counter is not zero (all bombs are marked/opened).
            // If flag was already set in this cell - reset it from the cell. 
            if (!isFlagSetArray[row, col] && !isOpenedCellsArray[row, col] && Game.GameInstance.BombsCounter != 0)
            {
                // Draw a flag in the cell.
                DrawCell(10, row, col, g);

                // Set flag to true for current coordinate.
                isFlagSetArray[row, col] = true;

                // TODO: Add check if BombsCounter == 0
                // Decrement bombs counter and update number of displayed bombs.
                Game.GameInstance.BombsCounter--;
                game.DisplayBombsNumber();
            }
            else if (isFlagSetArray[row, col])
            {
                // Draw a closed cell.
                DrawCell(9, row, col, g);

                // Set flag to false for current coordinate.
                isFlagSetArray[row, col] = false;

                // Increment bombs counter and update number of displayed bombs.
                Game.GameInstance.BombsCounter++;
                game.DisplayBombsNumber();
            }

            // TODO: DO NOTHING... (remove this comment)
        }

        /// <summary>
        /// Open flag area
        /// </summary>
        /// <param name="row">X coordinate.</param>
        /// <param name="col">Y coordinate.</param>
        /// <param name="g">Graphics object.</param>
        public static void OpenFlagArea(int row, int col, Graphics g)
        {
            GameSettings gameSettings = GameSettings.GameSettingsInstance;

            // Get bombs array.
            Pointer[] bombsArray = Playfield.GetBombsArray();

            // List contains all flags in the area.
            List<Pointer> areaFlagsArray = new List<Pointer>();
            
            // List contains all bombs in the area.
            List<Pointer> areaBombsArray = new List<Pointer>();

            // Loop for calculation flags and bombs number in the area.
            for (int i = row - 1 < 0 ? 0 : row - 1; i <= (row + 1 > gameSettings.FieldSize - 1 ? row : row + 1); i++)
            {
                for (int j = col - 1 < 0 ? 0 : col - 1; j <= (col + 1 > gameSettings.FieldSize - 1 ? col : col + 1); j++)
                {
                    // Processed only with closed cells. 
                    if (!isOpenedCellsArray[i, j])
                    {
                        // Increment flags counter for the current area if flag is set.
                        if (isFlagSetArray[i, j])
                        {
                            areaFlagsArray.Add(new Pointer(i, j));
                        }

                        // Increment bombs counter if bomb coordinate is got in area.
                        foreach (Pointer bomb in bombsArray)
                        {
                            if (i == bomb.X && j == bomb.Y)
                            {
                                areaBombsArray.Add(new Pointer(i, j));
                            }
                        }
                    }
                }
            }

            Pointer currentCellPointer = null;

            // Loop for opening cells in the area.
            if (areaFlagsArray.Count != 0 && areaFlagsArray.Count == areaBombsArray.Count)
            {
                for (int i = row - 1 < 0 ? 0 : row - 1; i <= (row + 1 > gameSettings.FieldSize - 1 ? row : row + 1); i++)
                {
                    for (int j = col - 1 < 0 ? 0 : col - 1; j <= (col + 1 > gameSettings.FieldSize - 1 ? col : col + 1); j++)
                    {
                        currentCellPointer = new Pointer(i, j);

                        // Open cell in case 
                        if (!areaFlagsArray.Contains(currentCellPointer) && !isFlagSetArray[i, j])
                        {
                            OpenCell(i, j, g);
                        }
                    }
                }
            }
        }



        public static bool[,] GetOpenedCellsArray()
        {
            return isOpenedCellsArray;
        }
    }
}
