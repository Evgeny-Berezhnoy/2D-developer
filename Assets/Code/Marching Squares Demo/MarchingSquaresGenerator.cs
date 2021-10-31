using UnityEngine;
using UnityEngine.Tilemaps;

using static Iterators.AdvancedIterators;

namespace MarchingSquaresDemo
{

    public class MarchingSquaresGenerator
    {

        private SquareGrid _squareGrid;
        private Tilemap _tileMap;
        private Tile _tile;

        #region Methods

        public void GenerateGrid(int[,] map, float squareSize)
        {

            _squareGrid = new SquareGrid(map, squareSize);

        }

        public void DrawTilesOnMap(Tilemap tileMap, Tile tile)
        {
            if (_squareGrid == null) return;

            _tileMap    = tileMap;
            _tile       = tile;

            ExecuteGridAction(_squareGrid.Squares.GetLength(0), _squareGrid.Squares.GetLength(1), (x, y) =>
            {

                DrawTileInControlNode(_squareGrid.Squares[x, y].TopLeft);
                DrawTileInControlNode(_squareGrid.Squares[x, y].TopRight);
                DrawTileInControlNode(_squareGrid.Squares[x, y].BottomRight);
                DrawTileInControlNode(_squareGrid.Squares[x, y].BottomLeft);
                
            });

        }

        private void DrawTileInControlNode(ControlNode controlNode)
        {

            var position = controlNode.Position;
            var positionTile = new Vector3Int((int)position.x, (int)position.y, 0);
            
            _tileMap.SetTile(positionTile, controlNode.Active ? _tile : null);
            
        }

        #endregion

    }

}