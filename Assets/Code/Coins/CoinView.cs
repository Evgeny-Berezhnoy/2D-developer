using UnityEngine;

namespace Coins
{

    [RequireComponent(typeof(CircleCollider2D))]
    public class CoinView : MonoBehaviour
    {

        #region Fields

        [Header("Components")]
        [SerializeField] private CircleCollider2D _collider;

        #endregion

        #region Properties

        public CircleCollider2D Collider => _collider;
        
        #endregion

    }

}