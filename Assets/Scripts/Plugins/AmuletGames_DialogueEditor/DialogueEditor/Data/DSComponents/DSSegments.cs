using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG
{
    [Serializable]
    public abstract class DSSegmentBase
    {
        [Header("ID")]
        public IntContainer orderID_IntContainer = new IntContainer();
    }

    [Serializable]
    public class ImagesPreviewSegment : DSSegmentBase
    {
        [Header("Avatars")]
        public SpriteObjectContainer l_avatar_SpriteContainer = new SpriteObjectContainer();
        public SpriteObjectContainer r_avatar_SpriteContainer = new SpriteObjectContainer();
    
        public void LoadSegmentValue(ImagesPreviewSegment source, Image leftPreviewImage, Image rightPreviewImage)
        {
            // Calling each container's overwrite method in order.
            l_avatar_SpriteContainer.LoadContainerValue(source.l_avatar_SpriteContainer);
            r_avatar_SpriteContainer.LoadContainerValue(source.r_avatar_SpriteContainer);

            // Update the preivew image if there is any.
            DSObjectFieldUtility.UpdateImagePreview(l_avatar_SpriteContainer.Value, leftPreviewImage);
            DSObjectFieldUtility.UpdateImagePreview(r_avatar_SpriteContainer.Value, rightPreviewImage);
        }
    }

    [Serializable]
    public class SpeakerNameSegment : DSSegmentBase
    {
        [Header("Name")]
        public TextContainer name_TextsContainer = new TextContainer();

        public void LoadSegmentValue(SpeakerNameSegment source)
        {
            // Calling each container's overwrite method in order.
            name_TextsContainer.LoadContainerValue(source.name_TextsContainer);
        }
    }

    [Serializable]
    public class TextlineSegment : DSSegmentBase
    {
        [Header("LGs")]
        public LanguageTextContainer LG_Texts_Container = new LanguageTextContainer();
        public LanguageAudioClipContainer LG_AudioClips_Container = new LanguageAudioClipContainer();

        [Header("CSV Guid")]
        public string csvGuid = Guid.NewGuid().ToString();

        public void LoadSegmentValue(TextlineSegment source)
        {
            // Calling each container's overwrite method in order.
            LG_Texts_Container.LoadContainerValue(source.LG_Texts_Container);
            LG_AudioClips_Container.LoadContainerValue(source.LG_AudioClips_Container);
            csvGuid = source.csvGuid;
        }
    }
}