using Controllers;
using Game;
using Interfaces.MVC;

namespace Points
{
    public class PointsInitializer : IGameInitializer
    {

        #region Fields

        private PointsController _pointsController;

        #endregion

        #region Properties

        public PointsController PointsController => _pointsController;

        #endregion

        #region Constructors

        public PointsInitializer(ControllersList controllersList, PointsView pointsView, GameRestarter gameRestarter)
        {

            _pointsController = new PointsController(pointsView, gameRestarter);

            controllersList.AddController(_pointsController);

        }

        #endregion

    }

}
