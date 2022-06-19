using System;
using System.Collections.Generic;
using UnityEngine;

namespace AG
{
    [Serializable]
    public class ChoiceNodeData : BaseNodeData
    {
        [Header("Port Guid")]
        public string inputPortGuid;
        public string outputPortGuid;

        [Header("Container")]
        public LanguageTextContainer LG_Texts_Container = new LanguageTextContainer();
        public LanguageAudioClipContainer LG_AudioClips_Container = new LanguageAudioClipContainer();
        public UnmetConditionDisplayTypeEnumContainer unmetConditionDisplayType_EnumContainer = new UnmetConditionDisplayTypeEnumContainer();

        [Header("Modifier")]
        public List<DSModifierBase> all = new List<DSModifierBase>();
        public List<ConditionModifier> conditionModifiers = new List<ConditionModifier>();
    }
}
