﻿using System;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;
using Object = UnityEngine.Object;

namespace AG.DS
{
    public class DialogueEditorWindow : EditorWindow
    {
        /// <summary>
        /// Reference of the dialogue system data.
        /// </summary>
        DialogueSystemData dsData;


        /// <summary>
        /// Reference of the graph viewer element.
        /// </summary>
        GraphViewer graphViewer;


        /// <summary>
        /// Reference of the headBar element.
        /// </summary>
        HeadBar headBar;


        /// <summary>
        /// Reference of the undo redo handler.
        /// </summary>
        UndoRedoHandler undoRedoHandler;


        /// <summary>
        /// Reference of the serialize handler.
        /// </summary>
        SerializeHandler serializeHandler;


        /// <summary>
        /// Reference of the node create request window.
        /// </summary>
        NodeCreateRequestWindow nodeCreateRequestWindow;


        /// <summary>
        /// The event to invoke when the user clicked the save button in the headBar element.
        /// </summary>
        public event Action<DialogueSystemData> SaveToDSDataEvent;


        /// <summary>
        /// The event to invoke when the dialogue editor window is first opened,
        /// <br>or when the user clicked the load button in the headBar element.</br>
        /// </summary>
        public event Action<DialogueSystemData> LoadFromDSDataEvent;


        /// <summary>
        /// The event to invoke to write all the unsaved changes to the disk.
        /// </summary>
        public event Action ApplyChangesToDiskEvent;


        /// <summary>
        /// The event to invoke when the dialogue editor window's OnEnable is called.
        /// </summary> 
        public event Action WindowOnEnableEvent;


        /// <summary>
        /// The event to invoke when the dialogue editor window's OnDisable is called.
        /// </summary> 
        public event Action WindowOnDisableEvent;


        /// <summary>
        /// The event to invoke when the dialogue editor window's OnDestroy is called.
        /// </summary> 
        public event Action WindowOnDestroyEvent;


        /// <summary>
        /// This is called when the scripts are reloaded and after OnDisable.
        /// <br>Also when the window is first opened in <see cref="EditorWindow.CreateWindow{T}(System.Type[])"/>.</br>
        /// </summary>
        void OnEnable() => WindowOnEnableEvent?.Invoke();


        /// <summary>
        /// This is called when the scripts are reloaded and before OnEnable.
        /// <br>Also when the window is about to close before OnDestroy is called.</br>
        /// </summary>
        void OnDisable() => WindowOnDisableEvent.Invoke();


        /// <summary>
        /// This is called when the window is closed and can be used to cleanup any static references.
        /// </summary>
        void OnDestroy() => WindowOnDisableEvent.Invoke();


        /// <summary>
        /// Initialize for the class.
        /// </summary>
        /// <param name="dsData">The dialogue system data to set for.</param>
        public void Initialize(DialogueSystemData dsData)
        {
            // Connecting data
            this.dsData = dsData;

            // Initialize singletons
            {
                ConfigResourcesManager.Initialize();
                LanguageManager.Initialize();
                HotkeyManager.Initialize();
                EdgeManager.Initialize();
                NodeManager.Initialize();
            }

            // Continue with setup.
            Setup();
        }


        /// <summary>
        /// Setup for the class.
        /// </summary>
        public void Setup()
        {
            // Create modules
            {
                // Graph Viewer
                graphViewer = GraphViewerPresenter.CreateElement(dsWindow: this);

                // HeadBar
                headBar = HeadBarPresenter.CreateElement(dsData);

                // Input Hint
                InputHint.Instance = InputHintPresenter.CreateElement(graphViewer);

                // Serialize Handler
                serializeHandler = new(graphViewer);

                // Node Create Window
                var nodeCreateDetails = new NodeCreateDetails();

                nodeCreateRequestWindow =
                    NodeCreateRequestWindowPresenter.CreateWindow(graphViewer, nodeCreateDetails, dsWindow: this);

                graphViewer.NodeCreateConnectorWindow =
                    NodeCreateConnectorWindowPresenter.CreateWindow(graphViewer, nodeCreateDetails, dsWindow: this);

                NodeCreateEntryProvider.SetupNodeCreateWindowEntries();

                //Debug.Log("graphViewer = " + graphViewer);
                //Debug.Log("dsWindow = " + dsWindow == null);
                //Debug.Log("nodeCreateRequestWindow = " + nodeCreateRequestWindow == null);
                //Debug.Log("graphViewer.NodeCreateConnectorWindow = " + graphViewer.NodeCreateConnectorWindow == null);
            }

            // Add modules to graph
            {
                rootVisualElement.Add(graphViewer);
                rootVisualElement.Add(headBar);

                graphViewer.contentViewContainer.Add(InputHint.Instance);
            }

            // Register modules events
            {
                var graphViewerCallback = new GraphViewerCallback(graphViewer, nodeCreateRequestWindow, dsWindow: this);
                graphViewerCallback.SetCallbacks();
                graphViewerCallback.RegisterEvents();

                new HeadBarCallback(headBar, dsData.GetInstanceID(), dsWindow: this).RegisterEvents();

                new DialogueEditorWindowCallback(
                    dsData, graphViewer, headBar,
                    serializeHandler, nodeCreateRequestWindow, dsWindow: this).RegisterEvents();

                new NodeCreateRequestWindowCallback(nodeCreateRequestWindow, dsWindow: this);
                new NodeCreateConnectorWindowCallback(graphViewer.NodeCreateConnectorWindow, dsWindow: this);
            }
        }


        // ----------------------------- Get Window -----------------------------
        /// <summary>
        /// Callback attribute for opening an asset in Unity (e.g the callback is fired when double clicking an asset in the Project Browser).
        /// <para>Read More https://docs.unity3d.com/2020.1/Documentation/ScriptReference/Callbacks.OnOpenAssetAttribute.html</para>
        /// </summary>
        /// <param name="instanceId">The instance id of the opened asset. Required parameter for the callback attribute.</param>
        /// <param name="line">Can be ignored. Required parameter for the callback attribute.</param>
        [OnOpenAsset(0)]
        public static bool OnOpenDialogueSystemDataAsset(int instanceId, int line)
        {
            // Get the instance id from the opened asset and translate it to an object reference.
            Object openedAssetObject = EditorUtility.InstanceIDToObject(instanceId);

            if (openedAssetObject is DialogueSystemData)
            {
                var dsData = (DialogueSystemData)openedAssetObject;
                if (dsData.IsOpened)
                {
                    // Return if the window has already been opened in the editor.
                    Debug.LogError(StringConfig.Editor_WindowAlreadyOpened_WarningText);
                    return false;
                }

                DialogueEditorWindowPresenter.CreateWindow().Initialize(dsData);

                dsData.IsOpened = true;
            }

            return false;
        }


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Performs a save action on the contents of the window.
        /// <br>The method is override to include saving all the visual elements in this window.</br>
        /// <para>Read More https://docs.unity3d.com/ScriptReference/EditorWindow.SaveChanges.html</para>
        /// </summary>
        public override void SaveChanges() => Save();


        /// <summary>
        /// When set to true, it force Unity to recognize the custom graph editor has unsaved changes,
        /// <br>so that it'll ask the user to save the window before it's closing.</br>
        /// <para></para>
        /// <br>When set to false, Unity won't ask user to save and it closes the window directly.</br>
        /// </summary>
        public void SetHasUnsavedChanges(bool value) => hasUnsavedChanges = value;


        /// <summary>
        /// Write all the unsaved changes to the disk.
        /// </summary>
        public void ApplyChangesToDisk() => ApplyChangesToDiskEvent.Invoke();


        /// <summary>
        /// Save all the graph elements on the custom graph editor.
        /// </summary>
        public void Save()
        {
            if (hasUnsavedChanges)
            {
                SaveToDSDataEvent.Invoke(dsData);
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
                LoadFromDSDataEvent.Invoke(dsData);
                ApplyChangesToDiskEvent.Invoke();
            }
            else
            {
                Debug.LogWarning(StringConfig.Editor_WindowAlreadyLoaded_WarningText);
            }
        }
    }
}