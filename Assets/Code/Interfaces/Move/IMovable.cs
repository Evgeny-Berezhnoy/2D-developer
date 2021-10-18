using UnityEngine;

namespace Interfaces.Move
{
    public interface IMovable
    {

        #region Properties

        Transform TravelerTransform { get; }
        float Speed { get; set; }

        #endregion

        #region Methods

        void Move(Vector3 direction, float deltaTime);

        #endregion

    }

}