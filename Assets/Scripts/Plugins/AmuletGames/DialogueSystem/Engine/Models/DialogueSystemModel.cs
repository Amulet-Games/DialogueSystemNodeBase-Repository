using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace AG.DS
{
    [CreateAssetMenu(menuName = "### AG ###/Dialogue System/Append Dialogue System Model")]
    public class DialogueSystemModel : ScriptableObject
    {
#if UNITY_EDITOR
        /// <summary>
        /// The asset parent path of all dialogue system models.
        /// <br>If the dialogue system models are placed in a different directory, this path need to be updated as well.</br>
        /// </summary>
        public const string ASSET_DIRECTORY_PATH = "Assets/Scripts/Plugins/AmuletGames/DialogueSystem/Resources/DialogueSystemModel";


        /// <summary>
        /// The key to use when saving the dialogue system window confirm status into the editor prefs.
        /// </summary>
        string DIALOGUE_SYSTEM_WINDOW_OPEN_CONFIRM_KEY => $"{GetInstanceID()}_OPEN_CONFIRM_KEY";


        /// <summary>
        /// Is the dialogue system window of this model has already been opened in the editor?
        /// </summary>
        public bool IsAlreadyOpened
        {
            get
            {
                return EditorPrefs.GetBool(key: DIALOGUE_SYSTEM_WINDOW_OPEN_CONFIRM_KEY);
            }
            set
            {
                EditorPrefs.SetBool(key: DIALOGUE_SYSTEM_WINDOW_OPEN_CONFIRM_KEY, value);
            }
        }


        /// <summary>
        /// Delete the editor prefs's dialogue system window open confirm key.
        /// </summary>
        public void DeleteOpenConfirmKey() => EditorPrefs.DeleteKey(DIALOGUE_SYSTEM_WINDOW_OPEN_CONFIRM_KEY);
#endif
        /// <summary>
        /// The property of the current dialogue system model asset's name.
        /// </summary>
        public string Name
        {
            get => name;
            set
            {
                AssetDatabase.RenameAsset(pathName: AssetDatabase.GetAssetPath(GetInstanceID()), value);
            }
        }


        /// <summary>
        /// The edge models cache.
        /// </summary>
        public List<EdgeModelBase> EdgeModels;


        /// <summary>
        /// The node models cache.
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