using UnityEngine;
using Interfaces.MVC;
using Interfaces.MVC.UnityEvents;

namespace Lifts
{
    public class LiftController : IController, IFixedUpdate
    {

        #region Fields

        private bool _increasingTranslation = true;
        private float _upperTranslation;
        private float _upperTranslationCurrent;
        
        private SliderJoint2D _slider;

        #endregion

        #region Constructors

        public LiftController(LiftView view)
        {

            _upperTranslation           = view.MaxUpperTranslation;
            _upperTranslationCurrent    = 0;
            
            _slider = view.Slider;

        }

        #endregion

        #region Interfaces Methods

        public void OnFixedUpdate(float deltaTime)
        {

            if (_increasingTranslation)
            {

                _upperTranslationCurrent = Mathf.Clamp(_upperTranslationCurrent + _slider.motor.motorSpeed * deltaTime, 0, _upperTranslation);

                var sliderJointLimits = new JointTranslationLimits2D()
                {

                    min = 0,
                    max = _upperTranslationCurrent

                };

                _slider.limits = sliderJointLimits;

                if (_upperTranslationCurrent == _upperTranslation)
                {

                    _increasingTranslation = false;

                };

            }
            else
            {

                _upperTranslationCurrent = Mathf.Clamp(_upperTranslationCurrent - _slider.motor.motorSpeed * deltaTime, 0, _upperTranslation);

                var sliderJointLimits = new JointTranslationLimits2D()
                {

                    min = 0,
                    max = _upperTranslationCurrent

                };

                _slider.limits = sliderJointLimits;

                if (_upperTranslationCurrent == 0)
                {

                    _increasingTranslation = true;

                };

            };

        }

        #endregion

    }
}
