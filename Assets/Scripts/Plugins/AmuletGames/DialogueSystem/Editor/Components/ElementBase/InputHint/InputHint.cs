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
        /// Vertical offset value in between the target field and the hint itself.
        /// </summary>
        const float HINT_OFFSET_TOP = 31f;


        /// <summary>
        /// Horizontal offset value in between the target field and the hint itself.
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


        // ----------------------------- Show / Hide Hint -----------------------------
        /// <summary>
        /// Show the input hint next to a visual element.
        /// </summary>
        /// <param name="hintText">The text of the hint to show.</param>
        /// <param name="targetWorldBoundRect">
        /// The world bound property from the visual element that the hint is targeting.
        /// <br>Read More: https://docs.unity3d.com/ScriptReference/Bounds.html</br>
        /// </param>
        public static void ShowHint(string hintText, Rect targetWorldBoundRect)
        {
            float targetHintPosX;
            float targetHintPosY;

            // Show the hint.
            Instance.ShowElement();

            // update hint position.
            UpdatePositionHorizontal();
            UpdatePositionVertical();

            // Update label text.
            Instance.HintTextLabel.text = hintText;

            void UpdatePositionHorizontal()
            {
                // Calculate the end point of the field that this hint is going to refer to.
                targetHintPosX = targetWorldBoundRect.x + targetWorldBoundRect.width;

                // Remove the horizontal offset value that from the graph viewer's content view container.
                targetHintPosX += Instance.graphViewer.contentViewContainer.worldBound.x * -1;

                // Divide it with the graph viewer size to keep position even after zooming in and out.
                targetHintPosX /= Instance.graphViewer.scale;

                // Lastly add the top offset value to the field that the hint is targeting to.
                Instance.style.left = targetHintPosX += HINT_OFFSET_LEFT;
            }

            void UpdatePositionVertical()
            {
                // Calculate the height position point of the field that this hint is going to target.
                targetHintPosY = targetWorldBoundRect.y - targetWorldBoundRect.height;
                //Debug.Log("Max.y = " + targetWorldBoundRect.max.y);

                // Remove the vertical offset value that created by the graph viewer's content view container.
                targetHintPosY += Instance.graphViewer.contentViewContainer.worldBound.y * -1;

                // Divide it with the graph viewer size to keep position even after zooming in and out.
                targetHintPosY /= Instance.graphViewer.scale;

                // Lastly add the top offset value to the field that the hint is targeting to.
                Instance.style.top = targetHintPosY += HINT_OFFSET_TOP;
            }
        }


        /// <summary>
        /// Hide the current showing input hint.
        /// </summary>
        public static void HideHint()
        {
            Instance.HideElement();
        }
    }
}