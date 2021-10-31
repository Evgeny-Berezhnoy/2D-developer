using System.Collections.Generic;
using UnityEngine;
using Interfaces.MVC;

namespace Lifts
{

    public class LiftCollectionView : MonoBehaviour, ICollectionView<LiftView> 
    {

        #region Fields

        [SerializeField] private List<LiftView> _lifts;
        
        #endregion

        #region Properties

        public List<LiftView> CollectionView => _lifts;
        
        #endregion

    }


}