using UnityEngine;

namespace EventSystem
{
    /// <summary>
    /// A flexible handler for events in the form of a MonoBehaviour. Responses can be connected directly from the Unity Inspector.
    /// </summary>
    public abstract class BaseEventListener<T> : MonoBehaviour
    {
        /// <summary>
        /// Must be overrided with "new" to show valid ScriptableObjects in the Inspector.
        /// </summary>
        [System.NonSerialized] // For editor errors with "new"
        protected EventChannelBaseSO<T> _channel = default;

        [SerializeField]
        protected BaseEvent<T> OnEventRaised;

        private void OnEnable()
        {
            if (_channel != null)
                _channel?.Subscribe(Respond);
        }

        private void OnDisable()
        {
            if (_channel != null)
                _channel?.Unsubscribe(Respond);
        }

        private void Respond(T value)
        {
            if (OnEventRaised != null)
                OnEventRaised.Invoke(value);
        }
    }
}
