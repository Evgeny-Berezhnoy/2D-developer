using Interfaces.MVC;
using Interfaces.Quests;

namespace Quests
{

    public abstract class QuestTaskController : IController, IQuestTaskController
    {

        #region Fields

        protected bool _completed;
        protected int _id;

        #endregion

        #region Properties

        public int ID => _id;
        public bool Completed { get => _completed; set => _completed = value; }

        #endregion

        #region Constructors

        public QuestTaskController(QuestTaskModel model)
        {

            _id = model.ID;

        }

        #endregion

    }

}