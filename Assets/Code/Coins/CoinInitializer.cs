using UnityEngine;
using Game;
using Interfaces.MVC;
using Points;
using Controllers;

namespace Coins
{
    public class CoinInitializer : IGameInitializer
    {

        #region Fields

        private CoinServiceController _coinServiceController;

        #endregion

        #region Constructors

        public CoinInitializer(ControllersList controllersList, CoinCollectionView coinCollectionView, Transform poolTransform, PointsController pointsController, GameRestarter gameRestarter)
        {

            _coinServiceController = new CoinServiceController(coinCollectionView.Coins, coinCollectionView.CoinData, poolTransform, pointsController, gameRestarter);

            controllersList.AddController(_coinServiceController);

        }

        #endregion


    }
}
