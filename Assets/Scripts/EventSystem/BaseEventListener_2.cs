using UnityEngine;


namespace EventSystem
{
    /// <summary>
    /// A flexible handler for events in the form of a MonoBehaviour. Responses can be connected directly from the Unity Inspector.
    /// The channel must be overrided with "new" to show valid ScriptableObjects in the Inspector.
    /// </summary>
    public abstract class BaseEventListener<TValue, TSender> : MonoBehaviour
    {
        [System.NonSerialized] // For editor errors with "new"
        protected EventChannelBaseSO<TValue, TSender> _channel = default;

        [SerializeField]
        protected BaseEvent<TValue, TSender> OnEventRaised;

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

        private void Respond(TValue value, TSender sender)
        {
            if (OnEventRaised != null)
                OnEventRaised.Invoke(value, sender);
        }
    }
}
