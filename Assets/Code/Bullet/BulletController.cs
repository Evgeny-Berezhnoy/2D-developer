using UnityEngine;
using ExtensionCompilation;
using Interfaces.Components;
using Interfaces;
using Interfaces.MVC;
using Interfaces.MVC.UnityEvents;

namespace Bullet
{

    public class BulletController : IController, IRestartable, IUpdate, IToggleObject
    {

        #region Fields

        private float _lifeTime;
        private float _lifeTimeCurrent;

        private Vector2 _velocity;

        private GameObject _gameObject;
        private Transform _transform;
        private TrailRenderer _trailRenderer;
        private Rigidbody2D _rigidbody;

        #endregion

        #region Properties

        public bool IsDead => _lifeTimeCurrent == 0;

        #endregion

        #region Constructors

        public BulletController(BulletView view)
        {

            _lifeTime       = view.LifeTime;

            _gameObject     = view.gameObject;
            _transform      = view.transform;
            _trailRenderer  = view.TrailRenderer;
            _rigidbody      = view.Rigidbody;

            SwitchOff();

        }

        #endregion

        #region Methods

        private void SetVelocity()
        {

            _rigidbody.AddForce(_velocity, ForceMode2D.Force);

            var angle           = Vector3.Angle(Vector3.left, _velocity);
            var axis            = Vector3.Cross(Vector3.left, _velocity);
            
            _transform.rotation = Quaternion.AngleAxis(angle, axis);

        }

        public void Throw(Transform spawnTransform, Vector3 velocity)
        {

            SwitchOn();

            _transform.SetPositionAndRotation(spawnTransform);

            _velocity = velocity;

            SetVelocity();

        }

        private void Toggle(bool state)
        {

            if (_trailRenderer)
            {

                _trailRenderer.enabled = state;
                _trailRenderer.Clear();

            };

            _gameObject.SetActive(state);

        }

        #endregion

        #region Interfaces Properties

        public void Restart()
        {

            SwitchOff();

            _transform.SetLocalPositionAndRotation();

        }

        public void OnUpdate(float deltaTime)
        {

            if (!_gameObject.activeSelf) return;

            _lifeTimeCurrent = Mathf.Clamp(_lifeTimeCurrent - deltaTime, 0, _lifeTime);

            if (IsDead)
            {

                SwitchOff();

            };

        }

        public void SwitchOff()
        {

            Toggle(false);

        }

        public void SwitchOn()
        {

            _lifeTimeCurrent = _lifeTime;

            Toggle(true);

        }

        #endregion

    }

}