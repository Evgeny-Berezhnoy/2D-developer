using UnityEngine;
using UnityEngine.UI;

namespace Points
{

    [RequireComponent(typeof(Text))]
    public class PointsView : MonoBehaviour
    {

        #region Fields

        [SerializeField] private Text _text;

        #endregion

        #region Properties

        public Text Text => _text;

        #endregion

    }

}
