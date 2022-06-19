using System;
using UnityEditor;

namespace AG
{
    public class DSApplyChangesToDiskEvent
    {
        public static event Action mEvent;

        /// Setup.
        public static void ClearEvents()
        {
            mEvent = null;
        }

        public static void RegisterEvent()
        {
            mEvent += AssetDatabase.SaveAssets;
            mEvent += DialogueEditorWindow.SetHasUnsavedChangesToFalse;
        }

        /// Invoke.
        public static void Invoke()
        {
            mEvent?.Invoke();
        }
    }
}