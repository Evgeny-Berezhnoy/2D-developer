using UnityEngine;
using Constants.LayersLogic;
using Game.Physicals;
using Interfaces;
using Interfaces.Components;
using Interfaces.MVC;
using Interfaces.MVC.UnityEvents;

namespace Torches
{
    public class TorchController : IController, IRestartable, IUpdate, IToggleObject
    {

        #region Fields

        private TorchView _view;
        private TorchAnimator _animator;
        private TriggerContactsPoller2D<BoxCollider2D> _contactsPoller;

        #endregion

        #region Properties

        public TorchAnimator Animator => _animator;

        #endregion

        #region Constructors

        public TorchController(TorchView view)
        {

            _view           = view;
            _animator       = new TorchAnimator(_view.Animator);
            _contactsPoller = new TriggerContactsPoller2D<BoxCollider2D>(_view.Collider, LayerMasks.PLAYER);
            
        }

        #endregion

        #region Interfaces Methods

        public void Restart()
        {

            SwitchOff();

        }

        public void OnUpdate(float deltaTime)
        {

            if (!_view.Collider.enabled) return;

            _contactsPoller.Overlap();

            if (_contactsPoller.HasContacts)
            {

                SwitchOff();

                _animator.Lit();
            
            };

        }

        public void SwitchOff()
        {

            _view.Collider.enabled = false;

        }

        public void SwitchOn()
        {

            _view.Collider.enabled = true;

            _animator.Unlit();
            
        }

        #endregion

    }

}