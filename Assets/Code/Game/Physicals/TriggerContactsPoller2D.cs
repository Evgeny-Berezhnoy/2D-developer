using UnityEngine;
using Constants.Physicals;

namespace Game.Physicals
{
    public class TriggerContactsPoller2D<T>
        where T : Collider2D
    {

        #region Fields

        private int _contactsCount = 0;

        private T _collider;
        private ContactFilter2D _filter;
        private Collider2D[] _colliders = new Collider2D[Physicals2D.COLLIDER_CONTACTS_AMOUNT];

        #endregion

        #region Properties

        public bool HasContacts => _contactsCount > 0;
        public Collider2D[] Colliders => _colliders;

        #endregion

        #region Constructors

        public TriggerContactsPoller2D(T collider, LayerMask layerMask)
        {

            _collider = collider;

            _filter = new ContactFilter2D();
            _filter.SetLayerMask(layerMask);

        }

        #endregion

        #region Methods

        public void Overlap()
        {

            _contactsCount = Physics2D.OverlapCollider(_collider, _filter, _colliders);

        }
        
        #endregion

    }

}