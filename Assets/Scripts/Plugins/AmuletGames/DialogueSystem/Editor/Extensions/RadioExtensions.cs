using UnityEngine.UIElements;

namespace AG.DS
{
    public static class RadioExtensions
    {
        /// <summary>
        /// Add or remove the radio element's selected style class based on the certain condition.
        /// </summary>
        /// <param name="radio">Extension radio element.</param>
        public static void ToggleActiveStyle(this Radio radio)
        {
            if (radio.pickingMode == PickingMode.Ignore)
            {
                ShowActiveStyle(radio);
            }
            else
            {
                HideActiveStyle(radio);
            }
        }


        /// <summary>
        /// Remove the radio element from the active style class.
        /// </summary>
        /// <param name="radio">Extension radio element.</param>
        public static void HideActiveStyle(this Radio radio)
        {
            radio.RemoveFromClassList(StyleConfig.Radio_Active);
        }


        /// <summary>
        /// Add the radio element to the active style class.
        /// </summary>
        /// <param name="radio">Extension radio element.</param>
        public static void ShowActiveStyle(this Radio radio)
        {
            radio.AddToClassList(StyleConfig.Radio_Active);
        }
    }
}