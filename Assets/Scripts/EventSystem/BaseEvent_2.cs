using UnityEngine.Events;

namespace EventSystem
{
    /// <summary>
    /// To use a generic UnityEvent type you must override the generic types.
    /// </summary>
    [System.Serializable]
    public class BaseEvent<TValue, TSender> : UnityEvent<TValue, TSender> { }
}
