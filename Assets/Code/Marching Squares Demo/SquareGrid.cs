using UnityEngine;

using static Iterators.AdvancedIterators;

namespace MarchingSquaresDemo
{

    public class SquareGrid
    {

        #region Fields

        public Square[ , ] Squares;

        #endregion

        #region Constructors

        public SquareGrid(int[,] map, float squareSize)
        {

            var nodeCountX      = map.GetLength(0);
            var nodeCountY      = map.GetLength(1);

            var mapWidth        = nodeCountX * squareSize;
            var mapHeight       = nodeCountY * squareSize;

            var controlNodes    = new ControlNode[nodeCountX, nodeCountY];

            ExecuteGridAction(nodeCountX, nodeCountY, (x, y) =>
            {

                var position        = new Vector3(-mapWidth / 2 + (x + 0.5f) * squareSize, -mapHeight / 2 + (y + 0.5f) * squareSize);
                
                controlNodes[x, y]  = new ControlNode(position, map[x, y] == 1);

            });

            Squares = new Square[nodeCountX - 1, nodeCountY - 1];

            ExecuteGridAction(nodeCountX - 1, nodeCountY - 1, (x, y) =>
            {

                Squares[x, y]       = new Square(controlNodes[x, y + 1], controlNodes[x + 1, y + 1], controlNodes[x + 1, y], controlNodes[x, y]);

            });

        }

        #endregion

    }

}