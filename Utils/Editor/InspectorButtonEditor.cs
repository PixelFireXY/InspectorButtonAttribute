using UnityEngine;
using UnityEditor;
using System.Reflection;

[CustomEditor(typeof(MonoBehaviour), true)]
public class InspectorButtonEditor : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        SerializedProperty serializedProperty = serializedObject.GetIterator();
        while (serializedProperty.NextVisible(true))
        {
            FieldInfo field = serializedObject.targetObject.GetType().GetField(serializedProperty.name);
            if (field != null)
            {
                InspectorButtonAttribute[] attributes = (InspectorButtonAttribute[])field.GetCustomAttributes(typeof(InspectorButtonAttribute), false);
                if (attributes.Length > 0)
                {
                    InspectorButtonAttribute buttonAttribute = attributes[0];
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField(serializedProperty.name);

                    if (GUILayout.Button(buttonAttribute.ButtonName))
                    {
                        MonoBehaviour script = (MonoBehaviour)target;
                        MethodInfo method = script.GetType().GetMethod(buttonAttribute.MethodName);

                        if (method.GetParameters().Length == 0)
                            method.Invoke(script, null);
                        else
                            method.Invoke(script, buttonAttribute.Parameters);
                    }

                    EditorGUILayout.EndHorizontal();
                }
                else
                {
                    EditorGUILayout.PropertyField(serializedProperty);
                }
            }
        }
        serializedObject.ApplyModifiedProperties();
    }
}
