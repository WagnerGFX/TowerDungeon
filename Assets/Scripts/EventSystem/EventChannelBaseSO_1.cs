using UnityEngine;
using UnityEngine.Events;
using System.Linq;

namespace EventSystem
{
    public abstract class EventChannelBaseSO<T> : ScriptableObject
    {
#if UNITY_EDITOR
        [SerializeField] [TextArea]
        private string editorDescription;
#endif

        private event UnityAction<T> OnEventRaised;

        public void RaiseEvent(T value)
        {
            if (OnEventRaised != null)
            {
                OnEventRaised.Invoke(value);
                EventRaised(value);
            }
            else
                EventRaisedWithNoListeners(value);
        }

        public void Subscribe(UnityAction<T> action)
        {
            if (OnEventRaised != null && OnEventRaised.GetInvocationList() != null)
                if (OnEventRaised.GetInvocationList().Contains(action))
                    return;

            OnEventRaised += action;
            EventSubscribed(action);
        }

        public void Unsubscribe(UnityAction<T> action)
        {
            OnEventRaised -= action;
            EventUnsubscribed(action);
        }

        public void UnsubscribeAll()
        {
            if (OnEventRaised != null && OnEventRaised.GetInvocationList() != null)
            {
                foreach (System.Delegate eventDelegate in OnEventRaised.GetInvocationList())
                    OnEventRaised -= eventDelegate as UnityAction<T>;
            }

            EventListenersCleared();
        }

        protected virtual void EventRaised(T value) { }
        protected virtual void EventRaisedWithNoListeners(T value) { }
        protected virtual void EventSubscribed(UnityAction<T> action) { }
        protected virtual void EventUnsubscribed(UnityAction<T> action) { }
        protected virtual void EventListenersCleared() { }
    }
}