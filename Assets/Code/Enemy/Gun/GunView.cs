using UnityEngine;

namespace Enemy.Gun
{
    public class GunView : MonoBehaviour
    {

        #region Fields

        [SerializeField] private Transform _muzzle;
        [SerializeField] private Transform _projectileSpawnPoint;

        #endregion

        #region Properties

        public Transform Muzzle => _muzzle;
        public Transform ProjectileSpawnPoint => _projectileSpawnPoint;

        #endregion

    }

}