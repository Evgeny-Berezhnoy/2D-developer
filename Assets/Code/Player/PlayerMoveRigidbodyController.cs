using System;
using UnityEngine;
using Constants.LayersLogic;
using Constants.Physicals;
using Controllers;
using ExtensionCompilation;
using Game.Physicals;
using Interfaces;
using Interfaces.MVC.UnityEvents;


namespace Player
{
    public class PlayerMoveRigidbodyController : MoveController, IRestartable, IUpdate, IFixedUpdate, IDisposable
    {

        #region Fields

        private bool _executeJump = false;
        private float _ignoringPlatformsLength;
        private float _ignoringPlatformsLengthCurrent;

        private Vector2 _direction;
        private Vector2 _leapForce;

        private Transform _playerStartTransform;
        private BoxCollider2D _collider;
        private Rigidbody2D _rigidbody;

        private PlayerAnimator _playerAnimator;
        private RestrictionsContactsPoller2D<BoxCollider2D> _contactsPoller;

        #endregion

        #region Observers

        private InputController _inputController;
        private GameRestarter _gameRestarter;
        
        #endregion

        #region Constructors

        public PlayerMoveRigidbodyController(Transform playerStartTransform, PlayerView playerView, GameRestarter gameRestarter, PlayerAnimator playerAnimator, InputController inputController) : base(playerView.transform, playerView.Speed)
        {

            _ignoringPlatformsLength        = playerView.IgnoringPlatformsLength;
            _ignoringPlatformsLengthCurrent = 0;

            _direction                      = Vector2.zero;
            _leapForce                      = new Vector2(0, playerView.LeapHeight);

            _playerStartTransform           = playerStartTransform;
            _collider                       = playerView.Collider;
            _rigidbody                      = playerView.RigidBody;
            
            _playerAnimator                 = playerAnimator;
            _contactsPoller                 = new RestrictionsContactsPoller2D<BoxCollider2D>(_collider, LayerMasks.SURFACES);

            _inputController                = inputController;
            _gameRestarter                  = gameRestarter;
                        
            _inputController.AddAxisShiftHandler(Move);
            _inputController.AddSpacePressHandler(Jump);

            _gameRestarter.AddHandler(Restart);

            Restart();

        }

        #endregion

        #region Base Methods

        public override void Move(Vector3 direction, float deltaTime)
        {

            _direction = direction;
            
            if(_direction.y < 0)
            {

                _ignoringPlatformsLengthCurrent = _ignoringPlatformsLength;

            };

        }

        #endregion

        #region Interfaces Methods

        public void Restart()
        {

            _rigidbody.MovePosition(_playerStartTransform.position);
            _rigidbody.velocity = Vector2.zero;

        }

        public void OnUpdate(float deltaTime)
        {

            _ignoringPlatformsLengthCurrent = Mathf.Clamp(_ignoringPlatformsLengthCurrent - deltaTime, 0, _ignoringPlatformsLength);

            SetAnimationParameters();

        }

        public void OnFixedUpdate(float deltaTime)
        {

            _contactsPoller.OnFixedUpdate(deltaTime);

            var directionX = (_direction.normalized * (deltaTime * Speed)).x;

            if (directionX > 0 && !_contactsPoller.HasRightContacts)
            {

                _rigidbody.velocity = _rigidbody.velocity.Change(x: directionX);

            }
            else if (directionX < 0 && !_contactsPoller.HasLeftContacts)
            {

                _rigidbody.velocity = _rigidbody.velocity.Change(x: directionX);

            }
            else
            {

                _rigidbody.velocity = _rigidbody.velocity.Change(x: 0);

            };

            if (_executeJump)
            {

                _executeJump = false;

                _rigidbody.AddForce(_leapForce);

            };

            if(_rigidbody.velocity.y < Physicals2D.FALL_VELOCITY_LIMIT)
            {

                _rigidbody.velocity = _rigidbody.velocity.Change(y: Physicals2D.FALL_VELOCITY_LIMIT);

            };

            if(_ignoringPlatformsLengthCurrent > 0
                    && !Physics2D.GetIgnoreLayerCollision(Layers.PLAYER, Layers.PLATFORM))
            {

                Physics2D.IgnoreLayerCollision(Layers.PLAYER, Layers.PLATFORM, true);    

            }
            else if (_ignoringPlatformsLengthCurrent == 0
                        && Physics2D.GetIgnoreLayerCollision(Layers.PLAYER, Layers.PLATFORM))
            {
                
                Physics2D.IgnoreLayerCollision(Layers.PLAYER, Layers.PLATFORM, false);
                
            };

        }

        public void Dispose()
        {

            _inputController.RemoveAxisShiftHandler(Move);
            _inputController.RemoveSpacePressHandler(Jump);

            _gameRestarter.RemoveHandler(Restart);

        }

        #endregion

        #region Methods

        private void Jump()
        {

            if (_executeJump || !_contactsPoller.OnTheGround) return;

            _executeJump = true;

            _playerAnimator.Jump();

        }

        private void SetAnimationParameters()
        {

            if (_direction.x < 0 - Physicals2D.MOVEMENT_THRESHOLD)
            {

                _playerAnimator.RunLeft();

            }
            else if (_direction.x > Physicals2D.MOVEMENT_THRESHOLD)
            {

                _playerAnimator.RunRight();

            }
            else
            {

                _playerAnimator.Idle();
                
            };
            
            if (_contactsPoller.OnTheGround)
            {

                _playerAnimator.Landed();

            }
            else
            {

                _playerAnimator.Airborne();

            };

        }

        #endregion

    }

}