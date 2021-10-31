using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Controllers;
using ExtensionCompilation;
using Interfaces;
using Interfaces.Components;
using Interfaces.MVC;
using Interfaces.MVC.UnityEvents;
using Interfaces.Quests;

using Object = UnityEngine.Object;

namespace Exit
{

    public class ExitServiceController : IController, IQuestSubscriber, IUpdate, IToggleObject
    {

        #region Fields

        private List<ExitController> _controllers = new List<ExitController>();
        private List<IQuestView> _questViews = new List<IQuestView>();
        private Dictionary<IQuestView, ExitController> _questLevers = new Dictionary<IQuestView, ExitController>();

        #endregion

        #region Interfaces Properties

        public List<IQuestView> QuestViews => _questViews;

        #endregion

        #region Constructors

        public ExitServiceController(List<Transform> transforms, GameObject prefab, Transform poolTransform, GameRestarter gameRestarter)
        {

            for (int i = 0; i < transforms.Count; i++)
            {

                var coin = Object.Instantiate(prefab, poolTransform);

                coin.transform.SetPositionAndRotation(transforms[i]);

                ExitController controller = null;

                if (coin.TryGetComponent<ExitView>(out var view))
                {

                    controller = new ExitController(view, gameRestarter);

                    _controllers.Add(controller);

                };

                if (coin.TryGetComponent<IQuestView>(out var questView))
                {

                    _questViews.Add(questView);

                };

                if (controller != null
                    && questView != null)
                {

                    _questLevers.Add(questView, controller);

                };

            };

        }

        #endregion

        #region Interfaces Methods

        public void EnableQuestObjects(int id)
        {

            var controller = QuestControllersByID(id);

            for (int i = 0; i < controller.Length; i++)
            {

                controller[i].SwitchOn();

            };

        }

        public void DisableQuestObjects(int id)
        {

            var controller = QuestControllersByID(id);

            for (int i = 0; i < controller.Length; i++)
            {

                controller[i].SwitchOff();

            };

        }

        public void OnUpdate(float deltaTime)
        {

            for (int i = 0; i < _controllers.Count; i++)
            {

                _controllers[i].OnUpdate(deltaTime);

            };

        }

        public void SwitchOff()
        {

            for (int i = 0; i < _controllers.Count; i++)
            {

                _controllers[i].SwitchOff();

            };

        }

        public void SwitchOn()
        {

            for (int i = 0; i < _controllers.Count; i++)
            {

                _controllers[i].SwitchOn();

            };

        }

        #endregion

        #region Methods

        private ExitController[] QuestControllersByID(int id)
        {

            return _questLevers
                    .Where((x) => x.Key.ID == id)
                    .ToArray()
                    .Select((x) => x.Value)
                    .ToArray();

        }

        #endregion

    }

}