using UnityEngine;
using Game;
using Interfaces.MVC;
using Points;

namespace Coins
{
    public class CoinInitializer : IGameInitializer
    {

        #region Fields

        private CoinServiceController _serviceController;

        #endregion

        #region Properties

        public CoinServiceController ServiceController => _serviceController;

        #endregion

        #region Constructors

        public CoinInitializer(ControllersList controllersList, CoinCollectionView coinCollectionView, Transform poolTransform, PointsController pointsController)
        {

            _serviceController = new CoinServiceController(coinCollectionView.Transforms, coinCollectionView.CoinData, poolTransform, pointsController);

            controllersList.AddController(_serviceController);

        }

        #endregion


    }

}