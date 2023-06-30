using System.Collections.Generic;
using UnityEngine;

namespace AG.DS
{
    [CreateAssetMenu(menuName = "### AG ###/Dialogue System/New Dialogue System Model")]
    public class DialogueSystemModel : ScriptableObject
    {
#if UNITY_EDITOR
        /// <summary>
        /// Is the dialogue editor window of this model has already been opened in the editor?
        /// </summary>
        /*[HideInInspector]*/ public bool IsOpened = false;
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