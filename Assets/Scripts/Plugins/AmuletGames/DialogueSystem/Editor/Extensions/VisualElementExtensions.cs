using UnityEngine.UIElements;

namespace AG.DS
{
    public static class VisualElementExtensions
    {
        /// <summary>
        /// Set the picking mode of the given visual element.
        /// </summary>
        /// <param name="element">Extension visual element.</param>
        /// <param name="mode">The picking mode to set for.</param>
        /// <returns>The after setup visual element.</returns>
        public static VisualElement SetPickingMode(this VisualElement element, PickingMode mode)
        {
            element.pickingMode = mode;
            return element;
        }


        /// <summary>
        /// Remove the visual element from the display none style class if the value is true,
        /// <br>otherwise add the visual element to the display none style class.</br>
        /// </summary>
        /// <param name="element">Extension visual element.</param>
        /// <param name="value">The display value to set for.</param>
        public static void SetDisplay(this VisualElement element, bool value)
        {
            if (value)
            {
                ShowElement(element);
            }
            else
            {
                HideElement(element);
            }
        }


        /// <summary>
        /// Remove the visual element from the display none style class.
        /// </summary>
        /// <param name="element">Extension visual element.</param>
        public static void ShowElement(this VisualElement element)
        {
            element.RemoveFromClassList(StyleConfig.Global_Display_None);
        }


        /// <summary>
        /// Add the visual element to the display none style class.
        /// </summary>
        /// <param name="element">Extension visual element.</param>
        public static void HideElement(this VisualElement element)
        {
            element.AddToClassList(StyleConfig.Global_Display_None);
        }


        /// <summary>
        /// Register GeometryChangedEvent to the visual element, and unregistered it once it's invoked.
        /// </summary>
        /// <param name="element">Extension visual element.</param>
        /// <param name="callback">The GeometryChangedEvent's callback to set for.</param>
        public static void ExecuteOnceOnGeometryChanged
        (
            this VisualElement element,
            EventCallback<GeometryChangedEvent> callback
        )
        {
            callback += _ =>
            {
                // Unregister the same callback from the GeometryChangedEvent.
                element.UnregisterCallback(callback);
            };

            element.RegisterCallback(callback);
        }


        /// <summary>
        /// Add a background highlighter element to the visual element.
        /// </summary>
        /// <param name="button">Extension visual element.</param>
        public static void AddBackgroundHighlighter(this VisualElement element)
        {
            VisualElement highlighter = new();

            highlighter.pickingMode = PickingMode.Ignore;

            highlighter.AddToClassList(StyleConfig.Background_Highlighter);

            element.Add(highlighter);
        }
    }
}