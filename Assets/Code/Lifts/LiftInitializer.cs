using Game;
using Interfaces.MVC;

namespace Lifts
{
    public class LiftInitializer : IGameInitializer
    {

        #region Fields

        private LiftServiceController _liftServiceController;

        #endregion

        #region Constructors

        public LiftInitializer(ControllersList controllersList, LiftCollectionView liftCollectionView)
        {

            _liftServiceController = new LiftServiceController(liftCollectionView.CollectionView);

            controllersList.AddController(_liftServiceController);

        }

        #endregion

    }

}