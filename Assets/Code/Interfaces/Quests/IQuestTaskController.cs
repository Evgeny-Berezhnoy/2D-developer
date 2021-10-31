using System.Collections.Generic;

namespace Interfaces.Quests
{

    public interface IQuestTaskController
    {

        #region Properties

        int ID { get; }
        bool Completed { get; set; }
        
        #endregion

    }

}