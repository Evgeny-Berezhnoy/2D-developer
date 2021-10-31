using System.Collections.Generic;
using UnityEngine;
using Bullet;
using Enemy.Gun;
using Enemy.Zombie;

namespace Enemy
{

    public class EnemyCollectionView : MonoBehaviour
    {

        #region Fields

        [SerializeField] private List<GunView> _guns;
        [SerializeField] private List<ZombieView> _zombies;
        [SerializeField] private BulletData _bulletData;

        #endregion

        #region Properties

        public List<GunView> Guns => _guns;
        public BulletData BulletData => _bulletData;
        public List<ZombieView> Zombies => _zombies;

        #endregion

    }

}