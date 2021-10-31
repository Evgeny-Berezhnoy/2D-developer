using UnityEngine;
using Interfaces.Quests;

namespace Quests
{

    public class QuestTriggerZoneView : MonoBehaviour, IQuestTriggerZone
    {

        #region Fields

        [SerializeField] private int _stepID;
        [SerializeField] private Collider2D _triggerZone;

        #endregion

        #region Properties

        public Collider2D TriggerZone => _triggerZone;
        public int ID => _stepID;

        #endregion

    }

}