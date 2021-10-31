using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using ExtensionCompilation;
using Interfaces.Components;
using Interfaces.MVC;
using Interfaces.MVC.UnityEvents;
using Interfaces.Quests;
using Points;

using Object = UnityEngine.Object;

namespace Coins
{

    public class CoinServiceController : IController, IQuestSubscriber, IUpdate, IToggleObject
    {

        #region Fields

        private List<CoinController> _controllers = new List<CoinController>();
        private List<IQuestView> _questViews = new List<IQuestView>();
        private Dictionary<IQuestView, CoinController> _questLevers = new Dictionary<IQuestView, CoinController>();

        #endregion

        #region Interfaces Properties

        public List<IQuestView> QuestViews => _questViews;

        #endregion

        #region Constructors

        public CoinServiceController(List<Transform> transforms, CoinData coinData, Transform poolTransform, PointsController pointsController)
        {

            for(int i = 0; i < transforms.Count; i++)
            {

                var coin = Object.Instantiate(coinData.Prefab, poolTransform);

                coin.transform.SetPositionAndRotation(transforms[i]);

                CoinController controller = null;

                if(coin.TryGetComponent<CoinView>(out var coinView))
                {

                    controller = new CoinController(coinView, pointsController, coinData.Points);

                    _controllers.Add(controller);
                    
                };
                
                if (coin.TryGetComponent<IQuestView>(out var questView))
                {

                    _questViews.Add(questView);

                };

                if(controller != null
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
            
            for(int i = 0; i < controller.Length; i++)
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
            
            for(int i = 0; i < _controllers.Count; i++)
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

        private CoinController[] QuestControllersByID(int id)
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