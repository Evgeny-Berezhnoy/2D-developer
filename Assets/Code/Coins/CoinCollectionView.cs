using System.Collections.Generic;
using UnityEngine;

namespace Coins
{

    public class CoinCollectionView : MonoBehaviour
    {

        #region Fields

        [SerializeField] private List<Transform> _coins;
        [SerializeField] private CoinData _coinData;

        #endregion

        #region Properties

        public List<Transform> Coins => _coins;
        public CoinData CoinData => _coinData;

        #endregion

    }

}