namespace AG.DS
{
    public class InputHintPresenter
    {
        /// <summary>
        /// Create a new input hint element.
        /// </summary>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        /// <returns>A new input hint element.</returns>
        public static InputHint CreateElement(GraphViewer graphViewer)
        {
            InputHint inputHint;

            CreateInputHint();

            CreateHintIconImage();

            CreateHintTextLabel();

            AddElementsToInputHint();

            AddStyleSheet();

            HideElementByDefault();

            return inputHint;

            void CreateInputHint()
            {
                inputHint = new(graphViewer);
                inputHint.AddToClassList(StyleConfig.InputHint);
            }

            void CreateHintIconImage()
            {
                inputHint.HintIconImage = ImagePresenter.CreateElement
                (
                    sprite: ConfigResourcesManager.SpriteConfig.LanguageFieldHintIconSprite,
                    USS01: StyleConfig.InputHint_HintIcon_Image
                );
            }

            void CreateHintTextLabel()
            {
                inputHint.HintTextLabel = LabelPresenter.CreateElement
                (
                    text: "",
                    USS: StyleConfig.InputHint_HintText_Label
                );
            }

            void AddElementsToInputHint()
            {
                inputHint.Add(inputHint.HintIconImage);
                inputHint.Add(inputHint.HintTextLabel);
            }

            void AddStyleSheet()
            {
                inputHint.styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.GlobalStyle);
                inputHint.styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.InputHintStyle);
            }

            void HideElementByDefault()
            {
                inputHint.UnDisplayElement();
            }
        }
    }
}