using UnityEngine;
using UnityEngine.Events;
using System.Linq;

namespace EventSystem
{
    public abstract class EventChannelBaseSO : ScriptableObject
    {
#if UNITY_EDITOR
        [SerializeField] [TextArea]
        private string editorDescription;
#endif

        private event UnityAction OnEventRaised;

        public void RaiseEvent()
        {
            if (OnEventRaised != null)
            {
                OnEventRaised.Invoke();
                EventRaised();
            }
            else
                EventRaisedWithNoListeners();
        }

        public void Subscribe(UnityAction action)
        {
            if (OnEventRaised != null && OnEventRaised.GetInvocationList() != null)
                if (OnEventRaised.GetInvocationList().Contains(action))
                    return;

            OnEventRaised += action;
            EventSubscribed(action);
        }

        public void Unsubscribe(UnityAction action)
        {
            OnEventRaised -= action;
            EventUnsubscribed(action);
        }

        public void UnsubscribeAll()
        {
            if (OnEventRaised != null && OnEventRaised.GetInvocationList() != null)
            {
                foreach (System.Delegate eventDelegate in OnEventRaised.GetInvocationList())
                    OnEventRaised -= eventDelegate as UnityAction;
            }
            EventListenersCleared();
        }

        protected virtual void EventRaised() { }
        protected virtual void EventRaisedWithNoListeners() { }
        protected virtual void EventSubscribed(UnityAction action) { }
        protected virtual void EventUnsubscribed(UnityAction action) { }
        protected virtual void EventListenersCleared() { }
    } 
}