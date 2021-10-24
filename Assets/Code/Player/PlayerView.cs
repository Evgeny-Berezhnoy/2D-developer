using UnityEngine;

namespace Player
{

    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    public class PlayerView : MonoBehaviour
    {

        #region Fields

        [Header("Components")]
        [SerializeField] private Animator _animator;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private BoxCollider2D _collider;

        [Header("Transforms")]
        [SerializeField] private Transform _legsTransform;

        [Header("Parameters")]
        [SerializeField] private float _speed;
        [SerializeField] private float _leapHeight;
        [SerializeField] private float _ignoringPlatformsLength;

        #endregion

        #region Properties

        public Animator Animator => _animator;
        public Rigidbody2D RigidBody => _rigidbody;
        public BoxCollider2D Collider => _collider;
        public Transform LegsTransform => _legsTransform; 
        public float Speed => _speed;
        public float LeapHeight => _leapHeight;
        public float IgnoringPlatformsLength => _ignoringPlatformsLength;

        #endregion

    }

}