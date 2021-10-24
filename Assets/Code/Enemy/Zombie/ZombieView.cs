using UnityEngine;
using Pathfinding;
using Views;

namespace Enemy.Zombie
{

    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(AIDestinationSetter))]
    [RequireComponent(typeof(AIPath))]
    [RequireComponent(typeof(Itinarary))]
    public class ZombieView : MonoBehaviour
    {

        #region Fields

        [SerializeField] private float _walkSpeed;
        [SerializeField] private float _runSpeed;
        [SerializeField] private Animator _animator;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private AIDestinationSetter _destinationSetter;
        [SerializeField] private AIPath _path;
        [SerializeField] private Itinarary _itinarary;

        #endregion

        #region Properties

        public float WalkSpeed => _walkSpeed;
        public float RunSpeed => _runSpeed;
        public Animator Animator => _animator;
        public Rigidbody2D Rigidbody => _rigidbody;
        public AIDestinationSetter DestinationSetter => _destinationSetter;
        public AIPath Path => _path;
        public Itinarary Itinarary => _itinarary;
        
        #endregion

    }

}