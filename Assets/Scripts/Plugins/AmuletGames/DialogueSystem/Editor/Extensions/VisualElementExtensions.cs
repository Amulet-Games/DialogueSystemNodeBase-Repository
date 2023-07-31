using UnityEngine.UIElements;

namespace AG.DS
{
    public static class VisualElementExtensions
    {
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
                element.RemoveFromClassList(StyleConfig.Global_Display_None);
            }
            else
            {
                element.AddToClassList(StyleConfig.Global_Display_None);
            }
        }


        /// <summary>
        /// Remove the given visual element from the display none style class.
        /// </summary>
        /// <param name="element">Extension visual element.</param>
        public static void ShowElement(this VisualElement element)
        {
            element.RemoveFromClassList(StyleConfig.Global_Display_None);
        }


        /// <summary>
        /// Add the given visual element to the display none style class.
        /// </summary>
        /// <param name="element">Extension visual element.</param>
        public static void HideElement(this VisualElement element)
        {
            element.AddToClassList(StyleConfig.Global_Display_None);
        }


        /// <summary>
        /// Register GeometryChangedEvent to the given element, once the event has been called, it will be unregistered from the given element. 
        /// <br>So the given callback will only be called once.</br>
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
        /// Add a background highlighter element to the given visual element.
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