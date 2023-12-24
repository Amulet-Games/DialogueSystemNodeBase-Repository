using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class InputHint : VisualElement
    {
        /// <summary>
        /// The singleton reference of the class.
        /// </summary>
        public static InputHint Instance = null;


        /// <summary>
        /// Reference of the graph viewer element.
        /// </summary>
        public GraphViewer graphViewer;


        /// <summary>
        /// Label for the hint text.
        /// </summary>
        public Label HintTextLabel;


        /// <summary>
        /// Image for the hint icon.
        /// </summary>
        public Image HintIconImage;


        /// <summary>
        /// The vertical offset from the target field.
        /// </summary>
        const float HINT_OFFSET_TOP = 31f;


        /// <summary>
        /// The horizontal offset from the target field.
        /// </summary>
        const float HINT_OFFSET_LEFT = 18f;


        /// <summary>
        /// Constructor of the input hint element.
        /// </summary>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        public InputHint(GraphViewer graphViewer)
        {
            this.graphViewer = graphViewer;
        }


        // ----------------------------- Service -----------------------------
        /// <summary>
        /// Update and Show the input hint on the graph.
        /// </summary>
        /// <param name="hintText">The text of the hint to show.</param>
        /// <param name="targetWorldBoundRect">
        /// The world bound property from the visual element that the hint is targeting.
        /// <br>Read More: https://docs.unity3d.com/ScriptReference/Bounds.html</br>
        /// </param>
        public static void ShowHint(string hintText, Rect targetWorldBoundRect)
        {
            var graphViewer = Instance.graphViewer;

            // Show the hint.
            Instance.DisplayElement();

            // update hint position.
            UpdatePositionHorizontal();
            UpdatePositionVertical();

            // Update label text.
            Instance.HintTextLabel.text = hintText;

            void UpdatePositionHorizontal()
            {
                // Calculate the end point of the field that this hint is going to refer to.
                float targetHintPosX = targetWorldBoundRect.x + targetWorldBoundRect.width;

                // Remove the horizontal offset value from the graph viewer's content view container.
                targetHintPosX += graphViewer.contentViewContainer.worldBound.x * -1;

                // Divide it with the graph viewer size to keep position even after zooming in and out.
                targetHintPosX /= graphViewer.scale;

                // Combine the calculated position with the offset.
                Instance.style.left = targetHintPosX += HINT_OFFSET_LEFT;
            }

            void UpdatePositionVertical()
            {
                // Calculate the height position point of the field that this hint is going to target..
                float targetHintPosY = targetWorldBoundRect.y - targetWorldBoundRect.height;

                // Remove the vertical offset value from the graph viewer's content view container.
                targetHintPosY += graphViewer.contentViewContainer.worldBound.y * -1;

                // Divide it with the graph viewer size to keep position even after zooming in and out.
                targetHintPosY /= graphViewer.scale;

                // Combine the calculated position with the offset.
                Instance.style.top = targetHintPosY += HINT_OFFSET_TOP;
            }
        }


        /// <summary>
        /// Hide the current showing input hint.
        /// </summary>
        public static void HideHint()
        {
            Instance.UnDisplayElement();
        }
    }
}