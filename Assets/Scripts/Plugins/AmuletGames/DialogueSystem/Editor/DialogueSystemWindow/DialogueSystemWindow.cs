using System;
using UnityEditor;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

namespace AG.DS
{
    public class DialogueSystemWindow : EditorWindow
    {
        /// <summary>
        /// Reference of the dialogue system window asset.
        /// </summary>
        DialogueSystemWindowAsset asset;


        /// <summary>
        /// Reference of the dialogue system window data.
        /// </summary>
        DialogueSystemWindowData data;


        /// <summary>
        /// Reference of the graph viewer element.
        /// </summary>
        GraphViewer graphViewer;


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
        /// The property of the dialogue system window's hasUnsavedChanges value.
        /// </summary>
        public bool HasUnsavedChanges
        {
            get => hasUnsavedChanges;
            set => hasUnsavedChanges = value;
        }


        /// <summary>
        /// The event to invoke to write all the unsaved changes to the disk.
        /// </summary>
        public event Action ApplyChangesToDiskEvent;


        /// <summary>
        /// The event to invoke when the dialogue system window's OnDisable is called.
        /// </summary> 
        public event Action WindowOnDisableEvent;


        /// <summary>
        /// The event to invoke when the dialogue system window's OnDestroy is called.
        /// </summary> 
        public event Action WindowOnDestroyEvent;


        /// <summary>
        /// This is called when the scripts are reloaded and after OnDisable.
        /// <br>Also when the window is first opened in <see cref="EditorWindow.CreateWindow{T}(System.Type[])"/>.</br>
        /// </summary>
        void OnEnable()
        {
            if (asset == null)
                return;

            Setup();

            Load(isForceLoadWindow: true);

            graphViewer.ReframeGraphOnGeometryChanged(
                geometryChangedElement: rootVisualElement,
                frameType: FrameType.All
            );
        }


        /// <summary>
        /// This is called when the scripts are reloaded and before OnEnable.
        /// <br>Also when the window is about to close before OnDestroy is called.</br>
        /// </summary>
        void OnDisable() => WindowOnDisableEvent.Invoke();


        /// <summary>
        /// This is called when the window is closed and can be used to cleanup any static references.
        /// </summary>
        void OnDestroy() => WindowOnDestroyEvent.Invoke();


        /// <summary>
        /// Init of the dialogue system window.
        /// Logic here should only be executed once.
        /// </summary>
        /// <param name="asset">The dialogue system window asset to set for.</param>
        public void Init(DialogueSystemWindowAsset asset)
        {
            this.asset = asset;
            asset.IsAlreadyOpened = true;

            data = asset.Data;
        }


        /// <summary>
        /// Setup for the dialogue system window class.
        /// </summary>
        public void Setup()
        {
            Headbar headBar;

            NodeCreateRequestWindow nodeCreateRequestWindow;

            // Setup static classes
            {
                LanguageProvider.Setup();
                NodeCreateEntryProvider.Setup();
            }

            // Setup singletons
            {
                ConfigResourcesManager.Setup();
                HotkeyManager.Setup();
                EdgeManager.Setup();
                NodeManager.Setup();
                NodeCreateWindowManager.Setup();
                PortManager.Setup();
            }

            // Create modules
            {
                // Language Handler
                {
                    languageHandler = new();
                }

                // Serialize Handler
                {
                    serializeHandler = new();
                }

                // Headbar
                {
                    headBar = HeadbarPresenter.CreateElement(languageHandler, asset);
                }

                // Graph Viewer
                {
                    graphViewer = GraphViewerPresenter.CreateElement(languageHandler, dialogueSystemWindow: this);
                }

                // Input Hint
                {
                    InputHint.Instance = InputHintPresenter.CreateElement(graphViewer);
                }

                // Search Windows
                {
                    nodeCreateRequestWindow =
                        NodeCreateWindowManager.Instance.CreateRequestWindow(graphViewer, languageHandler, dialogueSystemWindow: this);

                    graphViewer.NodeCreateDefaultConnectorWindow =
                        NodeCreateWindowManager.Instance.CreateDefaultConnectorWindow(graphViewer, languageHandler, dialogueSystemWindow: this);

                    graphViewer.NodeCreateOptionConnectorWindow = 
                        NodeCreateWindowManager.Instance.CreateOptionConnectorWindow(graphViewer, languageHandler, dialogueSystemWindow: this);
                }
            }

            // Add modules to graph
            {
                graphViewer.contentViewContainer.Add(InputHint.Instance);
                rootVisualElement.Add(graphViewer);
                rootVisualElement.Add(headBar);
            }

            // Register modules events
            {
                new GraphViewerObserver(graphViewer, dialogueSystemWindow: this).RegisterEvents();

                new HeadbarObserver(headBar, dialogueSystemWindow: this).RegisterEvents();

                new DialogueSystemWindowObserver(asset, graphViewer, headBar, dialogueSystemWindow: this).RegisterEvents();
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
                serializeHandler.Save(asset, data, graphViewer);

                ApplyChangesToDiskEvent.Invoke();
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
                graphViewer.ClearGraph();

                languageHandler.ClearCache();

                serializeHandler.Load(asset, data, graphViewer, languageHandler);

                ApplyChangesToDiskEvent.Invoke();
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
            asset.Name = value;

            ApplyChangesToDiskEvent.Invoke();
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
    }
}