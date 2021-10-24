using System;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using Constants.LayersLogic;
using Constants.Physicals;
using Controllers;
using Game.Physicals;
using Interfaces;
using Interfaces.MVC;
using Interfaces.MVC.UnityEvents;


namespace Enemy.Zombie
{
    public class ZombieMoveController : IController, IRestartable, IUpdate, IFixedUpdate
    {

        #region Fields

        private bool _chasingPlayer;

        private float _walkSpeed;
        private float _runSpeed;

        private Transform _playerTransform;
        private LinkedList<Transform> _itinararyPoints;
        private LinkedListNode<Transform> _itinararyPointCurrent;

        private Rigidbody2D _rigidbody;

        private AIPath _path;
        private AIDestinationSetter _destinationSetter;

        private ZombieAnimator _animator;
        private TriggerContactsPoller2D<Collider2D> _patrolZonePoller;

        #endregion

        #region Properties

        private Vector2 Velocity => _path.desiredVelocity;

        #endregion

        #region Constructors

        public ZombieMoveController(ZombieView view, ZombieAnimator animator, Transform playerTransform)
        {

            _walkSpeed          = view.WalkSpeed;
            _runSpeed           = view.RunSpeed;

            _playerTransform    = playerTransform;
            _itinararyPoints    = new LinkedList<Transform>(view.Itinarary.Destinations);

            _rigidbody          = view.Rigidbody;
            
            _path               = view.Path;
            _path.maxSpeed      = _walkSpeed;
            _destinationSetter  = view.DestinationSetter;
            
            _animator           = animator;
            _patrolZonePoller   = new TriggerContactsPoller2D<Collider2D>(view.Itinarary.PatrolZone, LayerMasks.PLAYER); 

            Restart();

        }

        #endregion

        #region Interfaces Methods

        public void Restart()
        {

            _itinararyPointCurrent = _itinararyPoints.First;

            _rigidbody.MovePosition(_itinararyPointCurrent.Value.position);
            _rigidbody.velocity = Vector2.zero;

            _destinationSetter.target = _itinararyPointCurrent.Value;

        }

        public void OnUpdate(float deltaTime)
        {

            SetAnimationParameters();

        }

        public void OnFixedUpdate(float deltaTime)
        {

            _patrolZonePoller.Overlap();

            if (_patrolZonePoller.HasContacts
                    && !_chasingPlayer)
            {

                _chasingPlayer = true;

                _path.maxSpeed = _runSpeed;

                _destinationSetter.target = _playerTransform;

            }
            else if (!_patrolZonePoller.HasContacts
                    && _chasingPlayer)
            {

                _chasingPlayer = false;

                _path.maxSpeed = _walkSpeed;

                _destinationSetter.target = _itinararyPointCurrent.Value;

            }
            else if (!_chasingPlayer
                    && _path.reachedEndOfPath)
            {

                _itinararyPointCurrent = _itinararyPointCurrent.Next;

                if(_itinararyPointCurrent == null)
                {

                    _itinararyPointCurrent = _itinararyPoints.First;

                };

                _destinationSetter.target = _itinararyPointCurrent.Value;
                
            };

        }

        #endregion

        #region Methods

        private void SetAnimationParameters()
        {

            if (_chasingPlayer)
            {

                if (Velocity.x > 0)
                {

                    _animator.RunRight();

                }
                else
                {

                    _animator.RunLeft();

                };

            }
            else
            {

                if (Velocity.x > Physicals2D.MOVEMENT_THRESHOLD)
                {

                    _animator.WalkRight();

                }
                else if (Velocity.x < 0 - Physicals2D.MOVEMENT_THRESHOLD)
                {

                    _animator.WalkLeft();

                }
                else
                {

                    _animator.Idle();

                };

            };

        }

        #endregion

    }

}