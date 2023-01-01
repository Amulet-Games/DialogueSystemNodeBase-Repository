using UnityEngine.UIElements;
using UnityEngine;

namespace AG.DS
{
    public class InputHint
    {
        /// <summary>
        /// Reference of the dialogue system's graph viewer module.
        /// </summary>
        readonly GraphViewer graphViewer;


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
        const float hintTopOffset = 31f;


        /// <summary>
        /// Horizontal offset value in between the target field and the hint itself.
        /// </summary>
        const float hintLeftOffset = 18f;


        /// <summary>
        /// The singleton reference of the class.
        /// </summary>
        public static InputHint Instance { get; private set; }


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the input hint module class.
        /// </summary>
        /// <param name="graphViewer">Dialogue system's graph viewer module.</param>
        public InputHint(GraphViewer graphViewer)
        {
            this.graphViewer = graphViewer;
            Instance = this;
        }


        // ----------------------------- Post Setup -----------------------------
        /// <summary>
        /// Post setup for the class, used to initialize internal fields, call the internal maker's method to create
        /// <br>the input hint and its child visual elements on the graph.</br>
        /// <para></para>
        /// <br>It's called by dialogue editor window, and executed after the creation of graph viewer module class.</br>
        /// </summary>
        public void PostSetup() => CreateInputHintVisualElements();


        // ----------------------------- Destruct -----------------------------
        /// <summary>
        /// Destruct for the class. Called during <see cref="DialogueEditorWindow.OnDisable"/>.
        /// </summary>
        public void Destruct()
        {
            // Remove the singleton reference of the class.
            // Forcing the window to recreate this element again on its next new setup.
            Instance = null;
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
                mainBox = new();
                mainBox.AddToClassList(StylesConfig.InputHint_Main_Box);
            }

            void SetupImage()
            {
                inputHintIconImage = ImageFactory.GetNewImage
                (
                    imageUSS01: StylesConfig.InputHint_Icon_Image
                );

                inputHintIconImage.sprite = AssetsConfig.LanguageFieldHintIconSprite;
            }

            void SetupLabel()
            {
                hintLabel = LabelFactory.GetNewLabel
                (
                    labelText: "",
                    labelUSS01: StylesConfig.InputHint_Text_Label
                );
            }

            void AddStyleSheet()
            {
                mainBox.styleSheets.Add(StylesConfig.DSGlobalStyle);
                mainBox.styleSheets.Add(StylesConfig.DSInputHintStyle);
            }

            void AddFieldsToBox()
            {
                mainBox.Add(inputHintIconImage);
                mainBox.Add(hintLabel);
            }

            void AddElementsToWindowRoot()
            {
                graphViewer.contentViewContainer.Add(mainBox);
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
            VisualElementHelper.ShowElement(mainBox);

            // Set hint position.
            CalculateHintBoxXPos();
            CalculateHintBoxYPos();

            // Set label text.
            hintLabel.text = hintText;

            void CalculateHintBoxXPos()
            {
                // Calculate the end point of the field that this hint is going to refered to.
                targetHintPosX = targetWorldBoundRect.x + targetWorldBoundRect.width;

                // Remove the horizontal offset value that from the graph viewer's content view container.
                targetHintPosX += graphViewer.contentViewContainer.worldBound.x * -1;

                // Divide it with the graph viewer size to keep position even after zooming in and out.
                targetHintPosX /= graphViewer.scale;

                // Lastly add the top offset value to the field that the hint is targeting to.
                mainBox.style.left = targetHintPosX += hintLeftOffset;
            }

            void CalculateHintBoxYPos()
            {
                // Calculate the height position point of the field that this hint is going to target.
                targetHintPosY = targetWorldBoundRect.y - targetWorldBoundRect.height;
                //Debug.Log("Max.y = " + targetWorldBoundRect.max.y);

                // Remove the vertical offset value that created by the graph viewer's content view container.
                targetHintPosY += graphViewer.contentViewContainer.worldBound.y * -1;

                // Divide it with the graph viewer size to keep position even after zooming in and out.
                targetHintPosY /= graphViewer.scale;

                // Lastly add the top offset value to the field that the hint is targeting to.
                mainBox.style.top = targetHintPosY += hintTopOffset;
            }
        }


        /// <summary>
        /// Hide the current showing input hint.
        /// </summary>
        public void HideHint()
        {
            VisualElementHelper.HideElement(mainBox);
        }
    }
}