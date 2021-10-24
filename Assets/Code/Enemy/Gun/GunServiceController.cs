using System;
using System.Collections.Generic;
using UnityEngine;
using Bullet;
using Controllers;
using Interfaces;
using Interfaces.MVC;
using Interfaces.MVC.UnityEvents;

namespace Enemy.Gun
{
    public class GunServiceController : IController, IRestartable, IUpdate, IFixedUpdate, IDisposable
    {

        #region Fields

        private List<GunView> _gunViews;
        private List<GunController> _gunControllers = new List<GunController>();

        #endregion

        #region Observers

        private GameRestarter _gameRestarter;

        #endregion

        #region Constructors

        public GunServiceController(List<GunView> gunViews, BulletData bulletData, Transform playerTransform, Transform poolTransform, GameRestarter gameRestarter)
        {

            _gunViews = gunViews;

            for(int i = 0; i < _gunViews.Count; i++)
            {

                _gunControllers.Add(new GunController(_gunViews[i], bulletData, playerTransform, poolTransform));

            };

            _gameRestarter = gameRestarter;

            _gameRestarter.AddHandler(Restart);

            Restart();

        }

        #endregion

        #region Interfaces Methods

        public void Restart()
        {
            
            for(int i = 0; i < _gunControllers.Count; i++)
            {

                _gunControllers[i].Restart();

            };

        }

        public void OnUpdate(float deltaTime)
        {

            for(int i = 0; i < _gunControllers.Count; i++)
            {

                _gunControllers[i].OnUpdate(deltaTime);

            };

        }

        public void OnFixedUpdate(float deltaTime)
        {

            for (int i = 0; i < _gunControllers.Count; i++)
            {

                _gunControllers[i].OnFixedUpdate(deltaTime);

            };

        }

        public void Dispose()
        {

            _gameRestarter.RemoveHandler(Restart);

        }

        #endregion

    }

}