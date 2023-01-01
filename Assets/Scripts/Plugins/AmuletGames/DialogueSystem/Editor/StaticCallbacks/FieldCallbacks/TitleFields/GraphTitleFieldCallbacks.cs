using UnityEngine.UIElements;

namespace AG.DS
{
    public class GraphTitleFieldCallbacks
    {
        /// <summary>
        /// Register value changed actions to the given field element.
        /// <para></para>
        /// FIELD DELAYED IS SET TO TRUE,
        /// <br>Registered actions will be invoked when the user pressed enter / return key on the field.</br>
        /// </summary>
        /// <param name="textField">The field to assign the value changed actions to.</param>
        public static void RegisterValueChangedEvent(TextField textField)
        {
            textField.RegisterValueChangedCallback(callback =>
            {
                GraphTitleChangedEvent.Invoke(callback.newValue);
            });
        }


        /// <summary>
        /// Register focus in actions to the given field element.
        /// </summary>
        /// <param name="textField">The field to assign the focus out actions to.</param>
        public static void RegisterGraphTitleFocusOutEvent(TextField textField)
        {
            textField.RegisterCallback<FocusOutEvent>(callback => 
            {
                textField.UpdateFieldValueNonAlert();
            });
        }
    }
}