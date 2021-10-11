using System.Collections.Generic;
using UnityEngine;
using Bullet;
using Interfaces.MVC;
using Interfaces.MVC.UnityEvents;

namespace Enemy.Gun
{
    public class GunServiceController : IController, IUpdate, IFixedUpdate
    {

        #region Fields

        private List<GunView> _gunViews;
        private List<GunController> _gunControllers = new List<GunController>();
        
        #endregion

        #region Constructors

        public GunServiceController(List<GunView> gunViews, BulletData bulletData, Transform playerTransform, Transform poolTransform)
        {

            _gunViews = gunViews;

            for(int i = 0; i < _gunViews.Count; i++)
            {

                _gunControllers.Add(new GunController(_gunViews[i], bulletData, playerTransform, poolTransform));

            };

        }

        #endregion

        #region Interfaces Methods

        public void OnUpdate(float deltaTime)
        {

            for(int i = 0; i < _gunControllers.Count; i++)
            {

                _gunControllers[i].OnUpdate(deltaTime);

            };

        }

        public void OnFixedUpdate()
        {

            for (int i = 0; i < _gunControllers.Count; i++)
            {

                _gunControllers[i].OnFixedUpdate();

            };

        }

        #endregion

    }

}