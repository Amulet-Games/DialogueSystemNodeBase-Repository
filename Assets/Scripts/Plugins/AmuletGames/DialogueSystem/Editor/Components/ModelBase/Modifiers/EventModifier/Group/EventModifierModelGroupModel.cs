using System.Collections.Generic;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class EventModifierModelGroupModel
    {
        /// <summary>
        /// Modifiers cache.
        /// </summary>
        List<EventModifierModel> modifiersCache;


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
        public Box MainContainer;


        /// <summary>
        /// Temporary reference of the modifier that is in the first position of the group hirerachy.
        /// </summary>
        EventModifierModel tempFirstModifier;


        /// <summary>
        /// Temporary reference of the modifier that is in the last position of the group hirerachy.
        /// </summary>
        EventModifierModel tempLastModifier;


        /// <summary>
        /// Temporary reference of the modifier that is the only one exists in the group hirerachy.
        /// </summary>
        EventModifierModel tempSoleModifier;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the event modifier model group model class.
        /// </summary>
        public EventModifierModelGroupModel()
        {
            modifiersCache = new();
        }


        // ----------------------------- Callback -----------------------------
        /// <summary>
        /// The action to invoke when the move up button is clicked.
        /// </summary>
        /// <param name="modifier">The modifier of which the button belongs to.</param>
        void MoveUpButtonClickAction(EventModifierModel modifier)
        {
            // Swap-from element.
            var swapFromElement = modifier.FolderModel.MainContainer;

            // Swap-from element's sibling index.
            var swapFromIndex = MainContainer.IndexOf(swapFromElement);

            // Swap-to modifier.
            var swapToModifier = modifiersCache[swapFromIndex - 1];

            // Swap-to element.
            var swapToElement = swapToModifier.FolderModel.MainContainer;

            // Swap hirerachy position.
            modifiersCache[swapFromIndex - 1] = modifier;
            modifiersCache[swapFromIndex] = swapToModifier;

            // Move swap-from element upward.
            swapFromElement.PlaceBehind(swapToElement);

            SetEnabledMoveUpButton();
            SetEnabledMoveDownButton();

            void SetEnabledMoveUpButton()
            {
                // If the swap-from modifier is int the first position of the cache.
                if (modifier == modifiersCache[0])
                {
                    tempFirstModifier?.SetEnabledMoveUpButton(value: true);

                    modifier.SetEnabledMoveUpButton(value: false);

                    tempFirstModifier = modifier;
                }
            }

            void SetEnabledMoveDownButton()
            {
                // If the swap-to modifier is in the last position of the cache.
                if (swapToModifier == modifiersCache[cacheCount - 1])
                {
                    tempLastModifier?.SetEnabledMoveDownButton(value: true);

                    swapToModifier.SetEnabledMoveDownButton(value: false);

                    tempLastModifier = swapToModifier;
                }
            }
        }


        /// <summary>
        /// The action to invoke when the move down button is clicked.
        /// </summary>
        /// <param name="modifier">The modifier of which the button belongs to.</param>
        void MoveDownButtonClickAction(EventModifierModel modifier)
        {
            // Swap-from element.
            var swapFromElement = modifier.FolderModel.MainContainer;

            // Swap-from element's sibling index.
            var swapFromIndex = MainContainer.IndexOf(swapFromElement);

            // Swap-to modifier.
            var swapToModifier = modifiersCache[swapFromIndex + 1];

            // Swap-to element.
            var swapToElement = swapToModifier.FolderModel.MainContainer;

            // Swap hirerachy position.
            modifiersCache[swapFromIndex + 1] = modifier;
            modifiersCache[swapFromIndex] = swapToModifier;

            // Move swap-from element downward.
            swapFromElement.PlaceInFront(swapToElement);

            SetEnabledMoveUpButton();
            SetEnabledMoveDownButton();

            void SetEnabledMoveUpButton()
            {
                // If the swap-to modifier is in the first position of the cache.
                if (swapToModifier == modifiersCache[0])
                {
                    tempFirstModifier?.SetEnabledMoveUpButton(value: true);

                    swapToModifier.SetEnabledMoveUpButton(value: false);

                    tempFirstModifier = swapToModifier;
                }
            }

            void SetEnabledMoveDownButton()
            {
                // If the swap-from modifier is in the last position of the cache.
                if (modifier == modifiersCache[cacheCount - 1])
                {
                    tempLastModifier?.SetEnabledMoveDownButton(value: true);

                    modifier.SetEnabledMoveDownButton(value: false);

                    tempLastModifier = modifier;
                }
            }
        }


        /// <summary>
        /// The action to invoke when the rename button is clicked.
        /// </summary>
        /// <param name="modifier">The modifier of which the button belongs to.</param>
        void RenameButtonClickAction(EventModifierModel modifier)
        {
            modifier.FolderModel.EditFolderTitle();
        }


        /// <summary>
        /// The action to invoke when the remove button is clicked.
        /// </summary>
        /// <param name="modifier">The modifier of which the button belongs to.</param>
        void RemoveButtonClickAction(EventModifierModel modifier)
        {
            RemoveModifierFromCache();

            SetEnabledButtons();

            void RemoveModifierFromCache()
            {
                cacheCount--;

                modifiersCache.Remove(modifier);

                MainContainer.Remove(modifier.FolderModel.MainContainer);
            }

            void SetEnabledButtons()
            {
                if (cacheCount > 0)
                {
                    // If there's only one modifier left and it hasn't set to be the sole modifier yet.
                    if (cacheCount == 1)
                    {
                        modifiersCache[0].SetEnabledRemoveButton(value: false);

                        tempSoleModifier = modifiersCache[0];
                    }

                    // If the first position modifier has changed.
                    if (tempFirstModifier != modifiersCache[0])
                    {
                        modifiersCache[0].SetEnabledMoveUpButton(value: false);

                        tempFirstModifier = modifiersCache[0];
                    }

                    // If the last position's modifier has changed.
                    var bottomModifier = modifiersCache[cacheCount - 1];
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
        /// <summary>
        /// Save the group values to the given data.
        /// </summary>
        /// <param name="data">The data to save to.</param>
        public void Save(EventModifierModelGroupData data)
        {
            // Save modifiers.
            data.ModifiersData = new EventModifierData[cacheCount];
            for (int i = 0; i < cacheCount; i++)
            {
                data.ModifiersData[i] = new();
                modifiersCache[i].SaveModifierValue(data: data.ModifiersData[i]);
            }
        }


        /// <summary>
        /// Load the group values from the given data.
        /// </summary>
        /// <param name="data">The data to load from.</param>
        public void Load(EventModifierModelGroupData data)
        {
            LoadModifiersData();

            SetEnabledButtons();

            void LoadModifiersData()
            {
                EventModifierCallback callback = new();
                EventModifierModel model;

                cacheCount = data.ModifiersData.Length;
                for (int cacheIndex = 1; cacheIndex <= cacheCount; cacheIndex++)
                {
                    model = new();
                    EventModifierPresenter.CreateElements
                    (
                        model: model,
                        index: cacheIndex
                    );

                    callback.ResetInternal(
                        model: model,
                        moveUpButtonClickEvent: evt => MoveUpButtonClickAction(model),
                        moveDownButtonClickEvent: evt => MoveDownButtonClickAction(model),
                        renameButtonClickEvent: evt => RenameButtonClickAction(model),
                        removeButtonClickEvent: evt => RemoveButtonClickAction(model)).RegisterEvents();

                    model.LoadModifierValue(data: data.ModifiersData[cacheIndex - 1]);

                    MainContainer.Add(model.FolderModel.MainContainer);
                    modifiersCache.Add(model);
                }

                nextIndex = cacheCount + 1;
            }

            void SetEnabledButtons()
            {
                // If there's only one modifier in the group.
                if (cacheCount == 1)
                {
                    tempSoleModifier = modifiersCache[0];
                    tempSoleModifier.SetEnabledRemoveButton(value: false);
                }

                // If there's a modifier in the group.
                if (cacheCount > 0)
                {
                    tempFirstModifier = modifiersCache[0];
                    tempFirstModifier.SetEnabledMoveUpButton(value: false);

                    tempLastModifier = modifiersCache[cacheCount - 1];
                    tempLastModifier.SetEnabledMoveDownButton(value: false);
                }
            }
        }


        // ----------------------------- Create Modifier Service -----------------------------
        /// <summary>
        /// Method that is mainly used with content button, to create a new event modifier model to the group.
        /// </summary>
        public void CreateModifier()
        {
            EventModifierModel model;

            SetupModifier();

            AddModifierToCache();

            SetEnabledRemoveButton();

            SetEnabledMoveUpButton();

            SetEnabledMoveDownButton();

            UpdateCacheCount();

            ExecuteFolderCreatedAction();

            void SetupModifier()
            {
                model = new();
                EventModifierPresenter.CreateElements
                (
                    model: model,
                    index: nextIndex
                );

                new EventModifierCallback(
                    model: model,
                    moveUpButtonClickEvent: evt => MoveUpButtonClickAction(model),
                    moveDownButtonClickEvent: evt => MoveDownButtonClickAction(model),
                    renameButtonClickEvent: evt => RenameButtonClickAction(model),
                    removeButtonClickEvent: evt => RemoveButtonClickAction(model)).RegisterEvents();
            }

            void AddModifierToCache()
            {
                MainContainer.Add(model.FolderModel.MainContainer);
                modifiersCache.Add(model);
            }

            void SetEnabledRemoveButton()
            {
                // If the new modifier is the first modifier added to the group.
                if (cacheCount == 0)
                {
                    model.SetEnabledRemoveButton(value: false);

                    tempSoleModifier = model;
                }
                // If there's already a modifier exists in the group.
                else if (tempSoleModifier != null)
                {
                    tempSoleModifier.SetEnabledRemoveButton(value: true);

                    tempSoleModifier = null;
                }
            }

            void SetEnabledMoveUpButton()
            {
                // If the new modifier is in the first position of the group hirerachy.
                if (tempFirstModifier == null)
                {
                    model.SetEnabledMoveUpButton(value: false);

                    tempFirstModifier = model;
                }
            }

            void SetEnabledMoveDownButton()
            {
                // Enable the previous bottom position modifier's button.
                tempLastModifier?.SetEnabledMoveDownButton(value: true);

                model.SetEnabledMoveDownButton(value: false);

                tempLastModifier = model;
            }

            void UpdateCacheCount()
            {
                cacheCount++;
                nextIndex++;
            }

            void ExecuteFolderCreatedAction()
            {
                model.FolderModel.FolderCreatedAction();
            }
        }
    }
}