using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace AG
{
    public static class DSLanguageGroupsMaker
    {
        public static Box GetNewLanguageGroup_Textline(LanguageTextContainer LG_Texts_Container, LanguageAudioClipContainer LG_AudioClips_Container)
        {
            // This consists with TextField for LG_Texts, and ObjectField for LG_AudioClips.
            Box LG_textlineBox;

            TextField LG_Text_TextField;
            ObjectField LG_AudioClip_ObjectField;

            SetupBoxContainer();

            SetupTextField();

            SetupObjectField();

            AddFieldsToBox();

            return LG_textlineBox;

            void SetupBoxContainer()
            {
                LG_textlineBox = new Box();
            }

            void SetupTextField()
            {
                LG_Text_TextField = DSLanguageFieldsMaker.GetNewLanguageField_Text(LG_Texts_Container, "Text", DSStylesConfig.languageGenerics_Text_TextField);
            }

            void SetupObjectField()
            {
                LG_AudioClip_ObjectField = DSLanguageFieldsMaker.GetNewLanguageField_AudioClip(LG_AudioClips_Container, DSStylesConfig.languageGenerics_AudioClip_ObjectField);
            }

            void AddFieldsToBox()
            {
                LG_textlineBox.Add(LG_Text_TextField);
                LG_textlineBox.Add(LG_AudioClip_ObjectField);
            }
        }
    }
}
