using UnityEngine;
using Enemy;
using Bullet;
using Player;

namespace Game
{
    public class GameController : MonoBehaviour
    {

        #region Fields

        [SerializeField] private PlayerView _player;
        [SerializeField] private EnemyCollectionView _enemies;
        [SerializeField] private Transform _pool;

        private ControllersList _controllersList;

        private PlayerInitializer _playerInitializer;
        private EnemyInitializer _enemyInitializer;

        #endregion

        #region Events

        public void Start()
        {

            _controllersList    = new ControllersList();

            _playerInitializer  = new PlayerInitializer(_controllersList, _player);
            _enemyInitializer   = new EnemyInitializer(_controllersList, _enemies, _player.transform, _pool);

        }

        public void Update()
        {

            _controllersList.OnUpdate(Time.deltaTime);

        }

        public void FixedUpdate()
        {

            _controllersList.OnFixedUpdate();

        }

        #endregion

    }

}
