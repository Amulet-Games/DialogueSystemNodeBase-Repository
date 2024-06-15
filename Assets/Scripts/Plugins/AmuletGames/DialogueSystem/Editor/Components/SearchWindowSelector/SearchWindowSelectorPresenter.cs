using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class SearchWindowSelectorPresenter
    {
        /// <summary>
        /// Create a new search window selector element.
        /// </summary>
        /// <param name="selectorSearchWindowView">The selector search window view to set for.</param>
        /// <param name="selectorButtonIconSprite">The selector button icon sprite to set for.</param>
        /// <param name="nullValueSelectorButtonLabelText">The null value selector button label text to set for.</param>
        /// <returns>A new search window selector element.</returns>
        public static SearchWindowSelector CreateElement
        (
            SelectorSearchWindowView selectorSearchWindowView,
            Sprite selectorButtonIconSprite,
            string nullValueSelectorButtonLabelText
        )
        {
            SearchWindowSelector selector;

            Image windowSelectImage;

            CreateSelector();

            CreateSelectorButton();

            CreateSelectorButtonIconImage();

            CreateSelectorButtonTextLabel();

            CreateWindowSelectImage();

            SetupDetails();

            AddElementsToContainer();

            AddContainersToSelector();

            AddStyleSheet();

            return selector;

            void CreateSelector()
            {
                selector = new
                (
                    selectorSearchWindowView,
                    nullValueSelectorButtonLabelText,
                    searchWindowWidth: 400f,
                    searchWindowHeight: 320f
                );

                selector.AddToClassList(StyleConfig.SearchWindowSelector);
            }

            void CreateSelectorButton()
            {
                selector.SelectorButton = new();
                selector.SelectorButton.AddToClassList(StyleConfig.SearchWindowSelector_SelectorButton_Button);
            }

            void CreateSelectorButtonIconImage()
            {
                selector.SelectorButtonIconImage = ImagePresenter.CreateElement
                (
                    sprite: selectorButtonIconSprite,
                    USS01: StyleConfig.SearchWindowSelector_SelectorButton_Icon_Image
                );
            }

            void CreateSelectorButtonTextLabel()
            {
                selector.SelectorButtonTextLabel = LabelPresenter.CreateElement
                (
                    text: nullValueSelectorButtonLabelText,
                    USS: StyleConfig.SearchWindowSelector_SelectorButton_Text_Label
                );
            }

            void CreateWindowSelectImage()
            {
                windowSelectImage = ImagePresenter.CreateElement
                (
                    sprite: ConfigResourcesManager.SpriteConfig.SearchWindowSelectIconSprite,
                    USS01: StyleConfig.SearchWindowSelector_SelectorButton_MenuSelectImage
                );
            }

            void SetupDetails()
            {
                selector.SelectorButton.focusable = true;
            }

            void AddElementsToContainer()
            {
                selector.SelectorButton.Add(selector.SelectorButtonIconImage);
                selector.SelectorButton.Add(selector.SelectorButtonTextLabel);
                selector.SelectorButton.Add(windowSelectImage);
            }

            void AddContainersToSelector()
            {
                selector.Add(selector.SelectorButton);
            }

            void AddStyleSheet()
            {
                selector.styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.SearchWindowSelectorStyle);
            }
        }
    }
}