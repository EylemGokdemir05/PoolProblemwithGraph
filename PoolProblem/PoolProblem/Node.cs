using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoolProblem
{
    public class Node
    {
        public string nodeName { get; set; }
        public int coordX { get; set; }
        public int coordY { get; set; }

        public Node(string nodeName, int coordX, int coordY)
        {
            this.nodeName = nodeName;
            this.coordX = coordX;
            this.coordY = coordY;
        }
    }
}