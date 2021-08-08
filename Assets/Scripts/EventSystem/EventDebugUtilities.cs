using System;
using System.Text;
using UnityEngine;
using UnityEngine.InputSystem;

namespace EventSystem
{
    public static class EventDebugUtilities
    {
        public static void DebugRaisedEventWithNoListeners(ScriptableObject eventChannel)
            => DebugRaisedEvent(eventChannel, null, null, null);
        public static void DebugRaisedEventWithNoListeners(ScriptableObject eventChannel, object value)
            => DebugRaisedEvent(eventChannel, value, null, null);
        public static void DebugRaisedEventWithNoListeners(ScriptableObject eventChannel, object value, object sender)
            => DebugRaisedEvent(eventChannel, value, sender, null);
        public static void DebugRaisedEvent(ScriptableObject eventChannel, Delegate[] invocationList)
            => DebugRaisedEvent(eventChannel, null, null, invocationList);
        public static void DebugRaisedEvent(ScriptableObject eventChannel, object value, Delegate[] invocationList)
            => DebugRaisedEvent(eventChannel, value, null, invocationList);

        public static void DebugRaisedEvent(ScriptableObject eventChannel, object value, object sender, Delegate[] invocationList)
        {
            var debugInfo = new StringBuilder();

            //Event Channel
            debugInfo.Append($"Raised Event Channel: {GetUnityObjectInfo(eventChannel)}");

            //Sender
            if (sender != null)
                debugInfo.Append($"\nSender: ");

            if (value != null && value is UnityEngine.Object)
                debugInfo.Append($"\nValue: {GetUnityObjectInfo(value)}");
            else if (value != null)
                debugInfo.Append($"\nValue: {value}");

            //Invocation List
            if (invocationList != null)
            {
                debugInfo.Append($"\nInvocation List:");

                foreach (Delegate del in invocationList)
                {
                    string targetOwnerInfo = GetUnityObjectInfo(del.Target);
                    debugInfo.Append($"\n    => {targetOwnerInfo}{del.Target.GetType().FullName} :: {del.Method}");
                }
            }

            Debug.Log(debugInfo.ToString());
        }

        private static string GetUnityObjectInfo(object target)
        {
            string ownerInfo = "";

            if (target is MonoBehaviour component)
                ownerInfo = $"[GO:{component.gameObject.name}#{component.gameObject.GetInstanceID()}] ";

            else if (target is GameObject gameObject)
                ownerInfo = $"[GO:{gameObject.name}#{gameObject.GetInstanceID()}] ";

            else if (target is ScriptableObject scriptableObject)
                ownerInfo = $"[SO:{scriptableObject.name}#{scriptableObject.GetInstanceID()}] ";

            else if (target is PlayerInput playerInput)
                ownerInfo = $"[PINPUT:{playerInput.name}#{playerInput.GetInstanceID()}] ";

            else if (target is UnityEngine.Object unityObject)
                ownerInfo = $"[OBJ:{unityObject.name}#{unityObject.GetInstanceID()}] ";

            else if (target is InputAction.CallbackContext context)
                ownerInfo = $"[INPUT:{context.action} <{context.action.phase}>]";

            return ownerInfo;
        }
    }
}
