using System.Collections.Generic;
using UnityEngine;

namespace Torches
{

    public class TorchCollectionView : MonoBehaviour
    {

        #region Fields

        [SerializeField] private List<Transform> _torches;
        [SerializeField] private GameObject _prefab;

        #endregion

        #region Properties

        public List<Transform> Torches => _torches;
        public GameObject Prefab => _prefab;

        #endregion

    }

}