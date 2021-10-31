using UnityEngine;
using Game;
using Interfaces.MVC;

namespace Torches
{

    public class TorchInitializer : IGameInitializer
    {

        #region Fields

        private TorchServiceController _torchServiceController;

        #endregion

        #region Properties

        public TorchServiceController ServiceController => _torchServiceController;
        
        #endregion

        #region Constructors

        public TorchInitializer(ControllersList controllersList, TorchCollectionView coinCollectionView, Transform poolTransform)
        {

            _torchServiceController = new TorchServiceController(coinCollectionView.Torches, poolTransform, coinCollectionView.Prefab);

            controllersList.AddController(_torchServiceController);

        }

        #endregion

    }

}