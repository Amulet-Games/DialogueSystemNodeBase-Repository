using System;
using UnityEngine;

namespace AG
{
    [Serializable]
    public abstract class DSModifierBase
    {
        [Header("ID")]
        public IntContainer orderID_IntContainer = new IntContainer();
    }

    [Serializable]
    public class ConditionModifier : DSModifierBase
    {
        public TextContainer conditionName_TextsContainer = new TextContainer();
        public FloatContainer compareNumber_FloatContainer = new FloatContainer();
        public ConditionComparisonTypeEnumContainer compareMethType_EnumContainer = new ConditionComparisonTypeEnumContainer();

        public void LoadModifierValue(ConditionModifier source)
        {
            // Calling each container's overwrite method in order.
            conditionName_TextsContainer.LoadContainerValue(source.conditionName_TextsContainer);
            compareNumber_FloatContainer.LoadContainerValue(source.compareNumber_FloatContainer);
            compareMethType_EnumContainer.LoadContainerValue(source.compareMethType_EnumContainer);
        }
    }

    [Serializable]
    public class BasicEventModifier : DSModifierBase
    {
        public TextContainer eventName_TextsContainer = new TextContainer();
        public FloatContainer desireNumber_FloatContainer = new FloatContainer();
        public BasicEventTypeEnumContainer basicEventType_EnumContainer = new BasicEventTypeEnumContainer();

        public void LoadModifierValue(BasicEventModifier source)
        {
            // Calling each container's overwrite method in order.
            eventName_TextsContainer.LoadContainerValue(source.eventName_TextsContainer);
            desireNumber_FloatContainer.LoadContainerValue(source.desireNumber_FloatContainer);
            basicEventType_EnumContainer.LoadContainerValue(source.basicEventType_EnumContainer);
        }
    }

    [Serializable]
    public class ScriptableEventModifier : DSModifierBase
    {
        public ObjectContainer<DialogueEventSO> dialEventSO_Container = new ObjectContainer<DialogueEventSO>();

        public void LoadModifierValue(ScriptableEventModifier source)
        {
            dialEventSO_Container.LoadContainerValue(source.dialEventSO_Container);
        }
    }
}