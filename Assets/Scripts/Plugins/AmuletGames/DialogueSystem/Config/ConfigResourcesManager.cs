using UnityEngine;

namespace AG.DS
{
    [CreateAssetMenu(menuName = "### AG ###/Dialogue System/Config Resources Manager")]
    public class ConfigResourcesManager : ScriptableObject
    {
        [SerializeField] private SpriteConfig spriteConfig;
        [SerializeField] private StyleSheetConfig styleSheetConfig;


        /// <summary>
        /// The singleton reference of the class.
        /// </summary>
        public static ConfigResourcesManager Instance { get; private set; } = null;


        /// <summary>
        /// The sprite config to use in the dialogue system.
        /// </summary>
        public static SpriteConfig SpriteConfig => Instance.spriteConfig;


        /// <summary>
        /// The style sheet config to use in the dialogue system.
        /// </summary>
        public static StyleSheetConfig StyleSheetConfig => Instance.styleSheetConfig;


        /// <summary>
        /// The path of the class within the resources folder.
        /// <br>The path should always be "Resources/Config Resources Manager"</br>
        /// </summary>
        const string PATH = "Config Resources Manager";


        /// <summary>
        /// Setup for the class.
        /// </summary>
        public static void Setup()
        {
            Instance = Instance != null ? Instance : Resources.Load<ConfigResourcesManager>(PATH);
        }
    }
}