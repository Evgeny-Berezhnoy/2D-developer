using UnityEngine;
using Constants.LayersLogic;
using Controllers;
using ExtensionCompilation;
using Interfaces.MVC.UnityEvents;


namespace Player
{
    public class PlayerMoveController : MoveController, IUpdate
    {

        #region Fields

        private bool _onTheGround;
        private Vector2 _leapForce;

        private Transform _legsTransform;
        private BoxCollider2D _collider;
        private Rigidbody2D _rigidbody;

        private PlayerAnimator _playerAnimator;
        private InputController _inputController;

        #endregion

        #region Constructors

        public PlayerMoveController(PlayerView playerView, PlayerAnimator playerAnimator, InputController inputController) : base(playerView.transform, playerView.Speed)
        {

            _onTheGround        = true;
            _leapForce          = new Vector2(0, playerView.LeapHeight);
            _legsTransform      = playerView.LegsTransform;
            _collider           = playerView.Collider;
            _rigidbody          = playerView.RigidBody;
            _playerAnimator     = playerAnimator;
            _inputController    = inputController;
            
            _inputController.AddAxisShiftHandler(Move);
            _inputController.AddSpacePressHandler(Jump);

        }

        #endregion

        #region Destructors

        ~PlayerMoveController()
        {

            _inputController.RemoveAxisShiftHandler(Move);
            _inputController.RemoveSpacePressHandler(Jump);

        }

        #endregion

        #region Base Methods

        public override void Move(Vector3 direction, float deltaTime)
        {

            var directionX = direction.TrimX();

            base.Move(directionX, deltaTime);

            if (directionX.x == 0)
            {

                _playerAnimator.Idle();

            }
            else if (directionX.x > 0)
            {

                _playerAnimator.RunRight();

            }
            else
            {

                _playerAnimator.RunLeft();

            };

        }

        #endregion

        #region Interfaces Methods

        public void OnUpdate(float deltaTime)
        {

            _onTheGround = (Physics2D.OverlapCircle(_legsTransform.position, _collider.size.x, LayerMasks.GROUND) != null);

            if (_onTheGround)
            {

                _playerAnimator.Landed();

            }
            else
            {

                _playerAnimator.Airborne();

            };

            _rigidbody.velocity = Vector2.ClampMagnitude(_rigidbody.velocity, 10f);
            
        }

        #endregion

        #region Methods

        private void Jump()
        {

            if (!_onTheGround) return;

            _rigidbody.AddForce(_leapForce);

            _playerAnimator.Jump();

        }

        #endregion

    }

}