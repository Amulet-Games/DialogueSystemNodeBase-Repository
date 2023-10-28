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
        /// 
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
                    throw new ArgumentException("Attempted to set radio group's cache twice!");
                }
                else
                {
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
        /// The property of the active radio element of the group.
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
        /// Reference of the active radio element of the group.
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
        /// <param name="model">The radio group model to set for.</param>
        public void Save(RadioGroupModel model)
        {
            model.activeRadioIndex = Radios.IndexOf(ActiveRadio);
        }


        /// <summary>
        /// Load the radio group values.
        /// </summary>
        /// <param name="model">The radio group model to set for.</param>
        public void Load(RadioGroupModel model)
        {
            ActiveRadio = Radios[model.activeRadioIndex];
        }
    }
}