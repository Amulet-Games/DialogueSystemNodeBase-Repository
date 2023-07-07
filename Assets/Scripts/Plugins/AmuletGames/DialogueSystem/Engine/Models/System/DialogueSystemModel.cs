using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace AG.DS
{
    [CreateAssetMenu(menuName = "### AG ###/Dialogue System/New Dialogue System Model"), InitializeOnLoad]
    public class DialogueSystemModel : ScriptableObject
    {
#if UNITY_EDITOR

        string DIALOGUE_EDITOR_WINDOW_OPEN_CONFIRM_KEY => $"{GetInstanceID()}_IsOpened";

        /// <summary>
        /// Is the dialogue editor window of this model has already been opened in the editor?
        /// </summary>
        public bool IsOpened { get; private set; } = false;

        /// <summary>
        /// Set a new value to the IsOpened property.
        /// </summary>
        /// <param name="value">The value to set for.</param>
        public void SetIsOpened(bool value) => IsOpened = value;
#endif

        /// <summary>
        /// Cache of the edge models that will be serialized.
        /// </summary>
        public List<EdgeModelBase> EdgeModels;


        /// <summary>
        /// Cache of the node models that will be serialized.
        /// </summary>
        public List<NodeModelBase> NodeModels;


        /// <summary>
        /// Clear the node model cache.
        /// </summary>
        public void ClearNodeModels() => NodeModels.Clear();


        /// <summary>
        /// Clear the edge model cache.
        /// </summary>
        public void ClearEdgeModels() => EdgeModels.Clear();
    }
}