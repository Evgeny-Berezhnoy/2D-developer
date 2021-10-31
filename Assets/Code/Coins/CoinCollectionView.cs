using System.Collections.Generic;
using UnityEngine;

namespace Coins
{

    public class CoinCollectionView : MonoBehaviour
    {

        #region Fields

        [SerializeField] private List<Transform> _transforms;
        [SerializeField] private CoinData _coinData;

        #endregion

        #region Properties

        public List<Transform> Transforms => _transforms;
        public CoinData CoinData => _coinData;
        
        #endregion

    }

}