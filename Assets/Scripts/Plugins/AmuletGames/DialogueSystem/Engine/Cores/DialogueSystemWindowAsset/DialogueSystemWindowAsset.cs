using UnityEditor;
using UnityEngine;

namespace AG.DS
{
    [CreateAssetMenu(menuName = "### AG ###/Dialogue System/Dialogue System Window Asset")]
    public class DialogueSystemWindowAsset : ScriptableObject
    {
#if UNITY_EDITOR
        /// <summary>
        /// The key to use when saving the dialogue system window confirm status into the editor prefs.
        /// </summary>
        public string DIALOGUE_SYSTEM_WINDOW_OPEN_CONFIRM_KEY => $"{GetInstanceID()}_OPEN_CONFIRM_KEY";


        /// <summary>
        /// Is the asset's window has already been opened in the editor?
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
#endif
        /// <summary>
        /// The property of the asset's name.
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                AssetDatabase.RenameAsset(pathName: AssetDatabase.GetAssetPath(GetInstanceID()), newName: value);
            }
        }


        /// <summary>
        /// The property of the dialogue system window data reference.
        /// </summary>
        public DialogueSystemWindowData Data => m_data;


        /// <summary>
        /// Reference of the dialogue system window data.
        /// </summary>
        [SerializeField] DialogueSystemWindowData m_data;


        /// <summary>
        /// Constructor of the dialogue system window asset.
        /// </summary>
        public DialogueSystemWindowAsset()
        {
            m_data ??= new();
        }
    }
}