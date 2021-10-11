using UnityEngine;

namespace Bullet
{

    [CreateAssetMenu(fileName = "Bullet data", menuName = "Scriptable objects/Bullet data")]
    public class BulletData : ScriptableObject
    {

        #region Fields

        [SerializeField] private int _bulletsAmount;
        [SerializeField] private float _cooldown;
        [SerializeField] private float _speed;
        [SerializeField] private BulletView _prefab;

        #endregion

        #region Properties

        public int BulletsAmount => _bulletsAmount;
        public float Cooldown => _cooldown;
        public float Speed => _speed;
        public BulletView Prefab => _prefab;

        #endregion

    }

}