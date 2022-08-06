using UnityEngine.UIElements;

namespace AG
{
    public class DSFieldUtility
    {
        /// <summary>
        /// Decide if the visual element should be hidden or not based on the condition that is provided. 
        /// </summary>
        /// <param name="shouldHide">Condition to base on to set visual element visibility.</param>
        /// <param name="elementToHide">The visual element to show or hide.</param>
        public static void ToggleElementDisplay(bool shouldHide, VisualElement elementToHide)
        {
            if (shouldHide)
            {
                elementToHide.AddToClassList(DSStylesConfig.dsGlobal_Display_None);
            }
            else
            {
                elementToHide.RemoveFromClassList(DSStylesConfig.dsGlobal_Display_None);
            }
        }

        /// <summary>
        /// Show the visual element without any conditions.
        /// </summary>
        /// <param name="elementToShow">The visual element to show.</param>
        public static void ShowElement(VisualElement elementToShow)
        {
            elementToShow.RemoveFromClassList(DSStylesConfig.dsGlobal_Display_None);
        }

        /// <summary>
        /// Hide the visual element without any conditions.
        /// </summary>
        /// <param name="elementToHide">The visual element to hide.</param>
        public static void HideElement(VisualElement elementToHide)
        {
            elementToHide.AddToClassList(DSStylesConfig.dsGlobal_Display_None);
        }
    }
}