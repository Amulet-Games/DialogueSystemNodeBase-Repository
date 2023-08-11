using System.Collections.Generic;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class EventModifierGroupView
    {
        /// <summary>
        /// Cache of the event modifiers that are within the group.
        /// </summary>
        List<EventModifierView> modifiers;


        /// <summary>
        /// The event modifiers cache counter.
        /// </summary>
        int modifiersCount = 0;


        /// <summary>
        /// Index of the next modifier.
        /// </summary>
        public int NextIndex { get; private set; } = 1;


        /// <summary>
        /// Element that contains the group modifiers.
        /// </summary>
        public Box GroupContainer;


        /// <summary>
        /// The property of the modifier that is in the first position of the group.
        /// </summary>
        public EventModifierView FirstModifier
        {
            get
            {
                return m_firstModifier;
            }
            private set
            {
                if (value == m_firstModifier)
                {
                    return;
                }

                value?.SetEnabledMoveUpButton(value: false);
                m_firstModifier?.SetEnabledMoveUpButton(value: true);
                m_firstModifier = value;
            }
        }


        /// <summary>
        /// Reference of the modifier that is in the first position of the group.
        /// </summary>
        EventModifierView m_firstModifier;


        /// <summary>
        /// The property of the modifier that is in the last position of the group.
        /// </summary>
        public EventModifierView LastModifier
        {
            get
            {
                return m_lastModifier;
            }
            private set
            {
                if (value == m_lastModifier)
                {
                    return;
                }

                value?.SetEnabledMoveDownButton(value: false);
                m_lastModifier?.SetEnabledMoveDownButton(value: true);
                m_lastModifier = value;
            }
        }

        /// <summary>
        /// Reference of the modifier that is in the last position of the group.
        /// </summary>
        EventModifierView m_lastModifier;


        /// <summary>
        /// The property of the modifier that is the only one exists in the group.
        /// </summary>
        public EventModifierView SoleModifier
        {
            get
            {
                return m_soleModifier;
            }
            private set
            {
                if (value == null)
                {
                    m_soleModifier?.SetEnabledRemoveButton(value: true);
                }
                else
                {
                    value.SetEnabledRemoveButton(value: false);
                }

                m_soleModifier = value;
            }
        }


        /// <summary>
        /// Reference of the modifier that is the only one exists in the group.
        /// </summary>
        EventModifierView m_soleModifier;


        /// <summary>
        /// Constructor of the event modifier group view class.
        /// </summary>
        public EventModifierGroupView()
        {
            modifiers = new();
        }


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Save the group values to the event modifier group model.
        /// </summary>
        /// <param name="model">The event modifier group model to set for.</param>
        public void Save(EventModifierGroupModel model)
        {
            model.ModifierModels = new EventModifierModel[modifiersCount];

            for (int i = 0; i < modifiersCount; i++)
            {
                model.ModifierModels[i] = new();

                modifiers[i].SaveModifierValue(model: model.ModifierModels[i]);
            }
        }


        /// <summary>
        /// Load the group values from the event modifier group model.
        /// </summary>
        /// <param name="model">The event modifier group model to set for.</param>
        public void Load(EventModifierGroupModel model)
        {
            modifiersCount = model.ModifierModels.Length;

            // Load modifiers
            {
                for (int i = 0; i <= modifiersCount; i++)
                {
                    var modifier = new EventModifierSeeder().Generate(
                        groupView: this,
                        model: model.ModifierModels[i]
                    );

                    Add(modifier);
                }
            }
            
            UpdateReferences();
        }


        // ----------------------------- Service -----------------------------
        /// <summary>
        /// Swap the position of the given modifier's and the up or down's modifier within the group.
        /// </summary>
        /// <param name="modifier">The swap from modifier to set for.</param>
        /// <param name="swapUp">The swap up value to set for.</param>
        public void Swap(EventModifierView modifier, bool swapUp)
        {
            var swapFromIndex = modifiers.IndexOf(modifier);

            var swapToIndex = swapFromIndex + (swapUp ? -1 : 1);

            var swapToModifier = modifiers[swapToIndex];

            // Swap array
            {
                modifiers[swapToIndex] = modifier;
                modifiers[swapFromIndex] = swapToModifier;
            }

            // Swap element
            {
                var swapFromElement = modifier.Folder;
                var swapToElement = swapToModifier.Folder;

                if (swapUp)
                {
                    swapFromElement.PlaceBehind(swapToElement);
                }
                else
                {
                    swapFromElement.PlaceInFront(swapToElement);
                }
            }

            UpdateReferences();
        }


        /// <summary>
        /// Remove the given event modifier view from the group.
        /// </summary>
        /// <param name="modifier">The event modifier view to set for.</param>
        public void Remove(EventModifierView modifier)
        {
            modifiersCount--;

            modifiers.Remove(modifier);

            GroupContainer.Remove(modifier.Folder);
        }


        /// <summary>
        /// Add the given event modifier view to the group.
        /// </summary>
        /// <param name="modifier">The event modifier view to set for.</param>
        public void Add(EventModifierView modifier)
        {
            modifiersCount++;

            modifiers.Add(modifier);

            GroupContainer.Add(modifier.Folder);

            NextIndex++;
        }


        /// <summary>
        /// Update the group's first, last and sole modifier references.
        /// </summary>
        public void UpdateReferences()
        {
            if (modifiersCount > 0)
            {
                FirstModifier = modifiers[0];
                LastModifier = modifiers[modifiersCount - 1];
                SoleModifier = modifiersCount == 1 ? modifiers[0] : null;
            }
            else
            {
                FirstModifier = null;
                LastModifier = null;
                SoleModifier = null;
            }
        }
    }
}