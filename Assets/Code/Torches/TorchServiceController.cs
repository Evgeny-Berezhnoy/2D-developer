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

namespace Torches
{

    public class TorchServiceController : IController, IQuestSubscriber, IUpdate, IToggleObject
    {

        #region Fields

        private List<TorchController> _controllers = new List<TorchController>();
        private List<IQuestView> _questViews = new List<IQuestView>();
        private Dictionary<IQuestView, TorchController> _questLevers = new Dictionary<IQuestView, TorchController>();
        
        #endregion

        #region Interfaces Properties

        public List<IQuestView> QuestViews => _questViews;

        #endregion

        #region Constructors

        public TorchServiceController(List<Transform> transforms, Transform poolTransform, GameObject prefab)
        {

            for (int i = 0; i < transforms.Count; i++)
            {

                var torch = Object.Instantiate(prefab, poolTransform);

                torch.transform.SetPositionAndRotation(transforms[i]);

                TorchController controller = null;

                if (torch.TryGetComponent<TorchView>(out var torchView))
                {

                    controller = new TorchController(torchView);

                    _controllers.Add(controller);
                    
                };

                if (torch.TryGetComponent<IQuestView>(out var questView))
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

            var controllers = QuestControllersByID(id);

            for (int i = 0; i < controllers.Length; i++)
            {

                controllers[i].SwitchOn();

            };

        }

        public void DisableQuestObjects(int id)
        {

            var controllers = QuestControllersByID(id);

            for (int i = 0; i < controllers.Length; i++)
            {

                var controller = controllers[i];

                controller.SwitchOff();
                controller.Animator.Unlit();

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

        private TorchController[] QuestControllersByID(int id)
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