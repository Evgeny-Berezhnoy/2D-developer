using UnityEngine;

namespace Torches
{

    [CreateAssetMenu(fileName = "Torch data", menuName = "Scriptable objects/Torch data")]
    public class TorchData : ScriptableObject
    {

        #region Fields

        [SerializeField] private GameObject _prefab;

        #endregion

        #region Properties

        public GameObject Prefab => _prefab;

        #endregion

    }

}