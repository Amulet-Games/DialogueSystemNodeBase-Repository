using UnityEngine.UIElements;

namespace AG
{
    public class DSIntFieldEventRegister : DSFieldEventRegisterBase
    {
        /// <summary>
        /// Each time the integer Field is assigned to a new value,
        /// <br>the Value(int) in the int container will changed at the sametime.</br>
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