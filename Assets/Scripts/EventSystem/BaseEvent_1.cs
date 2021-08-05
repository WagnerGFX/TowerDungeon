using UnityEngine.Events;

namespace EventSystem
{
    /// <summary>
    /// To use a generic UnityEvent type you must override the generic type.
    /// </summary>
    [System.Serializable]
    public class BaseEvent<T> : UnityEvent<T> { }
}
