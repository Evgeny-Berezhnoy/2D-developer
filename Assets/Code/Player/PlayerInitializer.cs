using UnityEngine;
using Controllers;
using Game;
using Interfaces.MVC;

namespace Player
{
    public class PlayerInitializer : IGameInitializer
    {

        #region Fields

        private InputController _inputController;
        private PlayerController _playerController;

        #endregion

        #region Properties

        public PlayerController PlayerController => _playerController;

        #endregion

        #region Constructors

        public PlayerInitializer(ControllersList controllersList, Transform playerTransform, PlayerView playerView, GameRestarter gameRestarter)
        {

            _inputController    = new InputController();
            _playerController   = new PlayerController(playerTransform, playerView, gameRestarter, _inputController);

            controllersList.AddController(_inputController);
            controllersList.AddController(_playerController);

        }

        #endregion

    }

}