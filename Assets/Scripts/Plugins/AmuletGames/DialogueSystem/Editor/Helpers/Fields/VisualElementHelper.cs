using UnityEngine.UIElements;

namespace AG.DS
{
    public class VisualElementHelper
    {
        /// <summary>
        /// Decide if the visual element should be hidden or not based on the condition provided. 
        /// </summary>
        /// <param name="condition">The condition to base on.</param>
        /// <param name="element">The targeting visual element.</param>
        public static void UpdateElementDisplay(bool condition, VisualElement element)
        {
            if (condition)
            {
                element.AddToClassList(StylesConfig.Global_Display_None);
            }
            else
            {
                element.RemoveFromClassList(StylesConfig.Global_Display_None);
            }
        }


        /// <summary>
        /// Show the visual element without any conditions.
        /// </summary>
        /// <param name="element">The targeting visual element.</param>
        public static void ShowElement(VisualElement element)
        {
            element.RemoveFromClassList(StylesConfig.Global_Display_None);
        }


        /// <summary>
        /// Hide the visual element without any conditions.
        /// </summary>
        /// <param name="element">The targeting visual element.</param>
        public static void HideElement(VisualElement element)
        {
            element.AddToClassList(StylesConfig.Global_Display_None);
        }


        /// <summary>
        /// Decide if the visual element can be interacted or not based on the condition provided.
        /// </summary>
        /// <param name="condition">The condition to base on.</param>
        /// <param name="element">The targeting visual element.</param>
        public static void UpdateElementInteractable(bool condition, VisualElement element)
        {
            if (condition)
            {
                element.pickingMode = PickingMode.Ignore;
                element.AddToClassList(StylesConfig.Global_Interactable_Disable);
            }
            else
            {
                element.pickingMode = PickingMode.Position;
                element.RemoveFromClassList(StylesConfig.Global_Interactable_Disable);
            }
        }
    }
}