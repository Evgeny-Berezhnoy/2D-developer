using Interfaces;

namespace Quests
{

    public class QuestTaskModel : IIdentificator
    {

        #region Fields

        protected int _id;
        protected QuestType _type;

        #endregion

        #region Properties

        public int ID => _id;
        public QuestType Type => _type;
        
        #endregion

        #region Constructors

        public QuestTaskModel(QuestTaskData data)
        {

            _id     = data.ID;
            _type   = data.Type;

        }

        #endregion

    }

}