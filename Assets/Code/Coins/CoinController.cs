using UnityEngine;
using Constants.LayersLogic;
using Game.Physicals;
using Interfaces;
using Interfaces.Components;
using Interfaces.MVC;
using Interfaces.MVC.UnityEvents;
using Points;

namespace Coins
{
    public class CoinController : IController, IUpdate, IToggleObject
    {

        #region Fields

        private int _points;

        private CoinView _view;
        private TriggerContactsPoller2D<CircleCollider2D> _contactsPoller;
        private PointsController _pointsController;

        #endregion

        #region Constructors

        public CoinController(CoinView coinView, PointsController pointsController, int points)
        {

            _points             = points;

            _view               = coinView;
            _contactsPoller     = new TriggerContactsPoller2D<CircleCollider2D>(_view.Collider, LayerMasks.PLAYER);
            _pointsController   = pointsController;

        }

        #endregion

        #region Interfaces Methods

        public void OnUpdate(float deltaTime)
        {

            if (!_view.gameObject.activeSelf) return;

            _contactsPoller.Overlap();

            if (_contactsPoller.HasContacts)
            {

                _pointsController.AddPoints(_points);

                SwitchOff();

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