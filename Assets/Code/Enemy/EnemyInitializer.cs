using UnityEngine;
using Enemy.Gun;
using Enemy.Zombie;
using Controllers;
using Game;
using Interfaces.MVC;

namespace Enemy
{

    public class EnemyInitializer : IGameInitializer
    {

        #region Fields

        private GunServiceController _gunServiceController;
        private ZombieServiceController _zombieServiceController;

        #endregion

        #region Constructors

        public EnemyInitializer(ControllersList controllersList, EnemyCollectionView enemyCollectionView, Transform playerTransform, Transform poolTransform, GameRestarter gameRestarter)
        {

            _gunServiceController       = new GunServiceController(enemyCollectionView.Guns, enemyCollectionView.BulletData, playerTransform, poolTransform, gameRestarter);
            _zombieServiceController    = new ZombieServiceController(enemyCollectionView.Zombies, playerTransform, gameRestarter);

            controllersList.AddController(_gunServiceController);
            controllersList.AddController(_zombieServiceController);

        }

        #endregion

    }

}