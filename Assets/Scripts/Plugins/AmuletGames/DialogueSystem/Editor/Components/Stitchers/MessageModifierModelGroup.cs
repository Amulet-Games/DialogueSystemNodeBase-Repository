using System.Collections.Generic;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class MessageModifierModelGroup
    {
        /// <summary>
        /// Modifiers cache.
        /// </summary>
        List<MessageModifier> modifiers;


        /// <summary>
        /// Modifiers cache counter.
        /// </summary>
        int cacheCount = 0;


        /// <summary>
        /// The index of the next modifier.
        /// </summary>
        int nextIndex = 1;


        /// <summary>
        /// The element that contains the modifiers in the group.
        /// </summary>
        Box modifierContainer;


        /// <summary>
        /// Temporary reference of the modifier that is in the first position of the group hirerachy.
        /// </summary>
        MessageModifier tempFirstModifier;


        /// <summary>
        /// Temporary reference of the modifier that is in the last position of the group hirerachy.
        /// </summary>
        MessageModifier tempLastModifier;


        /// <summary>
        /// Temporary reference of the modifier that is the only one exists in the group hirerachy.
        /// </summary>
        MessageModifier tempSoleModifier;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the message modifier model group class.
        /// </summary>
        public MessageModifierModelGroup()
        {
            modifiers = new();
        }


        // ----------------------------- Makers -----------------------------
        /// <summary>
        /// Create all the UIElements for the message modifier model group.
        /// </summary>
        /// <param name="node">Node of which this stitcher is created for.</param>
        public void CreateElements(NodeBase node)
        {
            SetupContentButton();

            SetupBoxContainers();

            AddFieldsToBox();

            StitcherCreatedAction();

            void SetupContentButton()
            {
                //ContentButtonPresenter.CreateElements
                //(
                //    node: node,
                //    buttonText: StringConfig.Instance.AddMessageLabelText,
                //    buttonIconSprite: SpriteConfig.Instance.AddMessageModifierButtonIconSprite,
                //    buttonClickAction: ContentButtonClickAction
                //);
            }

            void SetupBoxContainers()
            {
                modifierContainer = new();
                modifierContainer.AddToClassList(StyleConfig.Instance.MessageModifierGroup_Content_Container);
            }

            void AddFieldsToBox()
            {
                node.ContentContainer.Add(modifierContainer);
            }

            void StitcherCreatedAction()
            {
                // Add the first instance modifier.
                AddInstanceModifier(data: null);
            }
        }


        /// <summary>
        /// Create a new instance modifier for the stitcher.
        /// </summary>
        /// <param name="data">The given modifier data to load from.</param>
        void AddInstanceModifier(MessageModifierData data)
        {
            new MessageModifier().CreateInstanceElements
            (
                index: nextIndex,
                data: data,
                modifierCreatedAction: ModifierCreatedAction,
                moveUpButtonClickAction: MoveUpButtonClickAction,
                moveDownButtonClickAction: MoveDownButtonClickAction,
                renameButtonClickAction: RenameButtonClickAction,
                removeButtonClickAction: RemoveButtonClickAction
            );
        }


        // ----------------------------- Callback -----------------------------
        /// <summary>
        /// The action to invoke when the content button is clicked.
        /// <para>See: <see cref="CreateElements"/></para>
        /// </summary>
        void ContentButtonClickAction()
        {
            // Add a new instance modifier to the node.
            AddInstanceModifier(data: null);
        }


        /// <summary>
        /// The action to invoke when a modifier is created.
        /// </summary>
        /// <param name="modifier">The new created modifier.</param>
        void ModifierCreatedAction(MessageModifier modifier)
        {
            AddModifierToCache();

            SetEnabledRemoveButton();

            SetEnabledMoveUpButton();

            SetEnabledMoveDownButton();

            UpdateCacheCount();

            RenameFolderInitially();

            void AddModifierToCache()
            {
                // Add modifier folder's main box to the stitcher. 
                modifierContainer.Add(modifier.Folder.MainContainer);

                // Add modifier to the internal cache.
                modifiers.Add(modifier);
            }

            void SetEnabledRemoveButton()
            {
                // If the new modifier is the first modifier added to the cache.
                if (cacheCount == 0)
                {
                    // Disable the new first and only modifier's button
                    modifier.SetEnabledRemoveButton(value: false);

                    // Set temporary reference.
                    tempSoleModifier = modifier;
                }
                else if (tempSoleModifier != null)
                {
                    // Enable the previous first and only modifier's button.
                    tempSoleModifier.SetEnabledRemoveButton(value: true);

                    // Null out temporary reference.
                    tempSoleModifier = null;
                }
            }

            void SetEnabledMoveUpButton()
            {
                // If the new modifier is at the top of the cache.
                if (tempFirstModifier == null)
                {
                    // Disable the new top position modifier's button.
                    modifier.SetEnabledMoveUpButton(value: false);

                    // Set temporary reference.
                    tempFirstModifier = modifier;
                }
            }

            void SetEnabledMoveDownButton()
            {
                // Enable the previous bottom position modifier's button.
                tempLastModifier?.SetEnabledMoveDownButton(value: true);

                // Disable the new bottom position modifier's button.
                modifier.SetEnabledMoveDownButton(value: false);

                // Set temporary reference.
                tempLastModifier = modifier;
            }

            void UpdateCacheCount()
            {
                // Increase cache count.
                cacheCount++;
                // Increase creation count.
                nextIndex++;
            }

            void RenameFolderInitially()
            {
                // Call to rename folder when it's first created.
                modifier.Folder.EditFolderTitle();
            }
        }


        /// <summary>
        /// The action to invoke when the modifier's move up button is clicked.
        /// </summary>
        /// <param name="modifier">The targeting modifier.</param>
        void MoveUpButtonClickAction(MessageModifier modifier)
        {
            // Swap-from element.
            var swapFromElement = modifier.Folder.MainContainer;

            // Swap-from element's sibling index.
            var swapFromIndex = modifierContainer.IndexOf(swapFromElement);

            // Swap-to modifier.
            var swapToModifier = modifiers[swapFromIndex - 1];

            // Swap-to element.
            var swapToElement = swapToModifier.Folder.MainContainer;

            // Swap hirerachy position.
            modifiers[swapFromIndex - 1] = modifier;
            modifiers[swapFromIndex] = swapToModifier;

            // Move swap-from element upward.
            swapFromElement.PlaceBehind(swapToElement);

            SetEnabledMoveUpButton();
            SetEnabledMoveDownButton();

            void SetEnabledMoveUpButton()
            {
                // If the swap-from modifier is at the top of the cache.
                if (modifier == modifiers[0])
                {
                    // Enable the previous top position modifier's button.
                    tempFirstModifier?.SetEnabledMoveUpButton(value: true);

                    // Disable the swap-from modifier's button.
                    modifier.SetEnabledMoveUpButton(value: false);

                    // Set temporary reference.
                    tempFirstModifier = modifier;
                }
            }

            void SetEnabledMoveDownButton()
            {
                // If the swap-to modifier is at the bottom of the cache.
                if (swapToModifier == modifiers[cacheCount - 1])
                {
                    // Enable the previous bottom position modifier's button.
                    tempLastModifier?.SetEnabledMoveDownButton(value: true);

                    // Disable the swap-to modifier's button.
                    swapToModifier.SetEnabledMoveDownButton(value: false);

                    // Set temporary reference.
                    tempLastModifier = swapToModifier;
                }
            }
        }


        /// <summary>
        /// The action to invoke when the modifier's move down button is clicked.
        /// </summary>
        /// <param name="modifier">The targeting modifier.</param>
        void MoveDownButtonClickAction(MessageModifier modifier)
        {
            // Swap-from element.
            var swapFromElement = modifier.Folder.MainContainer;

            // Swap-from element's sibling index.
            var swapFromIndex = modifierContainer.IndexOf(swapFromElement);

            // Swap-to modifier.
            var swapToModifier = modifiers[swapFromIndex + 1];

            // Swap-to element.
            var swapToElement = swapToModifier.Folder.MainContainer;

            // Swap hirerachy position.
            modifiers[swapFromIndex + 1] = modifier;
            modifiers[swapFromIndex] = swapToModifier;

            // Move swap-from element downward.
            swapToElement.PlaceInFront(swapFromElement);

            SetEnabledMoveUpButton();
            SetEnabledMoveDownButton();

            void SetEnabledMoveUpButton()
            {
                // If the swap-to modifier is at the top of the cache.
                if (swapToModifier == modifiers[0])
                {
                    // Enable the previous top position modifier's button.
                    tempFirstModifier?.SetEnabledMoveUpButton(value: true);

                    // Disable the swap-to modifier's button.
                    swapToModifier.SetEnabledMoveUpButton(value: false);

                    // Set temporary reference.
                    tempFirstModifier = swapToModifier;
                }
            }

            void SetEnabledMoveDownButton()
            {
                // If the swap-from modifier is at the bottom of the cache.
                if (modifier == modifiers[cacheCount - 1])
                {
                    // Enable the previous bottom position modifier's button.
                    tempLastModifier?.SetEnabledMoveDownButton(value: true);

                    // Disable the swap-from modifier's button.
                    modifier.SetEnabledMoveDownButton(value: false);

                    // Set temporary reference.
                    tempLastModifier = modifier;
                }
            }
        }


        /// <summary>
        /// The action to invoke when the modifier's rename button is clicked.
        /// </summary>
        /// <param name="modifier">The targeting modifier.</param>
        void RenameButtonClickAction(MessageModifier modifier)
        {
            // Call to rename folder.
            modifier.Folder.EditFolderTitle();
        }


        /// <summary>
        /// The action to invoke when the modifier's remove button is clicked.
        /// </summary>
        /// <param name="modifier">The targeting modifier.</param>
        void RemoveButtonClickAction(MessageModifier modifier)
        {
            RemoveModifierFromCache();

            SetEnabledButtons();

            void RemoveModifierFromCache()
            {
                // Decrease cache count.
                cacheCount--;

                // Remove the modifier from the cache.
                modifiers.Remove(modifier);

                // Remove the element from the group container.
                modifierContainer.Remove(modifier.Folder.MainContainer);
            }

            void SetEnabledButtons()
            {
                if (cacheCount > 0)
                {
                    // If there's only one modifier left and it hasn't set to be the sole modifier yet.
                    if (cacheCount == 1 && tempSoleModifier != modifiers[0])
                    {
                        modifiers[0].SetEnabledRemoveButton(value: false);

                        tempSoleModifier = modifiers[0];
                    }

                    // If the top position has changed.
                    if (tempFirstModifier != modifiers[0])
                    {
                        modifiers[0].SetEnabledMoveUpButton(value: false);

                        tempFirstModifier = modifiers[0];
                    }

                    // If the bottom position has changed.
                    var bottomModifier = modifiers[cacheCount - 1];
                    if (tempLastModifier != bottomModifier)
                    {
                        bottomModifier.SetEnabledMoveDownButton(value: false);

                        tempLastModifier = bottomModifier;
                    }
                }
                else
                {
                    // If there's no modifier left.
                    tempSoleModifier = null;
                    tempFirstModifier = null;
                    tempLastModifier = null;
                }
            }
        }


        // ----------------------------- Serialization -----------------------------
        public void SaveStitcherValues(DialogueNodeStitcherData data)
        {
            // instance modifiers
            // creation count
        }


        public void LoadStitcherValues(DialogueNodeStitcherData data)
        {

        }
    }
}