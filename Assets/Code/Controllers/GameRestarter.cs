using System;
using System.Linq;
using Interfaces;
using Interfaces.MVC;

namespace Controllers
{

    public class GameRestarter : IController, IRestartable, IEventHandler<Action>, IDisposable
    {

        #region Events

        private event Action _onTrigger;

        #endregion

        #region Interfaces Methods

        public void Restart()
        {

            _onTrigger?.Invoke();

        }
        
        public void AddHandler(Action handler)
        {

            _onTrigger += handler;

        }

        public void RemoveHandler(Action handler)
        {

            _onTrigger -= handler;

        }

        public void RemoveAllHandlers()
        {

            var handlers =
                _onTrigger
                    .GetInvocationList()
                    .ToList()
                    .Cast<Action>()
                    .ToList();

            for (int i = 0; i < handlers.Count; i++)
            {

                _onTrigger -= handlers[i];

            };

        }

        public void Dispose()
        {

            RemoveAllHandlers();

        }
        
        #endregion

    }

}