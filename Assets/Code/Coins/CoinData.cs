using UnityEngine;

namespace Coins
{
    
    [CreateAssetMenu(fileName = "Coin data", menuName = "Scriptable objects/Coin data")]
    public class CoinData : ScriptableObject
    {

        #region Fields

        [SerializeField] private int _points;
        [SerializeField] private GameObject _prefab;

        #endregion

        #region Properties

        public int Points => _points;
        public GameObject Prefab => _prefab;

        #endregion

    }

}