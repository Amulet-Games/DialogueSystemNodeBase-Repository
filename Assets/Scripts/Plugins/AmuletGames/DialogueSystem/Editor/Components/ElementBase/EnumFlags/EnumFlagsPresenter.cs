using System;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class EnumFlagsPresenter
    {
        /// <summary>
        /// Create the enum flags menu element for the enum flags element.
        /// </summary>
        /// <typeparam name="TEnum">Type system.Enum</typeparam>
        /// <param name="enumFlags">The enum flags to set for.</param>
        /// <param name="flagsElements">The flag elements to set for.</param>
        protected static void CreateEnumFlagsMenu<TEnum>(EnumFlagsFrameBase<TEnum> enumFlags)
            where TEnum : struct, Enum
        {
            CreateMenu();

            AddMenuToGraphView();

            AddStyleSheet();

            HideEnumFlagsMenuByDefault();

            void CreateMenu()
            {
                enumFlags.EnumFlagsMenu = new();
                enumFlags.EnumFlagsMenu.AddToClassList(StyleConfig.EnumFlags_EnumFlagsMenu);
            }

            void AddMenuToGraphView()
            {
                enumFlags.GraphViewer.contentViewContainer.Add(enumFlags.EnumFlagsMenu);
            }

            void AddStyleSheet()
            {
                enumFlags.EnumFlagsMenu.styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.GlobalStyle);
                enumFlags.EnumFlagsMenu.styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.EnumFlagsStyle);
            }

            void HideEnumFlagsMenuByDefault()
            {
                enumFlags.Dropped = false;
            }
        }


        /// <summary>
        /// Create the enum flags button element for the enum flags element.
        /// </summary>
        /// <typeparam name="TEnum">Type system.Enum</typeparam>
        /// <param name="enumFlags">The enum flags to set for.</param>
        protected static void CreateEnumFlagsButton<TEnum>(EnumFlagsFrameBase<TEnum> enumFlags)
            where TEnum : struct, Enum
        {
            Image menuSelectImage;

            CreateEnumFlagsButton();

            CreateEnumFlagsButtonTextLabel();

            CreateMenuSelectImage();

            SetupDetails();

            AddElementsToButton();

            AddButtonToFlags();

            void CreateEnumFlagsButton()
            {
                enumFlags.EnumFlagsButton = new();
                enumFlags.EnumFlagsButton.AddToClassList(StyleConfig.EnumFlags_EnumFlagsButton);
            }

            void CreateEnumFlagsButtonTextLabel()
            {
                enumFlags.EnumFlagsButtonTextLabel = CommonLabelPresenter.CreateElement(
                    text: "",
                    USS: StyleConfig.EnumFlags_EnumFlagsButton_TextLabel
                );
            }

            void CreateMenuSelectImage()
            {
                menuSelectImage = CommonImagePresenter.CreateElement(
                    sprite: ConfigResourcesManager.SpriteConfig.MenuSelectIcon2Sprite,
                    USS01: StyleConfig.EnumFlags_EnumFlagsButton_MenuSelectImage
                );
            }

            void SetupDetails()
            {
                enumFlags.EnumFlagsButton.focusable = true;
            }

            void AddElementsToButton()
            {
                enumFlags.EnumFlagsButton.Add(enumFlags.EnumFlagsButtonTextLabel);
                enumFlags.EnumFlagsButton.Add(menuSelectImage);
            }

            void AddButtonToFlags()
            {
                enumFlags.Add(enumFlags.EnumFlagsButton);
            }
        }
    }
}