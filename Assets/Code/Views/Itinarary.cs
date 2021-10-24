using System.Collections.Generic;
using UnityEngine;

namespace Views
{

    public class Itinarary : MonoBehaviour
    {

        #region Fields

        [SerializeField] private BoxCollider2D _patrolZone;
        [SerializeField] private List<Transform> _destinations;

        #endregion

        #region Properties

        public BoxCollider2D PatrolZone => _patrolZone;
        public List<Transform> Destinations => _destinations;

        #endregion

    }

}