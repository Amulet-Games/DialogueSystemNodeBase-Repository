using UnityEngine.UIElements;

namespace AG.DS
{
    public class Segment
    {
        /// <summary>
        /// The box UIElement that stores the title and content section's visual elements.
        /// </summary>
        public Box MainBox;


        /// <summary>
        /// The box UIElement that stores all the visual elements that are next to the title's expand button.
        /// </summary>
        public Box TitleButtonBox;


        /// <summary>
        /// The box UIElement that stores all the visual elements that are included in the segment's content section.
        /// </summary>
        public Box ContentBox;


        /// <summary>
        /// Button that expand or shrink the segment's content when clicked.
        /// </summary>
        Button ExpandButton;


        /// <summary>
        /// Is the segment expanded?
        /// </summary>
        bool IsExpanded;


        // ----------------------------- Makers -----------------------------
        /// <summary>
        /// Create all the UIElements that are needed in the segment.
        /// </summary>
        /// <param name="node">Node of which this segment is created for.</param>
        /// <param name="titleText">The title text to set for the segment.</param>
        /// <param name="titleBoxUSS01">The first USS style to set for the segment title box.</param>
        /// <param name="contentBoxUSS01">The first USS style to set for the segment content box.</param>
        public void CreateRootElements
        (
            NodeBase node,
            string titleText,
            string titleBoxUSS01,
            string contentBoxUSS01
        )
        {
            // Title
            Box titleBox;
            Label titleLabel;

            SetupBoxContainer();

            SetupSegmentTitle();

            SetupExpandButton();

            AddFieldsToBox();

            AddBoxToMainContainer();

            SegmentCreatedAction();

            void SetupBoxContainer()
            {
                MainBox = new();
                MainBox.AddToClassList(StyleConfig.Segment_Common_Main_Box);

                titleBox = new();
                titleBox.AddToClassList(StyleConfig.Segment_Common_Title_Box);
                titleBox.AddToClassList(titleBoxUSS01);

                TitleButtonBox = new();
                TitleButtonBox.AddToClassList(StyleConfig.Segment_Common_Title_Button_Box);

                ContentBox = new();
                ContentBox.pickingMode = PickingMode.Ignore;
                ContentBox.AddToClassList(contentBoxUSS01);
            }

            void SetupSegmentTitle()
            {
                titleLabel = CommonLabelPresenter.CreateElement
                (
                    labelText: titleText,
                    labelUSS: StyleConfig.Segment_Common_Title_Label
                );
            }

            void SetupExpandButton()
            {
                ExpandButton = CommonButtonPresenter.CreateElement
                (
                    buttonSprite: ConfigResourcesManager.SpriteConfig.SegmentExpandButtonIconSprite,
                    buttonUSS: StyleConfig.Segment_Common_ExpandSegment_Button
                );

                new CommonButtonObserver(
                    isAlert: false,
                    button: ExpandButton,
                    clickEvent: ExpandButtonClickEvent).RegisterEvents();
            }

            void AddFieldsToBox()
            {
                MainBox.Add(titleBox);
                MainBox.Add(ContentBox);

                titleBox.Add(titleLabel);
                titleBox.Add(TitleButtonBox);
                titleBox.Add(ExpandButton);
            }

            void AddBoxToMainContainer()
            {
                //node.ContentContainer.Add(MainBox);
            }

            void SegmentCreatedAction()
            {
                // Expand the segment.
                SwitchSegmentIsExpanded();
            }
        }


        // ----------------------------- Callback -----------------------------
        /// <summary>
        /// The event to invoke when the expand button is clicked.
        /// </summary>
        /// <param name="evt">Registering event.</param>
        void ExpandButtonClickEvent(ClickEvent evt) => SwitchSegmentIsExpanded();


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Save the segment values.
        /// </summary>
        /// <param name="model">The segment model to set for.</param>
        public void SaveSegmentValues(SegmentModel model)
        {
            // Save IsExpanded
            model.IsExpanded = IsExpanded;
        }


        /// <summary>
        /// Load the segment values.
        /// </summary>
        /// <param name="model">The segment model to set for.</param>
        public void LoadSegmentValues(SegmentModel model)
        {
            // Load IsExpanded
            IsExpanded = model.IsExpanded;
            SetActiveSegmentContent();
        }


        // ----------------------------- IsExpanded Utility -----------------------------
        /// <summary>
        /// Set the current IsExpanded status to the new given value.
        /// </summary>
        public void SetIsExpanded(bool value)
        {
            if (IsExpanded != value)
            {
                IsExpanded = value;
                SetActiveSegmentContent();
            }
        }


        /// <summary>
        /// Switch the isExpanded status and resize itself to show the changes.
        /// </summary>
        public void SwitchSegmentIsExpanded()
        {
            IsExpanded = !IsExpanded;
            SetActiveSegmentContent();
        }


        // ----------------------------- Set Active Segment Content -----------------------------
        /// <summary>
        /// Activate or deactivate the segment content base on the current IsExpanded state.
        /// </summary>
        void SetActiveSegmentContent()
        {
            ContentBox.SetDisplay(value: IsExpanded);
        }
    }
}