using System;
using System.Linq;

namespace AG.DS
{
    public class BindingFlagsPresenter : EnumFlagsPresenter
    {
        /// <summary>
        /// Create a new binding flags element.
        /// </summary>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        /// <returns>A new binding flags element.</returns>
        public static BindingFlags CreateElement(GraphViewer graphViewer)
        {
            BindingFlags bindingFlags;

            CreateEnumFlags();

            CreateEnumFlagsButton();

            CreateEnumFlagsMenu();

            CreateFlagsElements();

            AddStyleSheet();

            return bindingFlags;

            void CreateEnumFlags()
            {
                bindingFlags = new(graphViewer);
                bindingFlags.AddToClassList(StyleConfig.EnumFlags);
            }

            void CreateEnumFlagsButton()
            {
                EnumFlagsPresenter.CreateEnumFlagsButton(bindingFlags);
            }

            void CreateEnumFlagsMenu()
            {
                EnumFlagsPresenter.CreateEnumFlagsMenu(enumFlags: bindingFlags);
            }

            void CreateFlagsElements()
            {
                // All Type
                {
                    BindingFlags.Bindings allFlag = 0;

                    var flagsValues = Enum.GetValues(typeof(BindingFlags.Bindings)).Cast<BindingFlags.Bindings>().ToArray();
                    for (int i = 0; i < flagsValues.Length; i++)
                    {
                        if (flagsValues[i] != 0)
                        {
                            allFlag |= flagsValues[i];
                        }
                    }

                    bindingFlags.AllTypeFlagElement = FlagElementPresenter.CreateElement
                    (
                        labelText: StringConfig.ConditionModifier_BindingFlags_FlagElement_All_LabelText,
                        selectedIconSprite: ConfigResourcesManager.SpriteConfig.CheckMarkIconSprite,
                        flag: allFlag
                    );
                }

                // Regular Types
                {
                    var instanceFlagElement = FlagElementPresenter.CreateElement
                    (
                        labelText: StringConfig.ConditionModifier_BindingFlags_FlagElement_Instance_LabelText,
                        selectedIconSprite: ConfigResourcesManager.SpriteConfig.CheckMarkIconSprite,
                        flag: BindingFlags.Bindings.Instance
                    );
                    var staticFlagElement = FlagElementPresenter.CreateElement
                    (
                        labelText: StringConfig.ConditionModifier_BindingFlags_FlagElement_Static_LabelText,
                        selectedIconSprite: ConfigResourcesManager.SpriteConfig.CheckMarkIconSprite,
                        flag: BindingFlags.Bindings.Static
                    );
                    var publicFlagElement = FlagElementPresenter.CreateElement
                    (
                        labelText: StringConfig.ConditionModifier_BindingFlags_FlagElement_Public_LabelText,
                        selectedIconSprite: ConfigResourcesManager.SpriteConfig.CheckMarkIconSprite,
                        flag: BindingFlags.Bindings.Public
                    );
                    var privateFlagElement = FlagElementPresenter.CreateElement
                    (
                        labelText: StringConfig.ConditionModifier_BindingFlags_FlagElement_Private_LabelText,
                        selectedIconSprite: ConfigResourcesManager.SpriteConfig.CheckMarkIconSprite,
                        flag: BindingFlags.Bindings.Private
                    );

                    bindingFlags.FlagElements = new FlagElement<BindingFlags.Bindings>[]
                    {
                        bindingFlags.AllTypeFlagElement,
                        instanceFlagElement,
                        staticFlagElement,
                        publicFlagElement,
                        privateFlagElement
                    };
                }
            }

            void AddStyleSheet()
            {
                bindingFlags.styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.EnumFlagsStyle);
            }
        }
    }
}