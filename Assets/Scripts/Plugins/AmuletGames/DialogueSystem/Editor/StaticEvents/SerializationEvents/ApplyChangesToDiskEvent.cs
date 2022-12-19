using System;
using UnityEditor;

namespace AG.DS
{
    public class ApplyChangesToDiskEvent
    {
        /// <summary>
        /// ApplyChangesToDiskEvent, which'll be invoked immediately after saved Data or load data
        /// <br>event has finished, also it'll be invoked if the graph's title has changed to a new one.</br>
        /// </summary>
        static event Action mEvent;


        /// <summary>
        /// Clear all the actions that have been registered to the event.
        /// </summary>
        public static void Clear()
        {
            mEvent = null;
        }


        /// <summary>
        /// Register actions from different modules to the event.
        /// </summary>
        /// <param name="window">Dialogue system's editor window module.</param>
        public static void Register(DialogueEditorWindow window)
        {
            mEvent += AssetDatabase.SaveAssets;
            mEvent += window.SetHasUnsavedChangesToFalse;
        }


        /// <summary>
        /// Invoke event.
        /// </summary>
        public static void Invoke()
        {
            mEvent?.Invoke();
        }
    }
}