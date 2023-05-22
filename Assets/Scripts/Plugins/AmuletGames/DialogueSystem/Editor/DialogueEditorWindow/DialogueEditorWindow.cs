using System;
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
        public DialogueSystemData DsData;


        /// <summary>
        /// Reference of the project manager class.
        /// </summary>
        public ProjectManager ProjectManager;


        /// <summary>
        /// Reference of the dialogue editor window callback.
        /// </summary>
        public DialogueEditorWindowCallback Callback;


        /// <summary>
        /// Are we skipping the next OnEnable method call?
        /// </summary>
        public bool SkipOnEnable;


        /// <summary>
        /// When set to true, it force Unity to recognize the custom graph editor has unsaved changes,
        /// <br>so that it'll ask the user to save the window before it's closing.</br>
        /// <para></para>
        /// <br>When set to false, Unity won't ask user to save and it closes the window directly.</br>
        /// </summary>
        public void SetHasUnsavedChanges(bool value) => hasUnsavedChanges = value;


        /// <summary>
        /// This method is called after the <see cref="EditorWindow.GetWindow(Type)"/> method.
        /// <para></para>
        /// <br>When scripts are reloaded after compilation has finished, OnDisable will be called,</br>
        /// <br>followed by OnEnable after the script has been loaded.</br>
        /// </summary>
        void OnEnable()
        {
            if (SkipOnEnable)
            {
                SkipOnEnable = false;
                return;
            }

            // Register events
            Callback.RegisterEventOnEnable();

            // Load window
            Load(isForceLoadWindow: true);
        }


        /// <summary>
        /// <br>This is called when the window is closed and can be used to cleanup any static references.</br>
        /// </summary>
        void OnDestroy()
        {
            ProjectManager.Cleanup();
        }


        /// <summary>
        /// Ask the serialize handler to save all the graph elements on the custom graph editor.
        /// </summary>
        public void Save()
        {
            if (hasUnsavedChanges)
            {
                SaveToDSDataEvent.Invoke(DsData);
                ApplyChangesToDiskEvent.Invoke();
            }
            else
            {
                Debug.LogWarning(StringConfig.Instance.Editor_WindowAlreadySaved_WarningText);
            }
        }


        /// <summary>
        /// Ask the serialize handler to load the saved graph elements and create them again on the graph.
        /// </summary>
        public void Load(bool isForceLoadWindow)
        {
            if (isForceLoadWindow)
            {
                LoadWindow();
            }
            else if (hasUnsavedChanges)
            {
                LoadWindow();
            }
            else
            {
                Debug.LogWarning(StringConfig.Instance.Editor_WindowAlreadyLoaded_WarningText);
            }

            void LoadWindow()
            {
                LoadFromDSDataEvent.Invoke(DsData);
                ApplyChangesToDiskEvent.Invoke();
            }
        }


        // ----------------------------- Override -----------------------------
        /// <summary>
        /// Callback attribute for opening an asset in Unity (e.g the callback is fired when double clicking an asset in the Project Browser).
        /// <para>Read More https://docs.unity3d.com/2020.1/Documentation/ScriptReference/Callbacks.OnOpenAssetAttribute.html</para>
        /// </summary>
        /// <param name="instanceId">The instance id of the opened asset. Required parameter for the callback attribute.</param>
        /// <param name="line">Can be ignored. Required parameter for the callback attribute.</param>
        [OnOpenAsset(0)]
        public static bool ShowWindow(int instanceId, int line)
        {
            // Get the instance id from the opened asset and translate it to an object reference.
            Object openedAssetObject = EditorUtility.InstanceIDToObject(instanceId);

            // If the object is a dialogue system data.
            if (openedAssetObject is DialogueSystemData)
            {
                var dsData = (DialogueSystemData)openedAssetObject;

                dsData.InstanceId = instanceId;

                new ProjectManager(dsData);
            }

            return false;
        }


        /// <summary>
        /// Performs a save action on the contents of the window.
        /// <br>The method is override to include saving all the visual elements in this window.</br>
        /// <para>Read More https://docs.unity3d.com/ScriptReference/EditorWindow.SaveChanges.html</para>
        /// </summary>
        public override void SaveChanges() => Save();
    }
}