using UnityEngine;
using Bullet;
using Interfaces;
using Interfaces.MVC;
using Interfaces.MVC.UnityEvents;

namespace Enemy.Gun
{
    public class GunController : IController, IRestartable, IUpdate, IFixedUpdate
    {

        #region Fields
        
        private Transform _muzzleTransform;
        private Transform _playerTransform;

        private BulletsSeviceController _bulletsSeviceController;

        #endregion

        #region Constructors

        public GunController(GunView gunView, BulletData bulletData, Transform playerTransform, Transform poolTransform)
        {

            _muzzleTransform            = gunView.Muzzle;
            _playerTransform            = playerTransform;

            _bulletsSeviceController    = new BulletsSeviceController(bulletData, gunView.ProjectileSpawnPoint, poolTransform);

        }

        #endregion

        #region Interface methods

        public void Restart()
        {

            _bulletsSeviceController.Restart();

        }

        public void OnUpdate(float deltaTime)
        {

            var relativePosition        = _playerTransform.position - _muzzleTransform.position;
            var angle                   = Vector3.Angle(Vector3.up, relativePosition);
            var axis                    = Vector3.Cross(Vector3.up, relativePosition);
            
            _muzzleTransform.rotation   = Quaternion.AngleAxis(angle, axis);

            _bulletsSeviceController.OnUpdate(deltaTime);

        }

        public void OnFixedUpdate(float deltaTime)
        {

            _bulletsSeviceController.OnFixedUpdate(deltaTime);

        }

        #endregion

    }

}