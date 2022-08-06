using System;
using UnityEditor;

namespace AG
{
    public class DSApplyChangesToDiskEvent
    {
        /// <summary>
        /// DSApplyChangesToDiskEvent, which'll be invoked immediately after saved Data or load data
        /// <br>event has finished, also it'll be invoked if the graph's title has changed to a new one.</br>
        /// </summary>
        static event Action mEvent;


        /// <summary>
        /// Clear all the actions that have been registered to the event.
        /// </summary>
        public static void ClearEvents()
        {
            mEvent = null;
        }


        /// <summary>
        /// Register actions from different modules to the event.
        /// </summary>
        public static void RegisterEvent()
        {
            mEvent += AssetDatabase.SaveAssets;
            mEvent += DialogueEditorWindow.SetHasUnsavedChangesToFalse;
        }


        /// <summary>
        /// Invoke DSApplyChangesToDiskEvent.
        /// </summary>
        public static void Invoke()
        {
            mEvent?.Invoke();
        }
    }
}