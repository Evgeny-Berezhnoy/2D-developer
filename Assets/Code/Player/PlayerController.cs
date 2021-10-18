using UnityEngine;
using Controllers;
using Interfaces.MVC;
using Interfaces.MVC.UnityEvents;

namespace Player
{

    public class PlayerController : IController, IUpdate, IFixedUpdate
    {

        #region Fields

        private PlayerAnimator _playerAnimator;
        private PlayerMoveRigidbodyController _playerMoveController;

        #endregion

        #region Constructors

        public PlayerController(Transform playerTransform, PlayerView playerView, GameRestarter gameRestarter, InputController inputController)
        {

            _playerAnimator         = new PlayerAnimator(playerView.Animator, gameRestarter);
            _playerMoveController   = new PlayerMoveRigidbodyController(playerTransform, playerView, gameRestarter, _playerAnimator, inputController);

        }

        #endregion

        #region Interfaces Methods

        public void OnUpdate(float deltaTime)
        {

            _playerMoveController.OnUpdate(deltaTime);
            
        }

        public void OnFixedUpdate(float deltaTime)
        {

            _playerMoveController.OnFixedUpdate(deltaTime);

        }

        #endregion

    }

}