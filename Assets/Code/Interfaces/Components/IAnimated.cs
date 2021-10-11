using UnityEngine;

namespace Interfaces.Components
{

    public interface IAnimated
    {

        #region Properties

        Animator Animator { get; }

        #endregion

        #region Methods

        void SetParameter(string parameter, int value);
        void SetParameter(string parameter, float value);
        void SetParameter(string parameter, bool value);
        void SetTrigger(string parameter);

        #endregion

    }

}