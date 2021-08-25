using System;
using UnityEngine;

namespace WagnerGFX.Utilities
{
    /// <summary>
    /// Makes the field not editable in inspector. The value is only visible during Play mode.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class ReadOnlyFieldAttribute : PropertyAttribute
    {
        public bool KeepPropertyVisible { get; private set; }
        public ReadOnlyFieldAttribute(bool keepPropertyVisible = true)
        {
            KeepPropertyVisible = keepPropertyVisible;
        }
    } 
}