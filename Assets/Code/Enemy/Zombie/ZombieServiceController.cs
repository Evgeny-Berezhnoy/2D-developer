using System;
using System.Collections.Generic;
using UnityEngine;
using Controllers;
using Interfaces;
using Interfaces.MVC;
using Interfaces.MVC.UnityEvents;

namespace Enemy.Zombie
{

    public class ZombieServiceController : IController, IUpdate, IFixedUpdate, IRestartable, IDisposable
    {

        #region Fields

        private List<ZombieController> _zombieControllers = new List<ZombieController>();

        #endregion

        #region Observers

        private GameRestarter _gameRestarter;

        #endregion

        #region Constructors

        public ZombieServiceController(List<ZombieView> zombieViews, Transform player, GameRestarter gameRestarter)
        {

            for(int i = 0; i < zombieViews.Count; i++)
            {

                _zombieControllers.Add(new ZombieController(zombieViews[i], player));

            };

            _gameRestarter = gameRestarter;
            _gameRestarter.AddHandler(Restart);

        }

        #endregion

        #region Interfaces Methods

        public void OnUpdate(float deltaTime)
        {
            
            for(int i = 0; i < _zombieControllers.Count; i++)
            {

                _zombieControllers[i].OnUpdate(deltaTime);

            };

        }

        public void OnFixedUpdate(float deltaTime)
        {

            for (int i = 0; i < _zombieControllers.Count; i++)
            {

                _zombieControllers[i].OnFixedUpdate(deltaTime);

            };

        }

        public void Restart()
        {

            for (int i = 0; i < _zombieControllers.Count; i++)
            {

                _zombieControllers[i].Restart();

            };

        }

        public void Dispose()
        {

            _gameRestarter.RemoveHandler(Restart);

        }

        #endregion

    }

}