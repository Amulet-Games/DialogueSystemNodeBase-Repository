using UnityEngine.UIElements;
using UnityEngine;

namespace AG
{
    public class DSInputHint
    {
        /// <summary>
        /// Reference of the dialogue system's graph view module.
        /// </summary>
        DSGraphView graphView;


        /// <summary>
        /// The main box container of the input hint.
        /// </summary>
        Box mainBox;


        /// <summary>
        /// The text label of the input hint.
        /// </summary>
        Label hintLabel;


        /// <summary>
        /// Vertical offset value in between the target field and the hint itself.
        /// </summary>
        float hintTopOffset = 19.5f;

        /// <summary>
        /// Horizontal offset value in between the target field and the hint itself.
        /// </summary>
        float hintLeftOffset = 18f;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the dialogue system's input hint module.
        /// </summary>
        /// <param name="graphView">Dialogue system's graph view module.</param>
        public DSInputHint(DSGraphView graphView)
        {
            this.graphView = graphView;
        }


        // ----------------------------- Post Setup -----------------------------
        /// <summary>
        /// Post setup for the class, used to initialize internal fields, call the internal maker's method to create
        /// <br>the input hint and its child visual elements on the graph.</br>
        /// <para></para>
        /// <br>It's called by dialogue editor window, and executed after the creation of graph view module class.</br>
        /// </summary>
        public void PostSetup()
        {
            CreateInputHintVisualElements();
        }


        // ----------------------------- Makers -----------------------------
        /// <summary>
        /// Create a new input hint and all its child visual elements, then hide it from the graph
        /// <br>until it is called to show again.</br>
        /// </summary>
        void CreateInputHintVisualElements()
        {
            Image inputHintIconImage;

            SetupBoxContainer();

            SetupImage();

            SetupLabel();

            AddStyleSheet();

            AddFieldsToBox();

            AddElementsToWindowRoot();

            HideHint();

            void SetupBoxContainer()
            {
                mainBox = new Box();
                mainBox.AddToClassList(DSStylesConfig.inputHint_MainBox);
            }

            void SetupImage()
            {
                inputHintIconImage = DSImagesMaker.GetNewImage(DSStylesConfig.inputHint_IconImage);
                inputHintIconImage.image = DSAssetsConfig.inputHintIconSprite.texture;
            }

            void SetupLabel()
            {
                hintLabel = DSLabelsMaker.GetNewLabel("", DSStylesConfig.inputHint_HintLabel);
            }

            void AddStyleSheet()
            {
                mainBox.styleSheets.Add(DSStylesConfig.dsGlobalStyle);
                mainBox.styleSheets.Add(DSStylesConfig.dsInputHintStyle);
            }

            void AddFieldsToBox()
            {
                mainBox.Add(inputHintIconImage);
                mainBox.Add(hintLabel);
            }

            void AddElementsToWindowRoot()
            {
                graphView.contentViewContainer.Add(mainBox);
            }
        }


        // ----------------------------- Show Hint Services -----------------------------
        /// <summary>
        /// Show the input hint next to a visual element.
        /// </summary>
        /// <param name="hintText">The text of the hint to show.</param>
        /// <param name="targetWorldBoundRect">
        /// The world bound property from the visual element that the hint is targeting.
        /// <br>Read More: https://docs.unity3d.com/ScriptReference/Bounds.html</br>
        /// </param>
        public void ShowHint(string hintText, Rect targetWorldBoundRect)
        {
            float targetHintPosX;
            float targetHintPosY;

            // Show the hint.
            DSFieldUtility.ShowElement(mainBox);

            // Set hint position.
            CalculateHintBoxXPos();
            CalculateHintBoxYPos();

            // Set label text.
            hintLabel.text = hintText;

            void CalculateHintBoxXPos()
            {
                // Calculate the end point of the field that this hint is going to refered to.
                targetHintPosX = targetWorldBoundRect.x + targetWorldBoundRect.width;

                // Remove the horizontal offset value that created by the Graph View Container.
                targetHintPosX += graphView.contentViewContainer.worldBound.x * -1;

                // Add the left offset value to create space between this hint and the field.
                targetHintPosX += hintLeftOffset;

                // To keep the correct position even after graph view zooming.
                mainBox.style.left = targetHintPosX / graphView.scale;
            }

            void CalculateHintBoxYPos()
            {
                // Calculate the height position point of the field that this hint is going to target.
                targetHintPosY = targetWorldBoundRect.y - targetWorldBoundRect.height;

                // Remove the vertical offset value that created by the Graph View Container.
                targetHintPosY += graphView.contentViewContainer.worldBound.y * -1;

                // Add the top offset value to match the position of this hint and the field.
                targetHintPosY += hintTopOffset;

                // To keep the correct position even after graph view zooming.
                mainBox.style.top = targetHintPosY / graphView.scale;
            }
        }


        /// <summary>
        /// Hide the current showing input hint.
        /// </summary>
        public void HideHint()
        {
            DSFieldUtility.HideElement(mainBox);
        }
    }
}