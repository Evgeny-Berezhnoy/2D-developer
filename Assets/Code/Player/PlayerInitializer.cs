using Controllers;
using Game;
using Interfaces.MVC;

namespace Player
{
    public class PlayerInitializer : IGameInitializer
    {

        #region Fields

        private PlayerController _playerController;

        #endregion

        #region Properties

        public PlayerController PlayerController => _playerController;

        #endregion

        #region Constructors

        public PlayerInitializer(ControllersList controllersList, PlayerView playerView)
        {

            var inputController = new InputController();

            var playerController = new PlayerController(playerView, inputController);

            controllersList.AddController(inputController);
            controllersList.AddController(playerController);

        }

        #endregion

    }

}