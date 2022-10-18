using UnityEngine.UIElements;

namespace AG
{
    public class DSIntFieldCallbacks : DSFieldCallbacksBase
    {
        /// <summary>
        /// Each time the integer Field is assigned to a new value,
        /// <br>the Value(int) in the int container will changed at the sametime.</br>
        /// </summary>
        /// <param name="intContainer">The Int container of which the field is connecting to.</param>
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