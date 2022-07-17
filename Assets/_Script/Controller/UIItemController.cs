using UnityEngine;

namespace StreetTrade
{
    public class UIItemController<T> : MonoBehaviour where T : class
    {
        private T item;
        public T Item
        {
            get { return item; }
            set
            {
                RemoveOldAction();
                item = value;
                OnChangeValue();
            }
        }

        protected virtual void RemoveOldAction()
        {

        }

        protected virtual void OnChangeValue()
        {

        }

        protected virtual void OnDisable()
        {
            RemoveOldAction();
        }
    }
}
