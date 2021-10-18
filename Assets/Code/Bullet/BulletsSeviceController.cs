using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Interfaces.MVC;
using Interfaces.MVC.UnityEvents;

namespace Bullet
{
    public class BulletsSeviceController : IController, IUpdate, IFixedUpdate
    {

        #region Fields

        private float _cooldown;
        private float _cooldownCurrent;
        private float _speed;

        private Transform _bulletSpawnPoint;

        private List<BulletController> _bulletControllers = new List<BulletController>();

        #endregion

        #region Cosntructors

        public BulletsSeviceController(BulletData bulletData, Transform bulletSpawnPoint, Transform poolTransform)
        {

            _cooldown           = bulletData.Cooldown;
            _speed              = bulletData.Speed;

            _bulletSpawnPoint   = bulletSpawnPoint;

            for(int i = 0; i < bulletData.BulletsAmount; i++)
            {

                var bulletPrefab = Object.Instantiate(bulletData.Prefab, poolTransform);

                _bulletControllers.Add(new BulletController(bulletPrefab.GetComponent<BulletView>()));

            };

        }

        #endregion

        #region Interfaces Methods

        public void OnUpdate(float deltaTime)
        {

            _cooldownCurrent = Mathf.Clamp(_cooldownCurrent - deltaTime, 0, _cooldown);

            if(_cooldownCurrent == 0)
            {

                _cooldownCurrent = _cooldown;

                var _bulletController = _bulletControllers.FirstOrDefault(x => x.IsDead);

                if(_bulletController == null)
                {

                    _bulletController = _bulletControllers[0];

                };

                _bulletController.Throw(_bulletSpawnPoint, _bulletSpawnPoint.up.normalized * _speed);

            };

            for(int i = 0; i < _bulletControllers.Count; i++)
            {

                _bulletControllers[i].OnUpdate(deltaTime);

            };

        }

        public void OnFixedUpdate()
        {

            for (int i = 0; i < _bulletControllers.Count; i++)
            {

                _bulletControllers[i].OnFixedUpdate();

            };

        }

        #endregion

    }

}
