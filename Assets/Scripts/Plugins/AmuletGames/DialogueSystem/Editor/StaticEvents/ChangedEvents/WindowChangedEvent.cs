using System;

namespace AG.DS
{
    public static class WindowChangedEvent
    {
        /// <summary>
        /// WindowChangedEvent, which'll be invoked if any of the visual element field's value have been changed.
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
        /// Register the event to the other static events so that it becomes one observable events stream. 
        /// </summary>
        public static void MultiCast()
        {
            GraphViewChangedEvent.Event += mEvent;
            TreeEntrySelectedEvent.Event += mEvent;
        }


        /// <summary>
        /// Invoke event.
        /// </summary>
        public static void Invoke()
        {
            mEvent.Invoke();
        }
    }
}