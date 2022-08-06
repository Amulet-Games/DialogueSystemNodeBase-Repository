using System;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace AG
{
    [Serializable]
    public class ConditionModifier : DSModifierFrameBase<ConditionModifier>
    {
        /// <summary>
        /// Text container for the name of condition.
        /// </summary>
        public TextContainer ConditionName_TextContainer;


        /// <summary>
        /// Float container for the value that is used for comparison.
        /// </summary>
        public FloatContainer ComparisonNumber_FloatContainer;


        /// <summary>
        /// Enum container for how the user want to compare the value in this condition.
        /// </summary>
        public ConditionComparisonTypeEnumContainer ComparisonType_EnumContainer;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of condition modifier
        /// </summary>
        public ConditionModifier()
        {
            ConditionName_TextContainer = new TextContainer();
            ComparisonNumber_FloatContainer = new FloatContainer();
            ComparisonType_EnumContainer = new ConditionComparisonTypeEnumContainer();
        }


        // ----------------------------- Makers -----------------------------
        /// <summary>
        /// Create all the UIElements that are needed in this modifier as root.
        /// </summary>
        /// <param name="node">Node of which this modifier is created for.</param>
        public override void SetupRootModifier(DSNodeBase node)
        {
            TextField conditionNameField;
            FloatField comparisonNumberField;
            EnumField comparisonTypeField;

            SetupModifierBox();

            SetupTextField();

            SetupFloatField();

            SetupEnumField();

            AddFieldsToBox();

            AddBoxToSegmentContentContainer();

            ModifierPostSetupAction();

            void SetupModifierBox()
            {
                MainBox = new Box();
                MainBox.AddToClassList(DSStylesConfig.modifier_Condition_MainBox);
            }

            void SetupTextField()
            {
                conditionNameField = DSTextFieldsMaker.GetNewTextField(ConditionName_TextContainer, "Condition Name", DSStylesConfig.modifier_Condition_Rooted_TextField);
            }

            void SetupFloatField()
            {
                comparisonNumberField = DSFloatFieldsMaker.GetNewFloatField(ComparisonNumber_FloatContainer, DSStylesConfig.modifier_Condition_Rooted_FloatField);
            }

            void SetupEnumField()
            {
                comparisonTypeField = DSEnumFieldsMaker.GetNewEnumField(ComparisonType_EnumContainer, () => ToggleFloatFieldVisibleAction(), DSStylesConfig.modifier_Condition_Rooted_EnumField);
            }

            void AddFieldsToBox()
            {
                MainBox.Add(conditionNameField);
                MainBox.Add(comparisonTypeField);
                MainBox.Add(comparisonNumberField);
            }

            void AddBoxToSegmentContentContainer()
            {
                node.mainContainer.Add(MainBox);
            }

            void ModifierPostSetupAction()
            {
                ToggleFloatFieldVisibleAction();
            }
        }


        // ----------------------------- Callbacks -----------------------------
        /// <summary>
        /// Hide modifier's float field when the condition compare type is set to boolean's type.
        /// <para>EnumFieldValueChangedAction - Internal - ConditionCompareTypeEnumField</para>
        /// </summary>
        public void ToggleFloatFieldVisibleAction()
        {
            DSFieldUtility.ToggleElementDisplay(ComparisonType_EnumContainer.IsBooleansComparisonType(), ComparisonNumber_FloatContainer.FloatField);
        }


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Save modifier's value from another previously create modifier.
        /// </summary>
        /// <param name="source">The modifier of which it's values are going to be saved.</param>
        public override void SaveModifierValue(ConditionModifier source)
        {
            // Calling each container's saving method in order.
            ConditionName_TextContainer.SaveContainerValue(source.ConditionName_TextContainer);
            ComparisonNumber_FloatContainer.SaveContainerValue(source.ComparisonNumber_FloatContainer);
            ComparisonType_EnumContainer.SaveContainerValue(source.ComparisonType_EnumContainer);
        }


        /// <summary>
        /// Load modifier's value from another previously saved modifier.
        /// </summary>
        /// <param name="source">The modifier that was previously saved and now it's used to load from.</param>
        public override void LoadModifierValue(ConditionModifier source)
        {
            // Calling each container's loading method in order.
            ConditionName_TextContainer.LoadContainerValue(source.ConditionName_TextContainer);
            ComparisonNumber_FloatContainer.LoadContainerValue(source.ComparisonNumber_FloatContainer);
            ComparisonType_EnumContainer.LoadContainerValue(source.ComparisonType_EnumContainer);

            // Manually invoke the ToggleFloatFieldVisible action
            ToggleFloatFieldVisibleAction();
        }
    }
}