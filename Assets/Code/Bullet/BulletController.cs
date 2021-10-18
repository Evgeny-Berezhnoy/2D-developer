using UnityEngine;
using Constants.LayersLogic;
using ExtensionCompilation;
using Interfaces.Components;
using Interfaces.MVC;
using Interfaces.MVC.UnityEvents;

using Collision = Constants.LayersLogic.Collision;

namespace Bullet
{

    public class BulletController : IController, IUpdate, IFixedUpdate, IToggleObject
    {

        #region Fields

        private float _lifeTime;
        private float _lifeTimeCurrent;

        private Vector2 _velocity;

        private Transform _transform;
        private TrailRenderer _trailRenderer;
        private CircleCollider2D _collider;
        private Rigidbody2D _rigidbody;

        #endregion

        #region Properties

        public bool IsDead => _lifeTimeCurrent == 0;

        #endregion

        #region Constructors

        public BulletController(BulletView view)
        {

            _lifeTime       = view.LifeTime;

            _transform      = view.transform;
            _trailRenderer  = view.TrailRenderer;
            _collider       = view.Collider;
            _rigidbody      = view.Rigidbody;

            SwitchOff();

        }

        #endregion

        #region Methods

        private void SetVelocity()
        {

            _rigidbody.velocity = _velocity;
            
            var angle           = Vector3.Angle(Vector3.left, _velocity);
            var axis            = Vector3.Cross(Vector3.left, _velocity);
            
            _transform.rotation = Quaternion.AngleAxis(angle, axis);

        }

        public void Throw(Transform spawnTransform, Vector3 velocity)
        {
            
            _transform.SetPositionAndRotation(spawnTransform);

            _velocity = velocity;

            SwitchOn();

        }

        private void Toggle(bool state)
        {

            if (_trailRenderer)
            {

                _trailRenderer.enabled = state;
                _trailRenderer.Clear();

            };

            _transform.gameObject.SetActive(state);

        }

        private Collision CheckCollision()
        {

            if(Physics2D.OverlapCircle(_transform.position, _collider.radius, LayerMasks.WALL) != null)
            {

                return Collision.WALL;

            }
            if (Physics2D.OverlapCircle(_transform.position, _collider.radius, LayerMasks.GROUND) != null)
            {

                return Collision.GROUND;

            }
            else
            {

                return Collision.NONE;

            };

        }

        #endregion

        #region Interfaces Properties

        public void OnUpdate(float deltaTime)
        {

            _lifeTimeCurrent = Mathf.Clamp(_lifeTimeCurrent - deltaTime, 0, _lifeTime);

            if (IsDead)
            {

                SwitchOff();

                return;

            }

            var collision = CheckCollision();

            if (collision == Collision.GROUND)
            {

                _velocity = _velocity.Change(y: 0 - _velocity.y);

                _transform.position = _transform.position.Change(y: _transform.position.y + _collider.radius);

            }
            else if (collision == Collision.WALL)
            {

                _velocity = _velocity.Change(x: 0 - _velocity.x);

                if (_velocity.x > 0)
                {

                    _transform.position = _transform.position.Change(x: _transform.position.x + _collider.radius);

                }
                else if(_velocity.x < 0)
                {

                    _transform.position = _transform.position.Change(x: _transform.position.x - _collider.radius);

                };
                                
            }
            else
            {

                _velocity = _velocity + Vector2.up * Physics2D.gravity.y * Time.deltaTime;

            }

        }

        public void OnFixedUpdate()
        {

            SetVelocity();

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