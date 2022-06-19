using UnityEngine.UIElements;

namespace AG
{
    public class DSIntFieldUtilityEditor : DSFieldUtilityEditor
    {
        /// <summary>
        /// Each time the integer Field is assigned to a new value,
        /// the Value(int) in the int container will changed at the sametime.
        /// </summary>
        /// <param name="intContainer">Int container of which the integer field is connecting to.</param>
        public static void RegisterValueChangedEvent(IntContainer intContainer)
        {
            intContainer.IntField.RegisterValueChangedCallback(value =>
            {
                intContainer.Value = value.newValue;

                InvokeDSWindowChangedEvent();
            });
        }
    }
}