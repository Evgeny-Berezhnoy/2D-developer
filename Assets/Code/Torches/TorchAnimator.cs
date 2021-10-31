using UnityEngine;
using Controllers;
using Interfaces;

namespace Torches
{

    public class TorchAnimator : AnimatorController
    {

        #region Fields

        private bool _firedUp;

        #endregion

        #region Constructors

        public TorchAnimator(Animator animator) : base(animator)
        {

            Unlit();

        }

        #endregion

        #region Methods

        public void Lit()
        {

            _firedUp = true;

            SetParameters();

        }

        public void Unlit()
        {

            _firedUp = false;

            SetParameters();

        }
        
        private void SetParameters()
        {

            SetParameter("Fired up", _firedUp);
            
        }

        #endregion

    }

}