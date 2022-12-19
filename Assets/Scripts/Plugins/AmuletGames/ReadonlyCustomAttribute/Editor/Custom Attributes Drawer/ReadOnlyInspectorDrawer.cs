using UnityEditor;
using UnityEngine;

namespace AG
{
    /// <summary>
    /// This class contain custom drawer for ReadOnly attribute.
    /// </summary>
    [CustomPropertyDrawer(typeof(ReadOnlyInspectorAttribute))]
    public class ReadOnlyInspectorDrawer : PropertyDrawer
    {
        // ----------------------------- Callbacks -----------------------------
        /// <summary>
        /// Override this method to make your own IMGUI based GUI for the property.
        /// <br>Read More https://docs.unity3d.com/ScriptReference/PropertyDrawer.OnGUI.html</br>
        /// </summary>
        /// <param name="position">Rectangle on the screen to use for the property GUI.</param>
        /// <param name="property">The SerializedProperty to make the custom GUI for.</param>
        /// <param name="label">The label of this property.</param>
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            // Disabling edit for property
            GUI.enabled = false;

            // Drawing Property
            EditorGUI.PropertyField(position, property, label, true);

            // Setting old GUI enabled value
            GUI.enabled = true;
        }


        /// <summary>
        /// Override this method to specify how tall the GUI for this field is in pixels.
        /// <br>The default is one line high.</br>
        /// <br>Read More https://docs.unity3d.com/ScriptReference/PropertyDrawer.GetPropertyHeight.html</br>
        /// </summary>
        /// <param name="property">The SerializedProperty to make the custom GUI for.</param>
        /// <param name="label">The label of this property.</param>
        /// <returns></returns>
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property, label, true);
        }
    }
}