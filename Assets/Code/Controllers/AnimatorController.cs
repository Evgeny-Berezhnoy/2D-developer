using UnityEngine;
using Interfaces.Components;
using Interfaces.MVC;

namespace Controllers
{
    public abstract class AnimatorController : IController, IAnimated
    {

        #region Fields

        protected Animator _animator;

        #endregion

        #region Properties

        public Animator Animator { get => _animator; protected set => _animator = value; }

        #endregion

        #region Constructors

        public AnimatorController(Animator animator)
        {

            _animator = animator;

        }
        
        #endregion

        #region Interfaces

        public virtual void SetParameter(string parameter, int value)
        {

            _animator.SetInteger(parameter, value);

        }

        public virtual void SetParameter(string parameter, float value)
        {

            _animator.SetFloat(parameter, value);
            
        }

        public virtual void SetParameter(string parameter, bool value)
        {

            _animator.SetBool(parameter, value);

        }

        public virtual void SetTrigger(string parameter)
        {

            _animator.SetTrigger(parameter);

        }

        #endregion

    }

}