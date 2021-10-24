using System.Collections.Generic;
using UnityEngine;

namespace Lifts
{

    public class LiftCollectionView : MonoBehaviour
    {

        #region Fields

        [SerializeField] private List<LiftView> _lifts;
        
        #endregion

        #region Properties

        public List<LiftView> Lifts => _lifts;
        
        #endregion

    }


}
