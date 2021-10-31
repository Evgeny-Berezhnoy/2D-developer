using UnityEngine;
using Game;
using Interfaces.MVC;
using Points;
using Controllers;

namespace Exit
{
    public class ExitInitializer : IGameInitializer
    {

        #region Fields

        private ExitServiceController _serviceController;

        #endregion

        #region Properties

        public ExitServiceController ServiceController => _serviceController;

        #endregion

        #region Constructors

        public ExitInitializer(ControllersList controllersList, ExitCollectionView collectionView, Transform poolTransform, GameRestarter gameRestarter)
        {

            _serviceController = new ExitServiceController(collectionView.Transforms, collectionView.Prefab, poolTransform, gameRestarter);

            controllersList.AddController(_serviceController);

        }

        #endregion


    }

}