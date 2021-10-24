using UnityEngine;
using Constants.LayersLogic;
using Game.Physicals;
using Controllers;
using Interfaces.MVC;
using Interfaces.MVC.UnityEvents;

namespace Death
{
    public class DeathZoneController : IController, IFixedUpdate
    {

        #region Fields

        private DeathZoneView _view;
        private TriggerContactsPoller2D<BoxCollider2D> _contactsPoller;

        #endregion

        #region Observers

        private GameRestarter _gameRestarter;

        #endregion

        #region Constructors

        public DeathZoneController(DeathZoneView view, GameRestarter gameRestarter)
        {

            _view           = view;
            _contactsPoller = new TriggerContactsPoller2D<BoxCollider2D>(_view.Collider, LayerMasks.PLAYER);

            _gameRestarter  = gameRestarter;

        }

        #endregion

        #region Interfaces Methods

        public void OnFixedUpdate(float deltaTime)
        {

            if (!_view.gameObject.activeSelf) return;

            _contactsPoller.OnUpdate(deltaTime);

            if (_contactsPoller.HasContacts)
            {

                _gameRestarter.Restart();

            };

        }

        #endregion

    }

}