using System.Collections.Generic;
using UnityEngine;

namespace Death
{

    public class DeathZoneCollectionView : MonoBehaviour
    {

        #region Fields

        [SerializeField] private List<DeathZoneView> _deathZones;
        
        #endregion

        #region Properties

        public List<DeathZoneView> DeathZones => _deathZones;
        
        #endregion

    }

}