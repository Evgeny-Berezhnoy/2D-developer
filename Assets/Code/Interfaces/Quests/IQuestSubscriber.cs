using System.Collections.Generic;

namespace Interfaces.Quests
{

    public interface IQuestSubscriber : IQuestObjectsToggle
    {

        #region Properties

        List<IQuestView> QuestViews { get; }

        #endregion

    }

}