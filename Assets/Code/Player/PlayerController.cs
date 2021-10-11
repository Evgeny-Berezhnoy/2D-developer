using Controllers;
using Interfaces.MVC;
using Interfaces.MVC.UnityEvents;

namespace Player
{

    public class PlayerController : IController, IUpdate
    {

        #region Fields

        private PlayerAnimator _playerAnimator;
        private PlayerMoveController _playerMoveController;

        #endregion

        #region Constructors

        public PlayerController(PlayerView playerView, InputController inputController)
        {

            _playerAnimator         = new PlayerAnimator(playerView.Animator);
            _playerMoveController   = new PlayerMoveController(playerView, _playerAnimator, inputController);

        }

        #endregion

        #region Interfaces Methods

        public void OnUpdate(float deltaTime)
        {

            _playerMoveController.OnUpdate(deltaTime);

        }

        #endregion

    }

}