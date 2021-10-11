using UnityEngine;
using Interfaces.Components;

namespace Bullet
{

    [RequireComponent(typeof(TrailRenderer))]
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(CircleCollider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class BulletView : MonoBehaviour, ISpriteRenderer, ICollider<CircleCollider2D>
    {

        #region Fields

        [Header("Components")]
        [SerializeField] private TrailRenderer _trailRenderer;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private CircleCollider2D _collider;
        [SerializeField] private Rigidbody2D _rigidbody;

        [Header("Properties")]
        [SerializeField] private float _lifeTime;

        #endregion

        #region Interfaces Properties

        public TrailRenderer TrailRenderer => _trailRenderer;
        public SpriteRenderer SpriteRenderer => _spriteRenderer;
        public CircleCollider2D Collider => _collider;
        public Rigidbody2D Rigidbody => _rigidbody;
        public float LifeTime => _lifeTime;

        #endregion

    }

}