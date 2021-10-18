using System.Collections.Generic;
using Controllers;
using Interfaces.MVC;
using Interfaces.MVC.UnityEvents;

namespace Death
{

    public class DeathZoneServiceController : IController, IFixedUpdate
    {

        #region Fields

        private List<DeathZoneController> _deathZoneControllers = new List<DeathZoneController>();

        #endregion

        #region Constructors

        public DeathZoneServiceController(List<DeathZoneView> deathZoneViews, GameRestarter gameRestarter)
        {

            for (int i = 0; i < deathZoneViews.Count; i++)
            {

                _deathZoneControllers.Add(new DeathZoneController(deathZoneViews[i], gameRestarter));

            };

        }

        #endregion

        #region Interfaces Methods

        public void OnFixedUpdate(float deltaTime)
        {

            for (int i = 0; i < _deathZoneControllers.Count; i++)
            {

                _deathZoneControllers[i].OnFixedUpdate(deltaTime);

            };

        }

        #endregion

    }

}