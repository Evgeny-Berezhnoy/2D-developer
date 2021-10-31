using System.Collections.Generic;

using static Iterators.AdvancedIterators;

namespace Quests
{

    public class QuestModel
    {

        #region Fields

        private List<QuestTaskModel> _tasks = new List<QuestTaskModel>();

        #endregion

        #region Properties

        public List<QuestTaskModel> Tasks => _tasks;

        #endregion

        #region Constructors

        public QuestModel(QuestData data)
        {

            ExecuteLinearAction(data.TasksData.Count, (i) =>
            {

                _tasks.Add(new QuestTaskModel(data.TasksData[i]));

            });

        }

        #endregion

    }

}