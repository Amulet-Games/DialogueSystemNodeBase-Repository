using UnityEditor;
using UnityEngine;

namespace AG.DS
{
    public class DialogueSystemWindow : EditorWindow
    {
        /// <summary>
        /// Reference of the dialogue system window asset.
        /// </summary>
        public DialogueSystemWindowAsset Asset { get; private set; }


        /// <summary>
        /// Reference of the dialogue system window data.
        /// </summary>
        DialogueSystemWindowData data;


        /// <summary>
        /// Reference of the headbar element.
        /// </summary>
        public Headbar Headbar { get; private set; }


        /// <summary>
        /// Reference of the graph viewer element.
        /// </summary>
        public GraphViewer GraphViewer { get; private set; }


        /// <summary>
        /// Reference of the undo redo handler.
        /// </summary>
        UndoRedoHandler undoRedoHandler;


        /// <summary>
        /// Reference of the serialize handler.
        /// </summary>
        SerializeHandler serializeHandler;


        /// <summary>
        /// Reference of the language handler.
        /// </summary>
        LanguageHandler languageHandler;


        /// <summary>
        /// This is called when the scripts are reloaded and after OnDisable.
        /// <br>Also when the window is first opened in <see cref="EditorWindow.CreateWindow{T}(System.Type[])"/>.</br>
        /// </summary>
        void OnEnable() => DialogueSystemWindowCallback.OnEnable(window: this);


        /// <summary>
        /// This is called when the scripts are reloaded and before OnEnable.
        /// <br>Also when the window is about to close before OnDestroy is called.</br>
        /// </summary>
        void OnDisable() => DialogueSystemWindowCallback.OnDisable(GraphViewer);


        /// <summary>
        /// This is called when the window is closed and can be used to cleanup any static references.
        /// </summary>
        void OnDestroy() => DialogueSystemWindowCallback.OnDestroy(window: this);


        /// <summary>
        /// Init of the dialogue system window.
        /// Logic here should only be executed once.
        /// </summary>
        /// <param name="asset">The dialogue system window asset to set for.</param>
        public void Init(DialogueSystemWindowAsset asset)
        {
            Asset = asset;
            asset.IsAlreadyOpened = true;
            data = asset.Data;
        }


        /// <summary>
        /// Setup for the dialogue system window class.
        /// </summary>
        public void Setup()
        {
            // Setup static classes
            {
                LanguageProvider.Setup();
                SearchTreeEntryProvider.Setup();
            }

            // Setup singletons
            {
                ConfigResourcesManager.Setup();
                HotkeyManager.Setup();
                NodeManager.Setup();
            }

            // Create modules
            {
                // Language Handler
                {
                    languageHandler = LanguageHandlerFactory.Generate();
                }

                // Serialize Handler
                {
                    serializeHandler = SerializeHandlerFactory.Generate();
                }

                // Headbar
                {
                    Headbar = HeadbarFactory.Generate(languageHandler, dialogueSystemWindowAsset: Asset, dialogueSystemWindow: this);
                }

                // Graph Viewer
                {
                    GraphViewer = GraphViewerFactory.Generate(languageHandler, dialogueSystemWindow: this);
                }
            }

            // Add modules to graph
            {
                rootVisualElement.Add(GraphViewer);
                rootVisualElement.Add(Headbar);
            }
        }


        // ----------------------------- Override -----------------------------
        /// <summary>
        /// Performs a save action on the contents of the window.
        /// <br>The method is override to include saving all the visual elements in this window.</br>
        /// <para>Read More https://docs.unity3d.com/ScriptReference/EditorWindow.SaveChanges.html</para>
        /// </summary>
        public override void SaveChanges() => Save();


        // ----------------------------- Service -----------------------------
        /// <summary>
        /// Save all the graph elements on the custom graph editor.
        /// </summary>
        public void Save()
        {
            if (hasUnsavedChanges)
            {
                serializeHandler.Save(Asset, data, GraphViewer);
                SaveChangesToAssetDatabase();
            }
            else
            {
                Debug.LogWarning(StringConfig.Editor_WindowAlreadySaved_WarningText);
            }
        }


        /// <summary>
        /// Load the saved graph elements and create them again on the graph.
        /// </summary>
        public void Load(bool isForceLoadWindow)
        {
            if (isForceLoadWindow || hasUnsavedChanges)
            {
                GraphViewer.ClearGraph();

                languageHandler.ClearCache();

                serializeHandler.Load(Asset, data, GraphViewer, languageHandler);

                SaveChangesToAssetDatabase();
            }
            else
            {
                Debug.LogWarning(StringConfig.Editor_WindowAlreadyLoaded_WarningText);
            }
        }


        /// <summary>
        /// Rename the dialogue system window.
        /// </summary>
        /// <param name="value">The new dialogue system window's name to set for.</param>
        public void RenameWindow(string value)
        {
            Asset.Name = value;
            SaveChangesToAssetDatabase();
        }


        /// <summary>
        /// Change the language of the dialogue system window.
        /// </summary>
        /// <param name="value">The new language type to set for.</param>
        public void ChangeLanguage(LanguageType value)
        {
            languageHandler.CurrentLanguage = value;
            WindowChangedEvent.Invoke();
        }


        /// <summary>
        /// Save the window changes to the asset database.
        /// </summary>
        void SaveChangesToAssetDatabase()
        {
            AssetDatabase.SaveAssets();
            hasUnsavedChanges = false;
        }


        /// <summary>
        /// The event to invoke when there are new changes happened to the dialogue system window.
        /// </summary>
        public void DialogueSystemWindowChangedEvent()
        {
            if (hasFocus)
            {
                hasUnsavedChanges = true;
            }
        }
    }
}