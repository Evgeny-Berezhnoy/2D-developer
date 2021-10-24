using UnityEngine;
using UnityEngine.Tilemaps;

using Random = System.Random;

using static Iterators.AdvancedIterators;

namespace MarchingSquaresDemo
{
    
    [RequireComponent(typeof(LevelView))]
    public class LevelGenerator : MonoBehaviour
    {

        #region Fields

        [SerializeField] private LevelView _view;
        
        private int[,] _map;
        
        private MarchingSquaresGenerator _marchingSquaresGenerator;
        
        #endregion

        #region Properties

        private int _width => _view.Width;
        private int _height => _view.Height;
        private float _seed => _view.Seed;
        private int _neighboursThreshold => _view.NeighboursThreshold;
        private int _factorSmooth => _view.FactorSmooth;
        private int _randomFillPercent => _view.RandomFillPercent;
        private Tilemap _tileMap => _view.TileMap;
        private Tile _tile => _view.Tile;
        
        #endregion

        #region Unity Events

        public void Awake()
        {

            _view = GetComponent<LevelView>();
            
        }

        #endregion

        #region Methods

        public void GenerateLevel()
        {

            _map = new int[_width, _height];

            RandomFillLevel();

            ExecuteLinearAction(_factorSmooth, (x) => SmoothMap());

            if(_marchingSquaresGenerator == null)
            {
                
                _marchingSquaresGenerator = new MarchingSquaresGenerator();
                
            };

            _marchingSquaresGenerator.GenerateGrid(_map, 0.5f);
            _marchingSquaresGenerator.DrawTilesOnMap(_tileMap, _tile);

        }

        private void RandomFillLevel()
        {

            var pseudoRandom = new Random(_seed.GetHashCode());

            ExecuteGridAction(_width, _height, (x, y) =>
            {

                if (x == 0
                    || y == 0
                    || x == _width - 1
                    || y == _height - 1)
                {
                    
                    _map[x, y] = 1;
                
                }
                else
                {
                    
                    _map[x, y] = (pseudoRandom.Next(0, 100) < _randomFillPercent) ? 1 : 0;

                };

            });

        }

        private void SmoothMap()
        {

            ExecuteGridAction(_width, _height, (x, y) =>
            {

                var neighbourWallTiles = GetSurroundingWallCount(x, y);

                if (neighbourWallTiles > _neighboursThreshold)
                {

                    _map[x, y] = 1;

                }
                else if(neighbourWallTiles < _neighboursThreshold)
                {

                    _map[x, y] = 0;

                };
                
            });
            
        }

        private int GetSurroundingWallCount(int gridX, int gridY)
        {

            var wallCount = 0;

            ExecuteGridAction(gridX - 1, gridX + 2, gridY - 1, gridY + 2, (x, y) =>
            {

                if (x >= 0
                    && y >= 0
                    && x < _width
                    && y < _height)
                {

                    if (x != gridX || y != gridY)
                    {

                        wallCount += _map[x, y];

                    };

                }
                else
                {

                    wallCount++;
                
                };

            });

            return wallCount;

        }

        #endregion

    }

}