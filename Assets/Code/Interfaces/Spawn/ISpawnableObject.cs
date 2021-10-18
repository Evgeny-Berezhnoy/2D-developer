using UnityEngine;
using Interfaces.MVC;

namespace Interfaces.Spawn
{
    public interface ISpawnableObject : IController
    {

        #region Properties

        GameObject Gameobject { get; }

        #endregion

    }

}
