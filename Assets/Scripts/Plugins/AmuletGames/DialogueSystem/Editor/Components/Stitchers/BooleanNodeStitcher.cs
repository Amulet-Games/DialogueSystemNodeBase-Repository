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
        /// Temporary use of root modifier model.
        /// </summary>
        ConditionModifierModel_Legacy tempRootModifierModel;


        /// <summary>
        /// Constructor of the event node stitcher class.
        /// </summary>
        public BooleanNodeStitcher()
        {
            rootModifier = new();
            instanceModifiers = new();
            segment = new();
            tempRootModifierModel = new();
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
                    titleText: StringConfig.ConditionSegmentTitleLabelText,
                    titleBoxUSS01: StyleConfig.Segment_Condition_Title_Box,
                    contentBoxUSS01: StyleConfig.Segment_Condition_Content_Box
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
                AddInstanceModifier(model: null);
            }
        }


        /// <summary>
        /// Create a new instance modifier for the stitcher.
        /// </summary>
        /// <param name="model">The condition modifier model to set for.</param>
        void AddInstanceModifier(ConditionModifierModel_Legacy model)
        {
            new ConditionModifier().CreateInstanceElements
            (
                model: model,
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
                // Load the root modifier's model to the initial instance modifier.
                rootModifier.SaveModifierValue(tempRootModifierModel);
                instanceModifiers[0].LoadModifierValue(tempRootModifierModel);

                // and show instance modifiers only.
                ShowInstanceModifiers();
            }

            // Add a new instance modifier to the node.
            AddInstanceModifier(model: null);
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

                // Load model from the last modifier in segment list, to rooted modifier
                instanceModifiers[0].SaveModifierValue(tempRootModifierModel);
                rootModifier.LoadModifierValue(tempRootModifierModel);
            }
        }


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Save the stitcher values.
        /// </summary>
        /// <param name="model">The boolean node stitcher model to set for.</param>
        public void SaveStitcherValues(BooleanNodeStitcherModel model)
        {
            SaveRootModifier();

            SaveInstanceModifiers();

            void SaveRootModifier()
            {
                rootModifier.SaveModifierValue(model.RootModifierModel);
            }

            void SaveInstanceModifiers()
            {
                for (int i = 0; i < instancesCount; i++)
                {
                    // New modifier model.
                    ConditionModifierModel_Legacy newModifierModel = new();

                    // Save values.
                    instanceModifiers[i].SaveModifierValue(newModifierModel);

                    // Add to the model list.
                    model.InstanceModifiersModels.Add(newModifierModel);
                }
            }
        }


        /// <summary>
        /// Load the stitcher values.
        /// </summary>
        /// <param name="model">The boolean node stitcher model to set for.</param>
        public void LoadStitcherValues(BooleanNodeStitcherModel model)
        {
            LoadRootModifier();

            LoadInstanceModifiers();

            StitcherLoadedAction();

            void LoadRootModifier()
            {
                rootModifier.LoadModifierValue(model.RootModifierModel);
            }

            void LoadInstanceModifiers()
            {
                // Instance modifiers model count.
                var instanceModifiersModelCount = model.InstanceModifiersModels.Count;

                // Initial instance modifier is created together with the molder,
                // so here it only need to load its values from the source.
                if (instanceModifiersModelCount > 0)
                {
                    instanceModifiers[0].LoadModifierValue(model.InstanceModifiersModels[0]);
                }

                // For the rest of saved instance modifiers, create a new instance modifier and
                // load its saved values from the source.
                for (int i = 1; i < instanceModifiersModelCount; i++)
                {
                    AddInstanceModifier(model.InstanceModifiersModels[i]);
                }
            }

            void StitcherLoadedAction()
            {
                UpdateModifiersDisplay(isShowInstances: instancesCount > 1);
            }
        }


        // ----------------------------- Update Modifier Display -----------------------------
        /// /// <summary>
        /// Show root modifier and hide the instance modifiers.
        /// </summary>
        void ShowRootModifier()
        {
            segment.MainBox.HideElement();
            rootModifier.MainBox.ShowElement();
        }


        /// <summary>
        /// Show instance modifiers and hide the root modifier.
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