using System.Collections.Generic;
using UnityEngine;
using Interfaces.MVC;

namespace Death
{

    public class DeathZoneCollectionView : MonoBehaviour, ICollectionView<DeathZoneView>
    {

        #region Fields

        [SerializeField] private List<DeathZoneView> _deathZones;
        
        #endregion

        #region Properties

        public List<DeathZoneView> CollectionView => _deathZones;
        
        #endregion

    }

}