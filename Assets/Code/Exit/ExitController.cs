using System;
using UnityEngine;
using Controllers;
using Constants.LayersLogic;
using Game.Physicals;
using Interfaces;
using Interfaces.Components;
using Interfaces.MVC;
using Interfaces.MVC.UnityEvents;

namespace Exit
{
    public class ExitController : IController, IUpdate, IToggleObject
    {

        #region Fields

        private ExitView _view;
        private TriggerContactsPoller2D<BoxCollider2D> _contactsPoller;

        #endregion

        #region Observers

        private GameRestarter _gameRestarter;

        #endregion

        #region Constructors

        public ExitController(ExitView coinView, GameRestarter gameRestarter)
        {

            _view = coinView;
            _contactsPoller = new TriggerContactsPoller2D<BoxCollider2D>(_view.Collider, LayerMasks.PLAYER);

            _gameRestarter = gameRestarter;
            
        }

        #endregion

        #region Interfaces Methods

        public void OnUpdate(float deltaTime)
        {

            if (!_view.gameObject.activeSelf) return;

            _contactsPoller.Overlap();

            if (_contactsPoller.HasContacts)
            {

                _gameRestarter.Restart();

            };

        }

        public void SwitchOff()
        {

            _view.gameObject.SetActive(false);
            _view.Collider.enabled = false;

        }

        public void SwitchOn()
        {

            _view.gameObject.SetActive(true);
            _view.Collider.enabled = true;

        }

        #endregion

    }

}