using UnityEngine;
using Enemy.Gun;
using Game;
using Interfaces.MVC;

namespace Enemy
{

    public class EnemyInitializer : IGameInitializer
    {

        #region Fields

        private GunServiceController _gunServiceController;

        #endregion

        #region Constructors

        public EnemyInitializer(ControllersList controllersList, EnemyCollectionView enemyCollectionView, Transform playerTransform, Transform poolTransform)
        {

            _gunServiceController = new GunServiceController(enemyCollectionView.Guns, enemyCollectionView.BulletData, playerTransform, poolTransform);

            controllersList.AddController(_gunServiceController);

        }

        #endregion

    }

}