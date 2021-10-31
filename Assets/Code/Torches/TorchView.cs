using UnityEngine;

namespace Torches
{

    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(BoxCollider2D))]
    public class TorchView : MonoBehaviour
    {

        #region Fields

        [SerializeField] private Animator _animator;
        [SerializeField] private BoxCollider2D _collider;

        #endregion

        #region Properties

        public Animator Animator => _animator;
        public BoxCollider2D Collider => _collider;

        #endregion

    }

}