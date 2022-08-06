using UnityEngine.UIElements;

namespace AG
{
    public class DSTextFieldEventRegister : DSFieldEventRegisterBase
    {
        /// <summary>
        /// Each time the text field is assigned to a new value,
        /// <br>the Value(string) in the string container will changed at the sametime.</br>
        /// </summary>
        /// <param name="stringContainer">String container of which the text field is connecting to.</param>
        public static void RegisterValueChangedEvent(TextContainer stringContainer)
        {
            stringContainer.TextField.RegisterValueChangedCallback(value =>
            {
                stringContainer.Value = value.newValue;

                InvokeDSWindowChangedEvent();
            });
        }


        /// <summary>
        /// Each time the text field is selected,
        /// <br>if it's currently empty then hide the placeholder text.</br>
        /// </summary>
        /// <param name="textField">The text field this event is registered upon on.</param>
        public static void RegisterFieldFocusInEvent(TextField textField)
        {
            textField.RegisterCallback<FocusInEvent>(_ => 
            {
                DSTextFieldUtility.HideEmptyStyle(textField);
            });
        }


        /// <summary>
        /// Each time the text field is deselected,
        /// <br>if it's currently empty then show the placeholder text.</br>
        /// </summary>
        /// <param name="stringContainer">String container of which the text field is connecting to.</param>
        public static void RegisterFieldFocusOutEvent(TextContainerBase stringContainer)
        {
            stringContainer.TextField.RegisterCallback<FocusOutEvent>(_ =>
            {
                DSTextFieldUtility.ShowEmptyStyle(stringContainer);
            });
        }
    }
}