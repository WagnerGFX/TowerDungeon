using System;
using UnityEngine;
using UnityEditor;

namespace WagnerGFX.Utilities
{
    [CustomPropertyDrawer(typeof(ReadOnlyFieldAttribute))]
    public class ReadOnlyFieldDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty prop, GUIContent label)
        {
            ReadOnlyFieldAttribute readOnlyAttribute = (ReadOnlyFieldAttribute)attribute;

            //Disabled only during the drawing phase
            GUI.enabled = false;

            if (Application.isPlaying)
            {
                string valueStr = FormatValue(prop);
                EditorGUI.LabelField(position, label.text, valueStr);
            }
            else if (readOnlyAttribute.KeepPropertyVisible)
                EditorGUI.LabelField(position, label.text, "");

            GUI.enabled = true;
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            ReadOnlyFieldAttribute readOnlyAttribute = (ReadOnlyFieldAttribute)attribute;

            if (Application.isPlaying || readOnlyAttribute.KeepPropertyVisible)
                return base.GetPropertyHeight(property, label);
            else
                return 0f;
        }

        private string FormatValue(SerializedProperty prop)
        {
            string valueStr;
            string propType = CleanPropertyType(prop.type);

            switch (prop.propertyType)
            {
                case SerializedPropertyType.String:
                    valueStr = prop.stringValue;
                    break;
                case SerializedPropertyType.Boolean:
                    valueStr = prop.boolValue.ToString();
                    break;
                case SerializedPropertyType.Integer:
                    valueStr = prop.intValue.ToString();
                    break;
                case SerializedPropertyType.Float:
                    valueStr = prop.floatValue.ToString("##0.0#");
                    break;
                case SerializedPropertyType.Vector2:
                    valueStr = String.Format("{0} {1}", propType, prop.vector2Value.ToString());
                    break;
                case SerializedPropertyType.Vector2Int:
                    valueStr = String.Format("{0} {1}", propType, prop.vector2IntValue.ToString());
                    break;
                case SerializedPropertyType.Vector3:
                    valueStr = String.Format("{0} {1}", propType, prop.vector3Value.ToString());
                    break;
                case SerializedPropertyType.Vector3Int:
                    valueStr = String.Format("{0} {1}", propType, prop.vector3IntValue.ToString());
                    break;
                case SerializedPropertyType.Vector4:
                    valueStr = String.Format("{0} {1}", propType, prop.vector4Value.ToString());
                    break;
                case SerializedPropertyType.Quaternion:
                    valueStr = String.Format("{0} {1}", propType, prop.quaternionValue.ToString());
                    break;
                case SerializedPropertyType.Rect:
                    valueStr = String.Format("{0} {1}", propType, prop.rectValue.ToString());
                    break;
                case SerializedPropertyType.RectInt:
                    valueStr = String.Format("{0} {1}", propType, prop.rectIntValue.ToString());
                    break;
                case SerializedPropertyType.Bounds:
                    valueStr = prop.boundsValue.ToString();
                    break;
                case SerializedPropertyType.BoundsInt:
                    valueStr = prop.boundsIntValue.ToString();
                    break;
                case SerializedPropertyType.Enum:
                    valueStr = propType + prop.enumNames[prop.enumValueIndex];
                    break;

                case SerializedPropertyType.ObjectReference:
                    try
                    {
                        valueStr = prop.objectReferenceValue.ToString();
                    }
                    catch (NullReferenceException)
                    {
                        valueStr = String.Format("None ({0})", propType);
                    }
                    break;
                default:
                    valueStr = String.Format("Not Supported ({0})", propType);
                    Debug.LogWarning(String.Format("ReadOnlyField type not supported ({0})", propType), prop.serializedObject.targetObject);
                    break;
            }

            return valueStr;
        }

        private string CleanPropertyType(string propType)
        {
            return propType.Replace("PPtr<$", "").Replace(">", "");
        }
    } 
}