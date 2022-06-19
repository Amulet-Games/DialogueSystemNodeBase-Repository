using System;
using UnityEditor.UIElements;

namespace AG
{
    public abstract class EnumContainerBase
    {
        /// <summary>
        /// Assign a new value to the enum container as it's child representing type.
        /// </summary>
        /// <param name="newValue">The new value to assign to the container.</param>
        public abstract void SetEnumValue(Enum newValue);

#if UNITY_EDITOR
        /// <summary>
        /// Work as a temp reference for base methods only.
        /// </summary>
        [NonSerialized] public Enum Value;

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
        /// Overwrite the target container's value with the value that's from this container.
        /// </summary>
        /// <param name="saveToContainer">Target container to save toward.</param>
        public void SaveContainerValue(EnumContainerBase saveToContainer)
        {
            // Save value
            saveToContainer.Value = Value;
        }
#endif
    }

    [Serializable]
    public class UnmetConditionDisplayTypeEnumContainer : EnumContainerBase
    {
        public new N_Modifier_UnmetConditionDisplayType Value = N_Modifier_UnmetConditionDisplayType.Hide;

        public override void SetEnumValue(Enum newValue) => Value = (N_Modifier_UnmetConditionDisplayType)newValue;

#if UNITY_EDITOR
        public UnmetConditionDisplayTypeEnumContainer()
        {
            base.Value = Value;
        }
#endif
    }

    [Serializable]
    public class DialogueOverHandleTypeEnumContainer : EnumContainerBase
    {
        public new N_End_DialogueOverHandleType Value = N_End_DialogueOverHandleType.End;

        public override void SetEnumValue(Enum newValue) => Value = (N_End_DialogueOverHandleType)newValue;

#if UNITY_EDITOR
        public DialogueOverHandleTypeEnumContainer()
        {
            base.Value = Value;
        }
#endif
    }

    [Serializable]
    public class ConditionComparisonTypeEnumContainer : EnumContainerBase
    {
        public new N_Modifier_ConditionComparisonType Value = N_Modifier_ConditionComparisonType.True;

        public override void SetEnumValue(Enum newValue) => Value = (N_Modifier_ConditionComparisonType)newValue;

#if UNITY_EDITOR
        public ConditionComparisonTypeEnumContainer()
        {
            base.Value = Value;
        }
#endif
    }

    [Serializable]
    public class BasicEventTypeEnumContainer : EnumContainerBase
    {
        public new N_Modifier_BasicEventType Value = N_Modifier_BasicEventType.Add;

        public override void SetEnumValue(Enum newValue) => Value = (N_Modifier_BasicEventType)newValue;

#if UNITY_EDITOR
        public BasicEventTypeEnumContainer()
        {
            base.Value = Value;
        }
#endif
    }
}