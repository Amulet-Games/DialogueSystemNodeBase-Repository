using System.Collections.Generic;

namespace AG.DS
{
    public class BooleanNodeStitcher
    {
        /// <summary>
        /// Internal root modifier reference.
        /// </summary>
        ConditionModifier rootModifier;


        /// <summary>
        /// Internal instance modifiers cache.
        /// </summary>
        List<ConditionModifier> instanceModifiers;


        /// <summary>
        /// Internal modifiers cache counter.
        /// </summary>
        int instancesCount = 0;


        /// <summary>
        /// Internal segment reference.
        /// </summary>
        Segment segment;


        /// <summary>
        /// Temporary use of root modifier data.
        /// </summary>
        ConditionModifierData tempRootModifierData;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the event node stitcher class.
        /// </summary>
        public BooleanNodeStitcher()
        {
            rootModifier = new();
            instanceModifiers = new();
            segment = new();
            tempRootModifierData = new();
        }


        // ----------------------------- Makers -----------------------------
        /// <summary>
        /// Create all the UIElements that are needed in the stitcher.
        /// </summary>
        /// <param name="node">Node of which this stitcher is created for.</param>
        public void CreateRootElements(NodeBase node)
        {
            SetupContentButton();

            SetupSegment();

            SetupRootModifier();

            StitcherCreatedAction();

            void SetupContentButton()
            {
                //ContentButtonPresenter.CreateElements
                //(
                //    node: node,
                //    buttonText: StringConfig.Instance.AddConditionLabelText,
                //    buttonIconSprite: SpriteConfig.Instance.AddConditionModifierButtonIconSprite,
                //    buttonClickAction: ContentButtonClickAction
                //);
            }

            void SetupSegment()
            {
                // Create new segment.
                segment.CreateRootElements
                (
                    node: node,
                    titleText: StringConfig.Instance.ConditionSegmentTitleLabelText,
                    titleBoxUSS01: StyleConfig.Instance.Segment_Condition_Title_Box,
                    contentBoxUSS01: StyleConfig.Instance.Segment_Condition_Content_Box
                );
            }

            void SetupRootModifier()
            {
                rootModifier.CreateRootElements(node);
            }

            void StitcherCreatedAction()
            {
                // Hide the instance modifiers.
                ShowRootModifier();

                // Add the first instance modifier.
                AddInstanceModifier(data: null);
            }
        }


        /// <summary>
        /// Create a new instance modifier for the stitcher.
        /// </summary>
        /// <param name="data">The given modifier data to load from.</param>
        void AddInstanceModifier(ConditionModifierData data)
        {
            new ConditionModifier().CreateInstanceElements
            (
                data: data,
                modifierCreatedAction: ModifierCreatedAction,
                removeButtonClickAction: ModifierRemoveButtonClickAction
            );
        }


        // ----------------------------- Callbacks -----------------------------
        /// <summary>
        /// The action to invoke when the content button is clicked.
        /// <para>See: <see cref="CreateRootElements"/></para>
        /// </summary>
        void ContentButtonClickAction()
        {
            // If this is the first time user adding a new instance modifier through content button.
            if (instancesCount == 1)
            {
                // Load the root modifier's data to the initial instance modifier.
                rootModifier.SaveModifierValue(tempRootModifierData);
                instanceModifiers[0].LoadModifierValue(tempRootModifierData);

                // and show instance modifiers only.
                ShowInstanceModifiers();
            }

            // Add a new instance modifier to the node.
            AddInstanceModifier(data: null);
        }


        /// <summary>
        /// The action to invoke when a modifier is created.
        /// </summary>
        /// <param name="modifier">The new created modifier.</param>
        void ModifierCreatedAction(ConditionModifier modifier)
        {
            // Add box to segment's content box
            segment.ContentBox.Add(modifier.MainBox);

            // Expand the segment.
            segment.SetIsExpanded(value: true);

            // Add modifier to the internal cache.
            instanceModifiers.Add(modifier);

            // Increase cache count.
            instancesCount++;
        }


        /// <summary>
        /// The action to invoke when the modifier's remove button is clicked.
        /// </summary>
        /// <param name="modifier">The modifier that is going to be removed.</param>
        void ModifierRemoveButtonClickAction(ConditionModifier modifier)
        {
            // Decrease internal count.
            instancesCount--;

            // Remove modifier from the cache.
            instanceModifiers.Remove(modifier);

            // Delete box from segment's content box
            segment.ContentBox.Remove(modifier.MainBox);

            // Check if there's only one instance modifier left,
            // if so, switch back to mainly show root modifier only.
            if (instancesCount == 1)
            {
                // Hide the segment's main box.
                ShowRootModifier();

                // Load data from the last modifier in segment list, to rooted modifier
                instanceModifiers[0].SaveModifierValue(tempRootModifierData);
                rootModifier.LoadModifierValue(tempRootModifierData);
            }
        }


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Save the stitcher values to the given data.
        /// </summary>
        /// <param name="data">The given data to save to.</param>
        public void SaveStitcherValues(BooleanNodeStitcherData data)
        {
            SaveRootModifier();

            SaveInstanceModifiers();

            void SaveRootModifier()
            {
                rootModifier.SaveModifierValue(data.RootModifierData);
            }

            void SaveInstanceModifiers()
            {
                for (int i = 0; i < instancesCount; i++)
                {
                    // New modifier data.
                    ConditionModifierData newModifierData = new();

                    // Save values.
                    instanceModifiers[i].SaveModifierValue(newModifierData);

                    // Add to the data list.
                    data.InstanceModifiersData.Add(newModifierData);
                }
            }
        }


        /// <summary>
        /// Load the stitcher values from the given data.
        /// </summary>
        /// <param name="data">The given data to load from.</param>
        public void LoadStitcherValues(BooleanNodeStitcherData data)
        {
            LoadRootModifier();

            LoadInstanceModifiers();

            StitcherLoadedAction();

            void LoadRootModifier()
            {
                rootModifier.LoadModifierValue(data.RootModifierData);
            }

            void LoadInstanceModifiers()
            {
                // Instnace modifiers data count.
                var instanceModifiersDataCount = data.InstanceModifiersData.Count;

                // Initial instanace modifier is created together with the molder,
                // so here it only need to load its values from the source.
                if (instanceModifiersDataCount > 0)
                {
                    instanceModifiers[0].LoadModifierValue(data.InstanceModifiersData[0]);
                }

                // For the rest of saved instance modifiers, create a new instance modifier and
                // load its saved values from the source.
                for (int i = 1; i < instanceModifiersDataCount; i++)
                {
                    AddInstanceModifier(data.InstanceModifiersData[i]);
                }
            }

            void StitcherLoadedAction()
            {
                UpdateModifiersDisplay(isShowInstances: instancesCount > 1);
            }
        }


        // ----------------------------- Update Modifier Display -----------------------------
        /// /// <summary>
        /// Show root modifier and hide the instance modfiiers.
        /// </summary>
        void ShowRootModifier()
        {
            segment.MainBox.HideElement();
            rootModifier.MainBox.ShowElement();
        }


        /// <summary>
        /// Show instance modfiiers and hide the root modifier.
        /// </summary>
        void ShowInstanceModifiers()
        {
            segment.MainBox.ShowElement();
            rootModifier.MainBox.HideElement();
        }


        /// <summary>
        /// Update the modifiers display base on given boolean value.
        /// </summary>
        /// <param name="isShowInstances">Is show instance modifiers?</param>
        void UpdateModifiersDisplay(bool isShowInstances)
        {
            if (isShowInstances)
            {
                ShowInstanceModifiers();
            }
            else
            {
                ShowRootModifier();
            }
        }
    }
}