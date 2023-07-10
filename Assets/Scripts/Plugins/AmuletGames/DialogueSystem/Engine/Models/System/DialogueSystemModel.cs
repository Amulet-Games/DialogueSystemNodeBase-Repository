using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace AG.DS
{
    [CreateAssetMenu(menuName = "### AG ###/Dialogue System/New Dialogue System Model")]
    public class DialogueSystemModel : ScriptableObject
    {
#if UNITY_EDITOR
        /// <summary>
        /// The asset parent path of all dialogue system models.
        /// <br>If the dialogue system models are placed in a different directory, this path need to be updated as well.</br>
        /// </summary>
        public const string ASSET_DIRECTORY_PATH = "Assets/Scripts/Plugins/AmuletGames/DialogueSystem/Resources/DialogueSystemModel";


        /// <summary>
        /// The key to use when saving the dialogue editor window confirm status into the editor prefs.
        /// </summary>
        string DIALOGUE_EDITOR_WINDOW_OPEN_CONFIRM_KEY => $"{GetInstanceID()}_OPEN_CONFIRM_KEY";


        /// <summary>
        /// Is the dialogue editor window of this model has already been opened in the editor?
        /// </summary>
        public bool IsDsWindowAlreadyOpened
        {
            get
            {
                return EditorPrefs.GetBool(key: DIALOGUE_EDITOR_WINDOW_OPEN_CONFIRM_KEY);
            }
            private set
            {
                EditorPrefs.SetBool(key: DIALOGUE_EDITOR_WINDOW_OPEN_CONFIRM_KEY, value);
            }
        }

        /// <summary>
        /// Set a new value to the IsDsWindowAlreadyOpened property.
        /// </summary>
        /// <param name="value">The new value to set for.</param>
        public void SetIsDsWindowAlreadyOpened(bool value) => IsDsWindowAlreadyOpened = value;


        /// <summary>
        /// Delete the editor prefs's dialogue editor window open confirm key.
        /// </summary>
        public void DeleteOpenConfirmKey()
        {
            EditorPrefs.DeleteKey(DIALOGUE_EDITOR_WINDOW_OPEN_CONFIRM_KEY);
        }
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