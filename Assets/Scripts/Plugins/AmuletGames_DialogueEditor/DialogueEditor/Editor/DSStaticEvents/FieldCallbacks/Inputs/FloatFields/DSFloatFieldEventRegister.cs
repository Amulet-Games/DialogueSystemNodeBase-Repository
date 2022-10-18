using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace AG
{
    public class DSFloatFieldCallbacks : DSFieldCallbacksBase
    {
        /// <summary>
        /// Each time the float field is assigned to a new value,
        /// <br>the Value(float) in the float container will changed at the sametime.</br>
        /// </summary>
        /// <param name="floatContainer">The Float container of which the field is connecting to.</param>
        public static void RegisterValueChangedEvent(FloatContainer floatContainer)
        {
            floatContainer.FloatField.RegisterValueChangedCallback(value =>
            {
                floatContainer.Value = value.newValue;

                InvokeDSWindowChangedEvent();
            });
        }


        /// <summary>
        /// Each time the float field is selected, if it's in empty style class then remove the field from it.
        /// </summary>
        /// <param name="floatField">The float field to register the event on.</param>
        public static void RegisterFieldFocusInEvent(FloatField floatField)
        {
            floatField.RegisterCallback<FocusInEvent>(_ =>
            {
                // When input field was clicked and it's empty,
                // remove the previous added empty style class.
                DSFloatFieldUtility.HideEmptyStyle(floatField);
            });
        }


        /// <summary>
        /// Each time the float field is deselected, if its value is equal to 0, add the field to empty style class.
        /// </summary>
        /// <param name="floatField">The float field to register the event on.</param>
        public static void RegisterFieldFocusOutEvent(FloatField floatField)
        {
            floatField.RegisterCallback<FocusOutEvent>(_ =>
            {
                // When input field was deselected and the field is empty,
                // add the field to empty style class.
                DSFloatFieldUtility.ToggleEmptyStyle(floatField);
            });
        }
    }
}