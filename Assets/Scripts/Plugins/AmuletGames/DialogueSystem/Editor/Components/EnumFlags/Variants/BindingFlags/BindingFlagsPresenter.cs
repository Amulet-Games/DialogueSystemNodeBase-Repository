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

            CreateEnumFlagsItems();

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

            void CreateEnumFlagsItems()
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

                    bindingFlags.AllTypeItem = EnumFlagsItemPresenter.CreateElement
                    (
                        labelText: StringConfig.ConditionModifier_BindingFlags_FlagElement_All_LabelText,
                        checkmarkSprite: ConfigResourcesManager.SpriteConfig.CheckmarkIconSprite,
                        flag: allFlag
                    );
                }

                // Regular Types
                {
                    var instanceItem = EnumFlagsItemPresenter.CreateElement
                    (
                        labelText: StringConfig.ConditionModifier_BindingFlags_FlagElement_Instance_LabelText,
                        checkmarkSprite: ConfigResourcesManager.SpriteConfig.CheckmarkIconSprite,
                        flag: BindingFlags.Bindings.Instance
                    );
                    var staticItem = EnumFlagsItemPresenter.CreateElement
                    (
                        labelText: StringConfig.ConditionModifier_BindingFlags_FlagElement_Static_LabelText,
                        checkmarkSprite: ConfigResourcesManager.SpriteConfig.CheckmarkIconSprite,
                        flag: BindingFlags.Bindings.Static
                    );
                    var publicItem = EnumFlagsItemPresenter.CreateElement
                    (
                        labelText: StringConfig.ConditionModifier_BindingFlags_FlagElement_Public_LabelText,
                        checkmarkSprite: ConfigResourcesManager.SpriteConfig.CheckmarkIconSprite,
                        flag: BindingFlags.Bindings.Public
                    );
                    var privateItem = EnumFlagsItemPresenter.CreateElement
                    (
                        labelText: StringConfig.ConditionModifier_BindingFlags_FlagElement_Private_LabelText,
                        checkmarkSprite: ConfigResourcesManager.SpriteConfig.CheckmarkIconSprite,
                        flag: BindingFlags.Bindings.Private
                    );

                    bindingFlags.Items = new EnumFlagsItem<BindingFlags.Bindings>[]
                    {
                        bindingFlags.AllTypeItem,
                        instanceItem,
                        staticItem,
                        publicItem,
                        privateItem
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