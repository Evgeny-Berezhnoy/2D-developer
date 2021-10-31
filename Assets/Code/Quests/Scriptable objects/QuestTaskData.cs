using System.Collections.Generic;
using UnityEngine;
using Interfaces;

namespace Quests
{

    [CreateAssetMenu(menuName = "Quests/Task data", fileName = "Quest task data", order = 1)]
    public class QuestTaskData : ScriptableObject, IIdentificator
    {

        #region Fields

        [SerializeField] private int _id;
        [SerializeField] private string _description;
        [SerializeField] private QuestType _type;

        #endregion

        #region Properties

        public int ID => _id;
        public string Description => _description;
        public QuestType Type => _type;

        #endregion

    }

}