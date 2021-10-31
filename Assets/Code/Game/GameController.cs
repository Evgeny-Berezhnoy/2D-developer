using System.Collections.Generic;
using UnityEngine;
using Coins;
using Controllers;
using Death;
using Enemy;
using Exit;
using Interfaces.Quests;
using Lifts;
using Player;
using Points;
using Quests;
using Torches;

namespace Game
{
    public class GameController : MonoBehaviour
    {

        #region Fields

        [Header("Transforms")]
        [SerializeField] private Transform _pool;
        [SerializeField] private Transform _playerTransform;

        [Header("Model")]
        [SerializeField] private QuestData _questData;

        [Header("Views")]
        [SerializeField] private PlayerView _player;
        [SerializeField] private PointsView _points;
        [SerializeField] private EnemyCollectionView _enemies;
        [SerializeField] private CoinCollectionView _coins;
        [SerializeField] private DeathZoneCollectionView _deathZones;
        [SerializeField] private LiftCollectionView _lifts;
        [SerializeField] private TorchCollectionView _torches;
        [SerializeField] private ExitCollectionView _exits;

        private ControllersList _controllersList;
        private GameRestarter _gameRestarter;
        
        private PointsInitializer _pointsInitializer;
        private PlayerInitializer _playerInitializer;
        private EnemyInitializer _enemyInitializer;
        private CoinInitializer _coinInitializer;
        private DeathZoneInitializer _deathZoneInitializer;
        private LiftInitializer _liftInitializer;
        private TorchInitializer _torchInitializer;
        private ExitInitializer _exitInitializer;
        private QuestInitializer _questInitializer;

        #endregion

        #region Events

        public void Start()
        {

            _controllersList        = new ControllersList();

            _gameRestarter          = new GameRestarter();

            _pointsInitializer      = new PointsInitializer(_controllersList, _points, _gameRestarter);
            _playerInitializer      = new PlayerInitializer(_controllersList, _playerTransform, _player, _gameRestarter);
            _enemyInitializer       = new EnemyInitializer(_controllersList, _enemies, _player.transform, _pool, _gameRestarter);
            _coinInitializer        = new CoinInitializer(_controllersList, _coins, _pool, _pointsInitializer.PointsController);
            _deathZoneInitializer   = new DeathZoneInitializer(_controllersList, _deathZones, _gameRestarter);
            _liftInitializer        = new LiftInitializer(_controllersList, _lifts);
            _torchInitializer       = new TorchInitializer(_controllersList, _torches, _pool);
            _exitInitializer        = new ExitInitializer(_controllersList, _exits, _pool, _gameRestarter);

            var questSubscribers = new List<IQuestSubscriber>();

            questSubscribers.Add(_coinInitializer.ServiceController);
            questSubscribers.Add(_torchInitializer.ServiceController);
            questSubscribers.Add(_exitInitializer.ServiceController);

            _questInitializer = new QuestInitializer(_controllersList, _questData, questSubscribers, _gameRestarter);
            
        }

        public void Update()
        {

            _controllersList.OnUpdate(Time.deltaTime);

        }

        public void FixedUpdate()
        {

            _controllersList.OnFixedUpdate(Time.fixedDeltaTime);

        }

        #endregion

    }

}
