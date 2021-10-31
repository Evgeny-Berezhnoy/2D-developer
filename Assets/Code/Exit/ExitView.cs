using UnityEngine;

namespace Exit
{

    [RequireComponent(typeof(BoxCollider2D))]
    public class ExitView : MonoBehaviour
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