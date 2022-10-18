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
        public TextContainer ConditionNameTextContainer;


        /// <summary>
        /// Float container for the value that is used for comparison.
        /// </summary>
        public FloatContainer ComparisonNumberFloatContainer;


        /// <summary>
        /// Enum container for how the users want to compare the value in this condition.
        /// </summary>
        public ConditionComparisonTypeEnumContainer ConditionComparisonTypeEnumContainer;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of condition modifier
        /// </summary>
        public ConditionModifier()
        {
            ConditionNameTextContainer = new TextContainer();
            ComparisonNumberFloatContainer = new FloatContainer();
            ConditionComparisonTypeEnumContainer = new ConditionComparisonTypeEnumContainer();
        }


        // ----------------------------- Makers -----------------------------
        /// <inheritdoc />
        public override void SetupRootModifier(DSNodeBase node)
        {
            TextField conditionNameTextField;
            FloatField comparisonNumberFloatField;
            EnumField conditionComparisonTypeEnumField;

            SetupModifierBox();

            SetupConditionNameTextField();

            SetupComparisonNumberFloatField();

            SetupConditionComparisonTypeEnumField();

            AddFieldsToBox();

            AddBoxToSegmentContentContainer();

            ModifierPostSetupAction();

            void SetupModifierBox()
            {
                MainBox = new Box();
                MainBox.AddToClassList(DSStylesConfig.Modifier_Condition_Rooted_MainBox);
            }

            void SetupConditionNameTextField()
            {
                conditionNameTextField = DSTextFieldsMaker.GetNewTextField
                (
                    ConditionNameTextContainer,
                    false,
                    DSStringsConfig.ConditionModifierConditionNamePlaceHolderText,
                    DSStylesConfig.Modifier_Condition_Rooted_TextField
                );
            }

            void SetupComparisonNumberFloatField()
            {
                comparisonNumberFloatField = DSFloatFieldsMaker.GetNewFloatField
                (
                    ComparisonNumberFloatContainer,
                    DSStylesConfig.Modifier_Condition_Rooted_FloatField
                );
            }

            void SetupConditionComparisonTypeEnumField()
            {
                conditionComparisonTypeEnumField = DSEnumFieldsMaker.GetNewEnumField
                (
                    ConditionComparisonTypeEnumContainer,
                    EnumFieldValueChangedAction,
                    DSStylesConfig.Modifier_Condition_Rooted_EnumField
                );
            }

            void AddFieldsToBox()
            {
                MainBox.Add(conditionNameTextField);
                MainBox.Add(conditionComparisonTypeEnumField);
                MainBox.Add(comparisonNumberFloatField);
            }

            void AddBoxToSegmentContentContainer()
            {
                node.mainContainer.Add(MainBox);
            }

            void ModifierPostSetupAction()
            {
                ToggleConditionNumberDisplay();
            }
        }


        // ----------------------------- Callbacks -----------------------------
        /// <summary>
        /// Action that invoked when the modifier's enum field value is changed.
        /// </summary>
        void EnumFieldValueChangedAction() => ToggleConditionNumberDisplay();


        // ----------------------------- Serialization -----------------------------
        /// <inheritdoc />
        public override void SaveModifierValue(ConditionModifier source)
        {
            // Calling each container's saving method in order.
            ConditionNameTextContainer.SaveContainerValue(source.ConditionNameTextContainer);
            ComparisonNumberFloatContainer.SaveContainerValue(source.ComparisonNumberFloatContainer);
            ConditionComparisonTypeEnumContainer.SaveContainerValue(source.ConditionComparisonTypeEnumContainer);
        }


        /// <inheritdoc />
        public override void LoadModifierValue(ConditionModifier source)
        {
            // Calling each container's loading method in order.
            ConditionNameTextContainer.LoadContainerValue(source.ConditionNameTextContainer);
            ComparisonNumberFloatContainer.LoadContainerValue(source.ComparisonNumberFloatContainer);
            ConditionComparisonTypeEnumContainer.LoadContainerValue(source.ConditionComparisonTypeEnumContainer);
            
            // Manually invoke the ToggleFloatFieldVisible action
            ToggleConditionNumberDisplay();
        }


        // ----------------------------- Toggle Condition Number Display Services -----------------------------
        /// <summary>
        /// Hide or show the modifier's condition number field when the condition compare type is set to "True" or "False".
        /// </summary>
        public void ToggleConditionNumberDisplay()
        {
            DSElementDisplayUtility.ToggleElementDisplay
            (
                ConditionComparisonTypeEnumContainer.IsTrueOrFalseComparisonType(),
                ComparisonNumberFloatContainer.FloatField
            );
        }
    }
}