using System.Collections.Generic;
using UnityEngine;
using Enemy.Gun;
using Bullet;

namespace Enemy
{
    public class EnemyCollectionView : MonoBehaviour
    {

        #region Fields

        [SerializeField] private List<GunView> _guns;
        [SerializeField] private BulletData _bulletData;

        #endregion

        #region Properties

        public List<GunView> Guns => _guns;
        public BulletData BulletData => _bulletData;

        #endregion

    }

}