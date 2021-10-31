using System.Collections.Generic;
using UnityEngine;

namespace Exit
{

    public class ExitCollectionView : MonoBehaviour
    {

        #region Fields

        [SerializeField] private List<Transform> _transforms;
        [SerializeField] private GameObject _prefab;

        #endregion

        #region Properties

        public List<Transform> Transforms => _transforms;
        public GameObject Prefab => _prefab;

        #endregion

    }

}