using System.Collections.Generic;
using Interfaces.MVC.UnityEvents;
using Interfaces.Quests;

namespace Quests
{

    public class QuestTaskTriggerZoneController : QuestTaskController, IUpdate
    {

        #region Fields

        private List<IQuestTriggerZone> _triggerZones;

        #endregion

        #region Constructors

        public QuestTaskTriggerZoneController(QuestTaskModel model, List<IQuestTriggerZone> triggerZones) : base(model)
        {

            _triggerZones = triggerZones;

        }

        #endregion

        #region Interfaces Methods

        public void OnUpdate(float deltaTime)
        {

            var zonesTriggered = _triggerZones.TrueForAll((x) => !x.TriggerZone.enabled);

            if (zonesTriggered)
            {

                _completed = true;

            };

        }

        #endregion

    }

}
