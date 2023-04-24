using UnityEngine;

namespace AG.DS
{
    [CreateAssetMenu(menuName = "### AG ###/Dialogue System/Config Resources Manager")]
    public class ConfigResourcesManager : ScriptableObject
    {
        /// <summary>
        /// The singleton reference of the class.
        /// </summary>
        public static ConfigResourcesManager Instance { get; private set; } = null;


        [Space(5)]
        /// <summary>
        /// The sprite config to use in the dialogue system.
        /// </summary>
        public SpriteConfig SpriteConfig;


        [Space(5)]
        /// <summary>
        /// The style sheet config to use in the dialogue system.
        /// </summary>
        public StyleSheetConfig StyleSheetConfig;


        /// <summary>
        /// The path of the class within the resources folder.
        /// <br>The path should always be "Resources/Config Resources Manager"</br>
        /// </summary>
        const string PATH = "Config Resources Manager";


        // ----------------------------- Setup -----------------------------
        /// <summary>
        /// Setup for the class.
        /// </summary>
        public static void Setup()
        {
            Instance ??= Resources.Load<ConfigResourcesManager>(PATH);
        }


        // ----------------------------- Dispose -----------------------------
        /// <summary>
        /// Dispose for the class.
        /// </summary>
        public void Dispose()
        {
            Instance = null;
        }
    }
}