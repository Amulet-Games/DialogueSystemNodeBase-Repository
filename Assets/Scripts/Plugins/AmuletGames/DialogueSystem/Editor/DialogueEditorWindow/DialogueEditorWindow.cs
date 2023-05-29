using System;
using UnityEditor;
using UnityEditor.Callbacks;
using Object = UnityEngine.Object;

namespace AG.DS
{
    public class DialogueEditorWindow : EditorWindow
    {
        /// <summary>
        /// Reference of the project manager class.
        /// </summary>
        public ProjectManager ProjectManager;


        /// <summary>
        /// Are we skipping the next OnEnable method call?
        /// </summary>
        public static bool SkipOnEnable;


        /// <summary>
        /// When set to true, it force Unity to recognize the custom graph editor has unsaved changes,
        /// <br>so that it'll ask the user to save the window before it's closing.</br>
        /// <para></para>
        /// <br>When set to false, Unity won't ask user to save and it closes the window directly.</br>
        /// </summary>
        public void SetHasUnsavedChanges(bool value) => hasUnsavedChanges = value;


        /// <summary>
        /// When scripts are reloaded after compilation has finished, OnDisable will be called,
        /// <br>followed by OnEnable after the script has been loaded.</br>
        /// <para></para>
        /// This will also be called in the <see cref="EditorWindow.GetWindow(Type)"/> method.
        /// </summary>
        void OnEnable()
        {
            if (SkipOnEnable)
            {
                SkipOnEnable = false;
                return;
            }

            WindowOnEnableEvent.Invoke();
        }


        /// <summary>
        /// <br>This is called when the window is closed and can be used to cleanup any static references.</br>
        /// </summary>
        void OnDestroy()
        {
            WindowOnDestroyEvent.Invoke();
        }


        // ----------------------------- Override -----------------------------
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
        public override void SaveChanges() => ProjectManager.Save();
    }
}