using UnityEngine;

namespace Interfaces.Components
{

    public interface ICollider<T>
        where T : Collider2D
    {

        #region Properties

        T Collider { get; }

        #endregion

    }

}