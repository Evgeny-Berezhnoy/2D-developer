using System.Collections.Generic;
using UnityEngine;

namespace Interfaces.MVC
{

    public interface ICollectionView<T>
    {

        #region Properties

        List<T> CollectionView { get; }

        #endregion

    }

}