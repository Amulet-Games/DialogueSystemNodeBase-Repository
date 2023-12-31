using System;
using System.Linq;

namespace AG.DS
{
    public class BindingFlags : EnumFlagsFrameBase<BindingFlags.Bindings>
    {
        [Flags]
        public enum Bindings
        {
            None = 0,
            Instance = 4,
            Static = 8,
            Public = 16,
            Private = 32
        }


        /// <summary>
        /// The all type flag element.
        /// </summary>
        public FlagElement<Bindings> AllTypeFlagElement;


        /// <inheritdoc/>
        public override FlagElement<Bindings>[] FlagElements
        {
            get
            {
                return m_flagElements;
            }
            set
            {
                if (m_flagElements != null)
                {
                    throw new ArgumentException("Attempted to set the enum flags elements cache twice!");
                }
                else
                {
                    for (int i = 0; i < value.Length; i++)
                    {
                        EnumFlagsMenu.Add(value[i]);
                    }

                    m_flagElements = value;

                    FlagElements.First().ShowFirstElementStyle();
                    m_flagElements.Last().ShowLastElementStyle();
                }
            }
        }
        

        /// <inheritdoc/>
        public override Bindings SelectedFlags
        {
            get
            {
                return m_selectedFlags;
            }
            set
            {
                m_selectedFlags = value;

                UpdateFlagsDisplay();

                SelectedFlagsChangedEvent?.Invoke();
            }
        }


        /// <summary>
        /// Constructor of the binding flags element.
        /// </summary>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        public BindingFlags(GraphViewer graphViewer) : base(graphViewer)
        {
        }


        // ----------------------------- Service -----------------------------
        /// <inheritdoc/>
        protected override void AddFlag(Bindings value) => SelectedFlags |= value;


        /// <inheritdoc/>
        protected override void RemoveFlag(Bindings value) => SelectedFlags &= ~value;


        /// <summary>
        /// Update the enum flags display.
        /// </summary>
        void UpdateFlagsDisplay()
        {
            var allFlag = m_selectedFlags == AllTypeFlagElement.Flag;
            if (allFlag)
            {
                for (int i = 0; i < FlagElements.Length; i++)
                {
                    FlagElements[i].SetSelected(true);
                }
            }
            else
            {
                for (int i = 0; i < FlagElements.Length; i++)
                {
                    FlagElements[i].SetSelected(SelectedFlags.HasFlag(FlagElements[i].Flag));
                }

                // If the selected flag is None, automatically select the second flag element by default.
                if (m_selectedFlags == 0)
                {
                    LastSelectedFlagElement = FlagElements[1];
                }
            }

            EnumFlagsButtonTextLabel.text = allFlag
                ? StringConfig.ConditionModifier_BindingFlags_FlagElement_All_LabelText
                : m_selectedFlags.ToString();
        }
    }
}