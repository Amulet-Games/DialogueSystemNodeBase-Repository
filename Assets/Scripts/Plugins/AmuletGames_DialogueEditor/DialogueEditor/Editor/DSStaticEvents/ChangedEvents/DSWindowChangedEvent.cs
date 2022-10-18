using System;

namespace AG
{
    public static class DSWindowChangedEvent
    {
        /// <summary>
        /// DSWindowChangedEvent, which'll be invoked if any of the visual element field's value have been changed.
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
            mEvent += window.SetHasUnsavedChangesToTrue;
        }


        /// <summary>
        /// Register this event to the other events so that they becomes one observable events stream. 
        /// </summary>
        public static void MultiCast()
        {
            DSGraphViewChangedEvent.Event += mEvent;
            DSTreeEntrySelectedEvent.Event += mEvent;
        }


        /// <summary>
        /// Invoke DSWindowChangedEvent only if the editor window has not
        /// <br>detected any unsaved changes yet, which usually it's made by the user.</br>
        /// </summary>
        public static void Invoke()
        {
            if (!DialogueEditorWindow.Instance.hasUnsavedChanges)
            {
                mEvent.Invoke();
            }
        }
    }
}