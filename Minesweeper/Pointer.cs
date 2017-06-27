using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper
{
    public class Pointer : IEquatable<Pointer>
    {
        private int x;
        private int y;

        public int X
        { get; set; }

        public int Y
        { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Pointer()
        { }

        /// <summary>
        /// Custom constructor.
        /// </summary>
        /// <param name="xPoint">X coordinate.</param>
        /// <param name="yPoint">Y coordinate.</param>
        public Pointer(int xPoint, int yPoint)
        {
            this.X = xPoint;
            this.Y = yPoint;
        }

        /// <summary>
        /// Implementation of the Equals method for Pointer objects.
        /// </summary>
        /// <param name="obj">Pointer object.</param>
        /// <returns>Is Pointer objects are equal.</returns>
        public bool Equals(Pointer obj)
        {
            return this.X == obj.X && this.Y == obj.Y;
        }
    }
}
