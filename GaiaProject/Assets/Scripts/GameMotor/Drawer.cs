using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LegumeEngine;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
/*/
namespace Engine
{
    //*
    [CustomPropertyDrawer(typeof(LegumeManager.LegumeStruct),true)]
    class Drawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property,GUIContent content)
        {   
            //
            SerializedProperty sPropertyType = property.FindPropertyRelative("type");
            SerializedProperty sPropertyValue = property.FindPropertyRelative("value");
            position.width /= 2;
            EditorGUI.PropertyField(position, sPropertyType);
            position.x += position.width;

            EditorGUI.PropertyField(position, sPropertyValue);
            ///
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUIUtility.singleLineHeight;
        }
    }
    ///


}

//*/