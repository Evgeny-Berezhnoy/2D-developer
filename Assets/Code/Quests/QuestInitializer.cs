using System.Collections.Generic;
using Controllers;
using Game;
using Interfaces.MVC;
using Interfaces.Quests;

namespace Quests
{
    public class QuestInitializer : IGameInitializer
    {

        #region Fields

        private QuestController _questController;

        #endregion

        #region Constructors

        public QuestInitializer(ControllersList controllersList, QuestData data, List<IQuestSubscriber> subscribers, GameRestarter gameRestarter)
        {

            var model = new QuestModel(data);

            _questController = new QuestController(model, subscribers, gameRestarter);

            controllersList.AddController(_questController);

        }

        #endregion

    }

}
