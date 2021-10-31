using System;
using UnityEngine;
using Controllers;
using Interfaces;
using Interfaces.MVC;
using Interfaces.MVC.UnityEvents;

namespace Enemy.Zombie
{

    public class ZombieController : IController, IRestartable, IUpdate, IFixedUpdate
    {

        #region Fields

        private ZombieAnimator _animator;
        private ZombieMoveController _moveController;

        #endregion

        #region Constructors

        public ZombieController(ZombieView view, Transform player)
        {

            _animator       = new ZombieAnimator(view.Animator);
            _moveController = new ZombieMoveController(view, _animator, player);

        }

        #endregion

        #region Interfaces Methods

        public void Restart()
        {

            _animator.Restart();
            _moveController.Restart();

        }

        public void OnUpdate(float deltaTime)
        {

            _moveController.OnUpdate(deltaTime);

        }

        public void OnFixedUpdate(float deltaTime)
        {

            _moveController.OnFixedUpdate(deltaTime);

        }

        #endregion

    }

}