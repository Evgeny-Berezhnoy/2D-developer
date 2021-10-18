using UnityEngine;
using Controllers;

namespace Player
{
    public class PlayerAnimator : AnimatorController
    {

        #region Fields

        private bool _onTheGround;
        private bool _flipped;
        private int _inputX;

        #endregion

        #region Constructors

        public PlayerAnimator(Animator animator) : base(animator)
        {

            IdleRight();

            Landed();

        }

        #endregion

        #region Methods

        public void Idle()
        {

            _inputX = 0;

            SetParameters();

        }

        public void IdleLeft()
        {

            _flipped    = false;
            _inputX     = 0;

            SetParameters();

        }

        public void IdleRight()
        {

            _flipped    = true;
            _inputX     = 0;

            SetParameters();

        }

        public void RunLeft()
        {

            _flipped    = false;
            _inputX     = -1;

            SetParameters();

        }

        public void RunRight()
        {

            _flipped    = true;
            _inputX     = 1;

            SetParameters();

        }

        public void Airborne()
        {

            _onTheGround = false;

            SetParameters();

        }

        public void Landed()
        {

            _onTheGround = true;

            SetParameters();

        }

        public void Jump()
        {

            if (!_onTheGround) return;

            Airborne();

            SetTrigger("Jump");

        }

        private void SetParameters()
        {

            SetParameter("On the ground", _onTheGround);
            SetParameter("Flipped", _flipped);
            SetParameter("Input X", _inputX);
            
        }

        #endregion

    }

}