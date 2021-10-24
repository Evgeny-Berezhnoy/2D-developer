using LinearPassAction = Constants.Delegates.LinearPassAction;
using GridPassAction = Constants.Delegates.GridPassAction;

namespace Iterators
{

    public static class AdvancedIterators
    {

        #region Static Methods

        public static void ExecuteLinearAction(int count, LinearPassAction linearPassAction)
        {

            for (int x = 0; x < count; x++)
            {

                linearPassAction(x);

            };

        }
        
        public static void ExecuteLinearAction(int countStart, int countEnd, LinearPassAction linearPassAction)
        {

            for (int x = countStart; x < countEnd; x++)
            {

                linearPassAction(x);

            };

        }

        public static void ExecuteGridAction(int columnCount, int rowCount, GridPassAction gridPassAction)
        {

            for (int x = 0; x < columnCount; x++)
            {

                for (int y = 0; y < rowCount; y++)
                {

                    gridPassAction(x, y);

                };

            };

        }

        public static void ExecuteGridAction(int columnCountStart, int columnCountEnd, int rowCountStart, int rowCountEnd, GridPassAction gridPassAction)
        {

            for (int x = columnCountStart; x < columnCountEnd; x++)
            {

                for (int y = rowCountStart; y < rowCountEnd; y++)
                {

                    gridPassAction(x, y);

                };

            };

        }

        #endregion

    }

}