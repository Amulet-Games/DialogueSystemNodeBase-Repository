using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class InputHint : VisualElement
    {
        /// <summary>
        /// The singleton reference of the class.
        /// </summary>
        static InputHint instance = null;


        /// <summary>
        /// Reference of the dialogue system's graph viewer module.
        /// </summary>
        GraphViewer graphViewer;


        /// <summary>
        /// The text label of the message that is written in the input hint.
        /// </summary>
        Label hintTextLabel;


        /// <summary>
        /// Vertical offset value in between the target field and the hint itself.
        /// </summary>
        const float HINT_OFFSET_TOP = 31f;


        /// <summary>
        /// Horizontal offset value in between the target field and the hint itself.
        /// </summary>
        const float HINT_OFFSET_LEFT = 18f;


        // ----------------------------- Post Setup -----------------------------
        /// <summary>
        /// Post Setup for the class.
        /// </summary>
        /// <param name="graphViewer">The graph viewer module to set for.</param>
        public static void PostSetup(GraphViewer graphViewer)
        {
            instance = new();
            instance.graphViewer = graphViewer;
            instance.CreateInputHintElements();
        }


        // ----------------------------- Makers -----------------------------
        /// <summary>
        /// Create a new input hint and all its child visual elements, then hide it from the graph
        /// <br>until it is called to show again.</br>
        /// </summary>
        void CreateInputHintElements()
        {
            Image hintIconImage;

            SetupMainStyle();

            SetupHintIconImage();

            SetupHintTextLabel();

            AddElementsToInputHint();

            AddInputHintToWindowRoot();

            AddStyleSheet();

            HideHint();

            void SetupMainStyle()
            {
                AddToClassList(StyleConfig.Instance.InputHint_Main);
            }

            void SetupHintIconImage()
            {
                hintIconImage = CommonImagePresenter.CreateElements
                (
                    imageSprite: ConfigResourcesManager.Instance.SpriteConfig.LanguageFieldHintIconSprite,
                    imageUSS01: StyleConfig.Instance.InputHint_IconImage
                );
            }

            void SetupHintTextLabel()
            {
                hintTextLabel = CommonLabelPresenter.CreateElements
                (
                    labelText: "",
                    labelUSS01: StyleConfig.Instance.InputHint_TextLabel
                );
            }

            void AddElementsToInputHint()
            {
                Add(hintIconImage);
                Add(hintTextLabel);
            }

            void AddInputHintToWindowRoot()
            {
                graphViewer.contentViewContainer.Add(this);
            }

            void AddStyleSheet()
            {
                styleSheets.Add(ConfigResourcesManager.Instance.StyleSheetConfig.DSGlobalStyle);
                styleSheets.Add(ConfigResourcesManager.Instance.StyleSheetConfig.DSInputHintStyle);
            }
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
            instance.ShowElement();

            // update hint position.
            UpdatePositionHorizontal();
            UpdatePositionVertical();

            // Update label text.
            instance.hintTextLabel.text = hintText;

            void UpdatePositionHorizontal()
            {
                // Calculate the end point of the field that this hint is going to refered to.
                targetHintPosX = targetWorldBoundRect.x + targetWorldBoundRect.width;

                // Remove the horizontal offset value that from the graph viewer's content view container.
                targetHintPosX += instance.graphViewer.contentViewContainer.worldBound.x * -1;

                // Divide it with the graph viewer size to keep position even after zooming in and out.
                targetHintPosX /= instance.graphViewer.scale;

                // Lastly add the top offset value to the field that the hint is targeting to.
                instance.style.left = targetHintPosX += HINT_OFFSET_LEFT;
            }

            void UpdatePositionVertical()
            {
                // Calculate the height position point of the field that this hint is going to target.
                targetHintPosY = targetWorldBoundRect.y - targetWorldBoundRect.height;
                //Debug.Log("Max.y = " + targetWorldBoundRect.max.y);

                // Remove the vertical offset value that created by the graph viewer's content view container.
                targetHintPosY += instance.graphViewer.contentViewContainer.worldBound.y * -1;

                // Divide it with the graph viewer size to keep position even after zooming in and out.
                targetHintPosY /= instance.graphViewer.scale;

                // Lastly add the top offset value to the field that the hint is targeting to.
                instance.style.top = targetHintPosY += HINT_OFFSET_TOP;
            }
        }


        /// <summary>
        /// Hide the current showing input hint.
        /// </summary>
        public static void HideHint()
        {
            instance.HideElement();
        }
    }
}