using System;

namespace AG
{
    public class DSLoadDataFromContainerSOEvent
    {
        /// <summary>
        /// DSLoadDataFromContainerSOEvent, which'll be invoked automatically when the editor
        /// <br>window is first opened or manually by user clicking the load button on the editor's</br>
        /// <br>head bar.</br>
        /// </summary>
        static event Action<DialogueContainerSO> mEvent;


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
        /// <param name="serializeHandler">Dialogue system's serialize handler module.</param>
        /// <param name="headBar">Dialogue system's Headbar module.</param>
        public static void Register(DSSerializeHandler serializeHandler, DSHeadBar headBar)
        {
            mEvent += serializeHandler.LoadEdgesAndNodesAction;
            mEvent += headBar.LoadLanguageAndTitleAction;
        }


        /// <summary>
        /// Invoke DSLoadDataFromContainerSOEvent.
        /// </summary>
        /// <param name="eventPara">The scriptable object asset parameter that is needed for this event to be invoked.</param>
        public static void Invoke(DialogueContainerSO eventPara)
        {
            mEvent?.Invoke(eventPara);
        }
    }
}