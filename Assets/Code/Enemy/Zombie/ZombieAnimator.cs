using System;
using UnityEngine;
using Controllers;
using Interfaces;

namespace Enemy.Zombie
{

    public class ZombieAnimator : AnimatorController, IRestartable
    {

        #region Fields

        private bool _flipped;
        private int _inputX;

        #endregion

        #region Constructors

        public ZombieAnimator(Animator animator) : base(animator)
        {

            Idle();

        }

        #endregion

        #region Interfaces Methods

        public void Restart()
        {

            Idle();

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

            _flipped    = true;
            _inputX     = 0;

            SetParameters();

        }

        public void IdleRight()
        {

            _flipped    = false;
            _inputX     = 0;

            SetParameters();

        }

        public void WalkLeft()
        {

            _flipped    = true;
            _inputX     = 1;

            SetParameters();

        }

        public void WalkRight()
        {

            _flipped    = false;
            _inputX     = 1;

            SetParameters();

        }

        public void RunLeft()
        {

            _flipped    = true;
            _inputX     = 2;

            SetParameters();

        }

        public void RunRight()
        {

            _flipped    = false;
            _inputX     = 2;

            SetParameters();

        }

        private void SetParameters()
        {

            SetParameter("Flipped", _flipped);
            SetParameter("Input X", _inputX);

        }
        
        #endregion

    }

}