using UnityEngine;

namespace AG
{
    /// <summary>
    /// Read Only attribute. Use this attribute to mark any fields as readOnly properties
    /// <br>and user will become unable to edit their values from the inspector.</br>
    /// </summary>
    public class ReadOnlyInspectorAttribute : PropertyAttribute 
    {
    }
}