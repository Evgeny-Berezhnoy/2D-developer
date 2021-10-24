using UnityEngine;

namespace MarchingSquaresDemo
{
    public class ControlNode : Node
    {

        #region Fields

        public bool Active;

        #endregion

        #region Constructors

        public ControlNode(Vector3 position, bool active = false) : base(position)
        {

            Active = active;

        }

        #endregion

    }

}