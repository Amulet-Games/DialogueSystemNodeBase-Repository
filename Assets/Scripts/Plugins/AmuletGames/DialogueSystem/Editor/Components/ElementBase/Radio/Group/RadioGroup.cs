using System;
using System.Linq;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class RadioGroup : VisualElement
    {
        /// <summary>
        /// The property of the radio elements cache.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Thrown when trying to initialize the radio elements cache twice.
        /// </exception>
        public Radio[] Radios
        {
            get
            {
                return m_radios;
            }
            set
            {
                if (m_radios != null)
                {
                    throw new ArgumentException("Attempted to set radio elements' cache twice!");
                }
                else
                {
                    for (int i = value.Length - 1; 0 <= i; i--)
                    {
                        Add(value[i]);
                    }

                    m_radios = value;

                    ActiveRadio = m_radios.Last();
                }
            }
        }


        /// <summary>
        /// The radio elements cache.
        /// </summary>
        Radio[] m_radios;


        /// <summary>
        /// The property of the active radio element.
        /// </summary>
        public Radio ActiveRadio
        {
            get
            {
                return m_activeRadio;
            }
            set
            {
                if (value == m_activeRadio)
                {
                    return;
                }

                value?.SetActive(true);
                m_activeRadio?.SetActive(false);
                m_activeRadio = value;
            }
        }


        /// <summary>
        /// The active radio element.
        /// </summary>
        Radio m_activeRadio;


        /// <summary>
        /// Constructor of the radio group element.
        /// </summary>
        /// <param name="radios">The radio elements array to set for.</param>
        public RadioGroup(Radio[] radios)
        {
            Radios = radios;
        }


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Save the radio group values.
        /// </summary>
        /// <param name="data">The radio group data to set for.</param>
        public void Save(RadioGroupData data)
        {
            data.activeRadioIndex = Radios.IndexOf(ActiveRadio);
        }


        /// <summary>
        /// Load the radio group values.
        /// </summary>
        /// <param name="data">The radio group data to set for.</param>
        public void Load(RadioGroupData data)
        {
            ActiveRadio = Radios[data.activeRadioIndex];
        }
    }
}