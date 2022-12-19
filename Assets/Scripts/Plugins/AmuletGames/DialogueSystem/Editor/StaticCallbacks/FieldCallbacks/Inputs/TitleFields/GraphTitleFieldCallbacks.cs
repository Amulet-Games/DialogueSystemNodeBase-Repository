using UnityEngine.UIElements;

namespace AG.DS
{
    public class GraphTitleFieldCallbacks
    {
        /// <summary>
        /// FIELD DELAYED IS SET TO TRUE
        /// <para></para>
        /// <br>Event only get invoked when user pressed enter / return to submit the changes to the field.</br>
        /// <br>Event will invoke the real dialogue system's GraphTitleChangedEvent.</br>
        /// </summary>
        /// <param name="graphTitleField">The graph title field in which it's located on the editor window's headbar.</param>
        public static void RegisterGraphTitleChangedEvent(TextField graphTitleField)
        {
            graphTitleField.RegisterValueChangedCallback(callback =>
            {
                GraphTitleChangedEvent.Invoke(callback.newValue);
            });
        }


        /// <summary>
        /// Each time the graph title field was deselected, if it was changed but not submitted yet,
        /// <br>the field's value will reset to current window's title.</br>
        /// </summary>
        /// <param name="graphTitleField">The graph title field in which it's located on the editor window's headbar.</param>
        public static void RegisterGraphTitleFocusOutEvent(TextField graphTitleField)
        {
            graphTitleField.RegisterCallback<FocusOutEvent>(callback => 
            {
                graphTitleField.UpdateFieldValueNonAlert();
            });
        }
    }
}