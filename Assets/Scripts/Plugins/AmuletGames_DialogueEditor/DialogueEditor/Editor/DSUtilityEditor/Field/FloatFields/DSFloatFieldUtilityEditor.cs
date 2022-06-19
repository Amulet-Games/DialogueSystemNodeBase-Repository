using UnityEngine.UIElements;

namespace AG
{
    public class DSFloatFieldUtilityEditor : DSFieldUtilityEditor
    {
        /// <summary>
        /// Each time the float field is assigned to a new value,
        /// the Value(float) in the float container will changed at the sametime.
        /// </summary>
        /// <param name="floatContainer">Float container of which the float field is connecting to.</param>
        public static void RegisterValueChangedEvent(FloatContainer floatContainer)
        {
            floatContainer.FloatField.RegisterValueChangedCallback(value =>
            {
                floatContainer.Value = value.newValue;

                InvokeDSWindowChangedEvent();
            });
        }
    }
}