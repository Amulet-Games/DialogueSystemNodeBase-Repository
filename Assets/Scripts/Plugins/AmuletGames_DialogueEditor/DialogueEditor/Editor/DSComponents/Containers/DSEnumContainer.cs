using System;
using UnityEditor.UIElements;

namespace AG
{
    [Serializable]
    public abstract class EnumContainerBase
    {
        /// <summary>
        /// The serialzable value from the container.
        /// </summary>
        protected Enum Value;


        /// <summary>
        /// Visual element
        /// </summary>
        public EnumField EnumField;


        /// <summary>
        /// Setup the enum field internally after it's been connected to the newly created one.
        /// </summary>
        public void SetupContainerField()
        {
            EnumField.Init(Value);
            EnumField.SetValueWithoutNotify(Value);
        }


        /// <summary>
        /// Assign a new value to the enum container as it's child representing type.
        /// </summary>
        /// <param name="newValue">The new value to assign to the container.</param>
        public abstract void SetEnumValue(Enum newValue);


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Overwrite the value of this container with the value that's from the source,
        /// and update the field to show the changes.
        /// </summary>
        /// <param name="source">Target container to load from</param>
        public void LoadContainerValue(EnumContainerBase source)
        {
            // Overwrite value
            Value = source.Value;

            // Set field's value without invoking field's value change event.
            EnumField.SetValueWithoutNotify(Value);
        }


        /// <summary>
        /// Overwrite the value in this container with the one that are from the source.
        /// </summary>
        /// <param name="source">Target container to save from.</param>
        public void SaveContainerValue(EnumContainerBase source)
        {
            // Save value
            Value = source.Value;
        }
    }


    public class DialogueOverHandleTypeEnumContainer : EnumContainerBase
    {
        /// <summary>
        /// Constructor of dialogue over handle type enum container.
        /// </summary>
        public DialogueOverHandleTypeEnumContainer()
        {
            Value = N_End_DialogueOverHandleType.End;
        }


        /// <inheritdoc />
        public override void SetEnumValue(Enum newValue) => Value = (N_End_DialogueOverHandleType)newValue;
    }


    public class UnmetOptionDisplayTypeEnumContainer : EnumContainerBase
    {
        /// <summary>
        /// Constructor of unmet option display type enum container.
        /// </summary>
        public UnmetOptionDisplayTypeEnumContainer()
        {
            Value = N_Modifier_ConditionDisplayType.Hide;
        }


        /// <inheritdoc />
        public override void SetEnumValue(Enum newValue) => Value = (N_Modifier_ConditionDisplayType)newValue;
    }


    public class ConditionComparisonTypeEnumContainer : EnumContainerBase
    {
        /// <summary>
        /// Constructor of condition comparison type enum container.
        /// </summary>
        public ConditionComparisonTypeEnumContainer()
        {
            Value = N_Modifier_ConditionComparisonType.True;
        }


        /// <inheritdoc />
        public override void SetEnumValue(Enum newValue) => Value = (N_Modifier_ConditionComparisonType)newValue;


        // ----------------------------- Utility -----------------------------
        /// <summary>
        /// Is the enum container's value currently on type either true or false? 
        /// </summary>
        /// <returns>A boolean value that returns true if the enum container's value is either on type true or false.</returns>
        public bool IsBooleansComparisonType()
        {
            N_Modifier_ConditionComparisonType comparisonType = (N_Modifier_ConditionComparisonType)Value;
            return comparisonType == N_Modifier_ConditionComparisonType.True || comparisonType == N_Modifier_ConditionComparisonType.False;
        }
    }
}