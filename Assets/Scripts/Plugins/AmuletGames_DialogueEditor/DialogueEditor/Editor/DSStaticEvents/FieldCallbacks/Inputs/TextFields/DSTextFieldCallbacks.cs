using UnityEngine.UIElements;

namespace AG
{
    public class DSTextFieldCallbacks : DSFieldCallbacksBase
    {
        /// <summary>
        /// Each time the text field is assigned to a new value,
        /// <br>the Value(string) in the string container will changed at the sametime.</br>
        /// </summary>
        /// <param name="textContainer">The Text container of which the text field is connecting to.</param>
        public static void RegisterValueChangedEvent(TextContainer textContainer)
        {
            textContainer.TextField.RegisterValueChangedCallback(value =>
            {
                textContainer.Value = value.newValue;

                InvokeDSWindowChangedEvent();
            });
        }


        /// <summary>
        /// Each time the text field is selected, if it's in empty style class then remove the field from it.
        /// </summary>
        /// <param name="textField">The text field to register the event on.</param>
        public static void RegisterFieldFocusInEvent(TextField textField)
        {
            textField.RegisterCallback<FocusInEvent>(_ => 
            {
                // When input field was clicked and it's empty,
                // remove the previous added empty style class.
                DSTextFieldUtility.HideEmptyStyle(textField);
            });
        }


        /// <summary>
        /// Each time the text field is deselected, if the field is empty, add the field to empty style class.
        /// </summary>
        /// <param name="textContainer">The Text container of which the text field is connecting to.</param>
        public static void RegisterFieldFocusOutEvent(TextContainerBase textContainer)
        {
            textContainer.TextField.RegisterCallback<FocusOutEvent>(_ =>
            {
                // When input field was deselected and the field is empty,
                // add the field to empty style class.
                DSTextFieldUtility.ToggleEmptyStyle(textContainer);
            });
        }
    }
}