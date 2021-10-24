using System;
using System.Collections.Generic;
using UnityEngine;
using Controllers;
using ExtensionCompilation;
using Interfaces;
using Interfaces.Components;
using Interfaces.MVC;
using Interfaces.MVC.UnityEvents;
using Points;

using Object = UnityEngine.Object;

namespace Coins
{

    public class CoinServiceController : IController, IRestartable, IUpdate, IToggleObject, IDisposable
    {

        #region Fields

        private List<CoinController> _coinControllers = new List<CoinController>();

        #endregion

        #region Observers

        private GameRestarter _gameRestarter;

        #endregion

        #region Constructors

        public CoinServiceController(List<Transform> transforms, CoinData coinData, Transform poolTransform, PointsController pointsController, GameRestarter gameRestarter)
        {

            for(int i = 0; i < transforms.Count; i++)
            {

                var coin = Object.Instantiate(coinData.Prefab, poolTransform);

                coin.transform.SetPositionAndRotation(transforms[i]);

                if(coin.TryGetComponent<CoinView>(out var coinView))
                {

                    _coinControllers.Add(new CoinController(coinView, pointsController, coinData.Points));

                };

            };

            _gameRestarter = gameRestarter;

            _gameRestarter.AddHandler(Restart);

        }

        #endregion

        #region Interfaces Methods

        public void Restart()
        {
            
            for(int i = 0; i < _coinControllers.Count; i++)
            {

                _coinControllers[i].Restart();

            };

        }

        public void OnUpdate(float deltaTime)
        {
            
            for(int i = 0; i < _coinControllers.Count; i++)
            {

                _coinControllers[i].OnUpdate(deltaTime);

            };

        }

        public void SwitchOff()
        {

            for (int i = 0; i < _coinControllers.Count; i++)
            {

                _coinControllers[i].SwitchOff();

            };

        }

        public void SwitchOn()
        {

            for (int i = 0; i < _coinControllers.Count; i++)
            {

                _coinControllers[i].SwitchOn();

            };

        }

        public void Dispose()
        {

            _gameRestarter.RemoveHandler(Restart);

        }

        #endregion

    }

}