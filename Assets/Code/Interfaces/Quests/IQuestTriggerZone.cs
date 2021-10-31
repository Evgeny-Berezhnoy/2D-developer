using UnityEngine;

namespace Interfaces.Quests
{

    public interface IQuestTriggerZone : IQuestView
    {

        #region Properties

        Collider2D TriggerZone { get; }

        #endregion

    }

}