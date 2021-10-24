using System.Collections.Generic;
using Interfaces.MVC;
using Interfaces.MVC.UnityEvents;

namespace Lifts
{
    
    public class LiftServiceController : IController, IFixedUpdate
    {

        #region Fields

        private List<LiftController> _liftControllers = new List<LiftController>();

        #endregion

        #region Constructors

        public LiftServiceController(List<LiftView> liftViews)
        {

            for (int i = 0; i < liftViews.Count; i++)
            {

                _liftControllers.Add(new LiftController(liftViews[i]));

            };

        }

        #endregion

        #region Interfaces Methods

        public void OnFixedUpdate(float deltaTime)
        {

            for (int i = 0; i < _liftControllers.Count; i++)
            {

                _liftControllers[i].OnFixedUpdate(deltaTime);

            };

        }

        #endregion

    }

}