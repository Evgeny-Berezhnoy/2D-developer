using UnityEngine;

namespace Lifts
{

    [RequireComponent(typeof(SliderJoint2D))]
    public class LiftView : MonoBehaviour
    {

        #region Fields

        [SerializeField] private float _maxUpperTranslation;
        [SerializeField] private SliderJoint2D _slider;

        #endregion

        #region Properties

        public float MaxUpperTranslation => _maxUpperTranslation;
        public SliderJoint2D Slider => _slider;

        #endregion

    }

}