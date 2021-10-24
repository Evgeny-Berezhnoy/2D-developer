namespace MarchingSquaresDemo
{

    public class Square
    {

        #region Fields

        public ControlNode TopLeft;
        public ControlNode TopRight;
        public ControlNode BottomRight;
        public ControlNode BottomLeft;

        #endregion

        #region Constructors

        public Square(ControlNode topLeft, ControlNode topRight, ControlNode bottomRight, ControlNode bottomLeft)
        {

            TopLeft     = topLeft;
            TopRight    = topRight;
            BottomRight = bottomRight;
            BottomLeft  = bottomLeft;
        
        }

        #endregion

    }

}