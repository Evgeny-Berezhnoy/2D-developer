using Game;
using Interfaces.MVC;
using Controllers;

namespace Death
{
    public class DeathZoneInitializer : IGameInitializer
    {

        #region Fields

        private DeathZoneServiceController _deathZoneServiceController;

        #endregion

        #region Constructors

        public DeathZoneInitializer(ControllersList controllersList, DeathZoneCollectionView deathZoneCollectionView, GameRestarter gameRestarter)
        {

            _deathZoneServiceController = new DeathZoneServiceController(deathZoneCollectionView.DeathZones, gameRestarter);

            controllersList.AddController(_deathZoneServiceController);

        }

        #endregion

    }

}
