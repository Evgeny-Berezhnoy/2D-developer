using System.Collections.Generic;
using UnityEngine;
using Interfaces;

namespace Quests
{

    [CreateAssetMenu(menuName = "Quests/Quest", fileName = "Quest data", order = 0)]
    public class QuestData : ScriptableObject, IIdentificator
    {

        #region Fields

        [SerializeField] private int _id;
        [SerializeField] private string _description;
        [SerializeField] private List<QuestTaskData> _tasksData;

        #endregion

        #region Properties

        public int ID => _id;
        public string Description => _description;
        public List<QuestTaskData> TasksData => _tasksData;

        #endregion
        
    }

}