using System.Collections.Generic;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class EventModifierViewGroupView
    {
        /// <summary>
        /// The event modifier views cache.
        /// </summary>
        public List<EventModifierView> Modifiers { get; private set; }


        /// <summary>
        /// The event modifier views cache counter.
        /// </summary>
        public int ModifiersCount { get; private set; } = 0;


        /// <summary>
        /// Index of the next modifier.
        /// </summary>
        public int NextIndex { get; private set; } = 1;


        /// <summary>
        /// Element that contains the group modifiers.
        /// </summary>
        public VisualElement GroupContainer;


        /// <summary>
        /// The property of the modifier that is in the first position of the group view.
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
        /// Reference of the modifier that is in the first position of the group view.
        /// </summary>
        EventModifierView m_firstModifier;


        /// <summary>
        /// The property of the modifier that is in the last position of the group view.
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
        /// Reference of the modifier that is in the last position of the group view.
        /// </summary>
        EventModifierView m_lastModifier;


        /// <summary>
        /// The property of the modifier that is the only one exists in the group view.
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
        /// Reference of the modifier that is the only one exists in the group view.
        /// </summary>
        EventModifierView m_soleModifier;


        /// <summary>
        /// Constructor of the event modifier view group view class.
        /// </summary>
        public EventModifierViewGroupView()
        {
            Modifiers = new();
        }


        // ----------------------------- Service -----------------------------
        /// <summary>
        /// Swap the position of the given modifier's and the up or down's modifier within the group view.
        /// </summary>
        /// <param name="modifier">The swap from modifier to set for.</param>
        /// <param name="swapUp">The swap up value to set for.</param>
        public void Swap(EventModifierView modifier, bool swapUp)
        {
            var swapFromIndex = Modifiers.IndexOf(modifier);

            var swapToIndex = swapFromIndex + (swapUp ? -1 : 1);

            var swapToModifier = Modifiers[swapToIndex];

            // Swap array
            {
                Modifiers[swapToIndex] = modifier;
                Modifiers[swapFromIndex] = swapToModifier;
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

            UpdateModifiersReferences();
        }


        /// <summary>
        /// Remove the given event modifier view from the group view.
        /// </summary>
        /// <param name="modifier">The event modifier view to set for.</param>
        public void Remove(EventModifierView modifier)
        {
            ModifiersCount--;

            Modifiers.Remove(modifier);

            GroupContainer.Remove(modifier.Folder);
        }


        /// <summary>
        /// Add the given event modifier view to the group view.
        /// </summary>
        /// <param name="modifier">The event modifier view to set for.</param>
        public void Add(EventModifierView modifier)
        {
            ModifiersCount++;

            Modifiers.Add(modifier);

            GroupContainer.Add(modifier.Folder);

            NextIndex++;
        }


        /// <summary>
        /// Update the group view's first, last and sole modifier references.
        /// </summary>
        public void UpdateModifiersReferences()
        {
            if (ModifiersCount > 0)
            {
                FirstModifier = Modifiers[0];
                LastModifier = Modifiers[ModifiersCount - 1];
                SoleModifier = ModifiersCount == 1 ? Modifiers[0] : null;
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