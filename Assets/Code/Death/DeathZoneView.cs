using UnityEngine;

namespace Death
{

    [RequireComponent(typeof(BoxCollider2D))]
    public class DeathZoneView : MonoBehaviour
    {

        #region Fields

        [Header("Components")]
        [SerializeField] private BoxCollider2D _collider;

        #endregion

        #region Properties

        public BoxCollider2D Collider => _collider;

        #endregion

    }

}