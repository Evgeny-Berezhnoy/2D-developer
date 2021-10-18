using System;
using System.Linq;
using UnityEngine;
using Constants.InputNames;
using Interfaces.MVC;
using Interfaces.MVC.UnityEvents;

using static Constants.Delegates;

namespace Controllers
{
    public class InputController : IController, IUpdate, IDisposable
    {

        #region Events

        private event AxisShiftDelegate _onAxisShift;
        private event Action _onSpacePress;

        #endregion

        #region Properties

        private Vector3 _axisShift => new Vector3(Input.GetAxis(InputAxis.HORIZONTAL), Input.GetAxis(InputAxis.VERTICAL));

        #endregion

        #region Methods

        public void AddAxisShiftHandler(AxisShiftDelegate handler)
        {

            _onAxisShift += handler;

        }

        public void RemoveAxisShiftHandler(AxisShiftDelegate handler)
        {

            _onAxisShift -= handler;

        }
            
        public void RemoveAllAxisShiftHandlers()
        {

            var axisShiftHandlers =
                _onAxisShift
                    .GetInvocationList()
                    .ToList()
                    .Cast<AxisShiftDelegate>()
                    .ToList();

            for (int i = 0; i < axisShiftHandlers.Count; i++)
            {

                _onAxisShift -= axisShiftHandlers[i];

            };

        }

        public void AddSpacePressHandler(Action handler)
        {

            _onSpacePress += handler;

        }

        public void RemoveSpacePressHandler(Action handler)
        {

            _onSpacePress -= handler;

        }

        public void RemoveAllSpacePressHandlers()
        {

            var spacePressHandlers =
                _onSpacePress
                    .GetInvocationList()
                    .ToList()
                    .Cast<Action>()
                    .ToList();

            for (int i = 0; i < spacePressHandlers.Count; i++)
            {

                _onSpacePress -= spacePressHandlers[i];

            };

        }

        private void CheckAxisShift(float deltaTime)
        {

            _onAxisShift?.Invoke(_axisShift, deltaTime);

        }

        private void CheckSpacePress()
        {

            if (Input.GetButtonDown(InputButtons.SPACE))
            {

                _onSpacePress?.Invoke();

            };
            
        }

        #endregion

        #region Interfaces Methods

        public void OnUpdate(float deltaTime)
        {

            CheckAxisShift(deltaTime);

            CheckSpacePress();

        }

        public void Dispose()
        {

            RemoveAllAxisShiftHandlers();

            RemoveAllSpacePressHandlers();

        }

        #endregion

    }

}