using UnityEngine.UIElements;

namespace AG.DS
{
    public static class ButtonExtensions
    {
        /// <summary>
        /// Add a background highlighter UIElement to the given button.
        /// </summary>
        /// <param name="button">Extension button</param>
        public static void AddBackgroundHighlighter(this Button button)
        {
            VisualElement highlighter = new();

            highlighter.AddToClassList(StyleConfig.Button_Background_Highlighter);

            button.Add(highlighter);
        }
    }
}