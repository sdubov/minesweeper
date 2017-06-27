using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Reflection;

namespace Minesweeper
{
    // TODO: Need to update by using singleton GameSettings object.
    public class Playfield
    {
        // TODO: Need to replase wit values from GameSettings class.
        private static int[,] fieldArray;
        private static Pointer[] bombsArray;

        private static int size;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Playfield(GameSettings settings)
        {
            PlayfieldInitialization(settings);
        }

        /// <summary>
        /// Initial initialization of play field and bombs placement.
        /// </summary>
        /// <param name="settings"></param>
        public static void PlayfieldInitialization(GameSettings settings)
        {
            size = settings.FieldSize;

            fieldArray = new int[size, size];

            // Generating initial play field.
            fieldArray = GenerateInitialFieldArray(size);

            // Generate bombs array.
            Pointer[] bombsArray = BombGeneration(settings.BombsNumber, size);

            // Updating initial field with sets of bombs.
            fieldArray = PopulateBombs(bombsArray);

            // Calculation of play field according to populated bombs.
            fieldArray = CalculateFieldArrayWithBombs(bombsArray);

            // Stop here for now!...
        }

        /// <summary>
        /// Field generation.
        /// </summary>
        /// <param name="size">Size of the field.</param>
        /// <returns>Zero array.</returns>
        public static int[,] GenerateInitialFieldArray(int size)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    fieldArray[i, j] = 0;
                }
            }

            return fieldArray;
        }

        /// <summary>
        /// Random bombs generation on the field array.
        /// </summary>
        /// <param name="bombsNumber">Set number of bombs on the field.</param> // TODO: Need to add Settings support.
        /// <param name="size">Size of the play field. Need for determineing max coordinate of bombs.</param>
        /// <returns></returns>
        public static Pointer[] BombGeneration(int bombsNumber, int size)
        {
            // Variable for check generated bombs number.
            int bombsCount = 0;
            
            // Generating new array containing Pointer objects.
            bombsArray = new Pointer[bombsNumber];

            Random rand = new Random();

            //for (int i = 0; i < bombsNumber; i++)
            while (bombsCount != bombsNumber)
            {
                // Generate random X and Y;
                int generatedX = rand.Next(size);
                int generatedY = rand.Next(size);

                // Flag for determining if current generated points are already exists.
                bool isBombExists = false;

                // Chech if generated bomb's coordinates are already exists. Update isBombExists flag if it was found.
                foreach (Pointer bomb in bombsArray)
                {
                    if (bomb != null)
                    {
                        if ((generatedX == bomb.X) && (generatedY == bomb.Y))
                        {
                            isBombExists = true;
                            break;
                        }
                    }
                    else
                    { 
                        break; // TODO: this should spped up looking through array in theory. 'else' case should be removed if unnecessary. 
                    }
                }

                // Add new bombs coordinates in case bom was not found in existing array.
                if (!isBombExists)
                {
                    bombsArray[bombsCount] = new Pointer(generatedX, generatedY);
                    bombsCount++;
                }
            }
            
            return bombsArray;
        }

        /// <summary>
        /// Populate initial array wiuth bombs coordinates.
        /// </summary>
        /// <param name="bombs">Array with bombs' coordinates.</param>
        /// <returns>Initial array with bombs coordinates.</returns>
        public static int[,] PopulateBombs(Pointer[] bombs)
        {
            foreach (Pointer bomb in bombs)
            {
                fieldArray[bomb.X, bomb.Y] = -1;
            }

            return fieldArray;
        }

        /// <summary>
        /// Method to calculate number for each cell on the playfield according to the bomb's array.
        /// </summary>
        /// <param name="bombs">Array of bomb's coordinates.</param>
        /// <returns>Return initial array of playfield with recalculated cells.</returns>
        public static int[,] CalculateFieldArrayWithBombs(Pointer[] bombs)
        {
            int bombsCounter = 0;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    // Verify if current coordinate is boms and don't calculate value for this field.
                    if (fieldArray[i, j] == -1)
                    {
                        continue;
                    }
                    else
                    {
                        // Initialize max/min X and Y.
                        int minX = (i - 1) < 0 ? 0 : (i - 1);
                        int maxX = (i + 1) > size - 1 ? size - 1 : (i + 1);

                        int minY = (j - 1) < 0 ? 0 : (j - 1);
                        int maxY = (j + 1) > size - 1 ? size - 1 : (j + 1);

                        // Loop for 1-1 area for each cell 
                        // ("1-1" mean that we should look for area from x-1 to x+1 and from y-1 to y+1 for number of bombs calculation for the current cell).
                        for (int areaX = minX; areaX <= maxX; areaX++)
                        {
                            for (int areaY = minY; areaY <= maxY; areaY++)
                            {
                                // If bomb was found increment counter. Result number should be equal to the number of bombs in the area 1-1.
                                if (fieldArray[areaX, areaY] == -1)
                                {
                                    bombsCounter++;
                                }
                            }
                        }

                        fieldArray[i, j] = bombsCounter;
                        bombsCounter = 0;
                    }
                }
            }

            return fieldArray;
        }

        /// <summary>
        /// Method to draw playfield.
        /// </summary>
        /// <param name="g">Graphics object.</param>
        public static void DrawPlayfield(Graphics g)
        {
            // Get closed cell image.
            string imagePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\images\cell_closed.bmp";
            Image imgClosedCell = Image.FromFile(imagePath);

            // Loop for drawing closed cells.
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Point point = new Point(row * 20, col * 20);
                    g.DrawImage(imgClosedCell, point);
                }
            }
        }



        // TESTING to get fieldArray object!!!
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static int[,] GetFieldArray()
        {
            return fieldArray;
        }

        // TESTING to get bombs array!!!
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Pointer[] GetBombsArray()
        {
            return bombsArray; 
        }
    }
}
