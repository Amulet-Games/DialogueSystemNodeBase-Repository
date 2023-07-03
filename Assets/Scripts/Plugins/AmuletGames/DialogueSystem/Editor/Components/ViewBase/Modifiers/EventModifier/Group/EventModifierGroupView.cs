using System.Collections.Generic;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class EventModifierGroupView
    {
        /// <summary>
        /// Modifiers cache.
        /// </summary>
        List<EventModifierView> modifiersCache;


        /// <summary>
        /// Modifiers cache counter.
        /// </summary>
        int modelCount = 0;


        /// <summary>
        /// The index of the next modifier.
        /// </summary>
        int nextIndex = 1;


        /// <summary>
        /// The element that contains all the modifiers within the group.
        /// </summary>
        public Box GroupContainer;


        /// <summary>
        /// Temporary reference of the modifier that is in the first position of the group hierarchy.
        /// </summary>
        EventModifierView tempFirstModifier;


        /// <summary>
        /// Temporary reference of the modifier that is in the last position of the group hierarchy.
        /// </summary>
        EventModifierView tempLastModifier;


        /// <summary>
        /// Temporary reference of the modifier that is the only one exists in the group hierarchy.
        /// </summary>
        EventModifierView tempSoleModifier;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the event modifier group view class.
        /// </summary>
        public EventModifierGroupView()
        {
            modifiersCache = new();
        }


        // ----------------------------- Callback -----------------------------
        /// <summary>
        /// The action to invoke when the move up button is clicked.
        /// </summary>
        /// <param name="modifier">The modifier of which the button belongs to.</param>
        void MoveUpButtonClickAction(EventModifierView modifier)
        {
            // Swap-from element.
            var swapFromElement = modifier.Folder;

            // Swap-from element's sibling index.
            var swapFromIndex = GroupContainer.IndexOf(swapFromElement);

            // Swap-to modifier.
            var swapToModifier = modifiersCache[swapFromIndex - 1];

            // Swap-to element.
            var swapToElement = swapToModifier.Folder;

            // Swap hierarchy position.
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
                if (swapToModifier == modifiersCache[modelCount - 1])
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
        void MoveDownButtonClickAction(EventModifierView modifier)
        {
            // Swap-from element.
            var swapFromElement = modifier.Folder;

            // Swap-from element's sibling index.
            var swapFromIndex = GroupContainer.IndexOf(swapFromElement);

            // Swap-to modifier.
            var swapToModifier = modifiersCache[swapFromIndex + 1];

            // Swap-to element.
            var swapToElement = swapToModifier.Folder;

            // Swap hierarchy position.
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
                if (modifier == modifiersCache[modelCount - 1])
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
        void RenameButtonClickAction(EventModifierView modifier)
        {
            modifier.Folder.EditFolderTitle();
        }


        /// <summary>
        /// The action to invoke when the remove button is clicked.
        /// </summary>
        /// <param name="modifier">The modifier of which the button belongs to.</param>
        void RemoveButtonClickAction(EventModifierView modifier)
        {
            RemoveModifierFromCache();

            SetEnabledButtons();

            void RemoveModifierFromCache()
            {
                modelCount--;

                modifiersCache.Remove(modifier);

                GroupContainer.Remove(modifier.Folder);
            }

            void SetEnabledButtons()
            {
                if (modelCount > 0)
                {
                    // If there's only one modifier left and it hasn't set to be the sole modifier yet.
                    if (modelCount == 1)
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
                    var bottomModifier = modifiersCache[modelCount - 1];
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
        /// Save the group values to the event modifier group model.
        /// </summary>
        /// <param name="model">The event modifier group model to set for.</param>
        public void Save(EventModifierGroupModel model)
        {
            // Save modifiers.
            model.ModifierModels = new EventModifierModel[modelCount];
            for (int i = 0; i < modelCount; i++)
            {
                model.ModifierModels[i] = new();
                modifiersCache[i].SaveModifierValue(model: model.ModifierModels[i]);
            }
        }


        /// <summary>
        /// Load the group values from the event modifier group model.
        /// </summary>
        /// <param name="model">The event modifier group model to set for.</param>
        public void Load(EventModifierGroupModel model)
        {
            LoadModifierModels();

            SetEnabledButtons();

            void LoadModifierModels()
            {
                modelCount = model.ModifierModels.Length;
                for (int modifierIndex = 1; modifierIndex <= modelCount; modifierIndex++)
                {
                    EventModifierView view = new();
                    EventModifierPresenter.CreateElement
                    (
                        view: view,
                        index: modifierIndex
                    );

                    new EventModifierCallback
                    (
                        view: view,
                        moveUpButtonClickEvent: evt => MoveUpButtonClickAction(view),
                        moveDownButtonClickEvent: evt => MoveDownButtonClickAction(view),
                        renameButtonClickEvent: evt => RenameButtonClickAction(view),
                        removeButtonClickEvent: evt => RemoveButtonClickAction(view)
                    )
                    .RegisterEvents();

                    view.LoadModifierValue(model: model.ModifierModels[modifierIndex - 1]);

                    GroupContainer.Add(view.Folder);
                    modifiersCache.Add(view);
                }

                nextIndex = modelCount + 1;
            }

            void SetEnabledButtons()
            {
                // If there's only one modifier in the group.
                if (modelCount == 1)
                {
                    tempSoleModifier = modifiersCache[0];
                    tempSoleModifier.SetEnabledRemoveButton(value: false);
                }

                // If there's a modifier in the group.
                if (modelCount > 0)
                {
                    tempFirstModifier = modifiersCache[0];
                    tempFirstModifier.SetEnabledMoveUpButton(value: false);

                    tempLastModifier = modifiersCache[modelCount - 1];
                    tempLastModifier.SetEnabledMoveDownButton(value: false);
                }
            }
        }


        // ----------------------------- Service -----------------------------
        /// <summary>
        /// Method that is mainly used with content button, to create a new event modifier view to the group.
        /// </summary>
        public void CreateModifier()
        {
            EventModifierView view;

            SetupModifier();

            AddModifierToCache();

            SetEnabledRemoveButton();

            SetEnabledMoveUpButton();

            SetEnabledMoveDownButton();

            OnModifierCreated();

            void SetupModifier()
            {
                view = new();
                EventModifierPresenter.CreateElement
                (
                    view: view,
                    index: nextIndex
                );

                new EventModifierCallback
                (
                    view: view,
                    moveUpButtonClickEvent: evt => MoveUpButtonClickAction(view),
                    moveDownButtonClickEvent: evt => MoveDownButtonClickAction(view),
                    renameButtonClickEvent: evt => RenameButtonClickAction(view),
                    removeButtonClickEvent: evt => RemoveButtonClickAction(view)
                )
                .RegisterEvents();

                GroupContainer.Add(view.Folder);
            }

            void AddModifierToCache()
            {
                modifiersCache.Add(view);
                modelCount++;
                nextIndex++;
            }

            void SetEnabledRemoveButton()
            {
                // If the new modifier is the first modifier added to the group.
                if (modelCount == 1)
                {
                    view.SetEnabledRemoveButton(value: false);

                    tempSoleModifier = view;
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
                // If the new modifier is in the first position of the group hierarchy.
                if (tempFirstModifier == null)
                {
                    view.SetEnabledMoveUpButton(value: false);

                    tempFirstModifier = view;
                }
            }

            void SetEnabledMoveDownButton()
            {
                // Enable the previous bottom position modifier's button.
                tempLastModifier?.SetEnabledMoveDownButton(value: true);

                view.SetEnabledMoveDownButton(value: false);

                tempLastModifier = view;
            }

            void OnModifierCreated()
            {
                view.Folder.SetIsExpand(value: false);
                view.Folder.EditFolderTitle();
            }
        }
    }
}