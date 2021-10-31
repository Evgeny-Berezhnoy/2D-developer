using UnityEngine;
using UnityEngine.Tilemaps;

namespace MarchingSquaresDemo
{

    [RequireComponent(typeof(Tilemap))]
    public class LevelView : MonoBehaviour
    {

        #region Fields

        [Header("Components")]
        [SerializeField] private Tilemap _tileMap;
        [SerializeField] private Tile _tile;

        [Header("Map")]
        [SerializeField] private int _width;
        [SerializeField] private int _height;

        [Header("Generation parameters")]
        [Range(0, 1000f)]
        [SerializeField] private float _seed;
        [Range(0, 8)]
        [SerializeField] private int _neighboursThreshold;
        [Range(0, 10)]
        [SerializeField] private int _factorSmooth;
        [Range(0, 100)]
        [SerializeField] private int _randomFillPercent;

        #endregion

        #region Properties

        public Tilemap TileMap => _tileMap;
        public Tile Tile => _tile;
        public int Width => _width;
        public int Height => _height;
        public float Seed => _seed;
        public int NeighboursThreshold => _neighboursThreshold;
        public int FactorSmooth => _factorSmooth;
        public int RandomFillPercent => _randomFillPercent;

        #endregion

    }

}
