using System;

namespace AG
{
    public abstract partial class DSSegmentFrameBase
    {
        [Serializable]
        public abstract class T1<TSegment>
        : DSSegmentBase
        where TSegment : DSSegmentBase
        {
            // ----------------------------- Serialization -----------------------------
            /// <summary>
            /// Save segment's value from another previously created segment.
            /// </summary>
            /// <param name="source">The segment of which it's values are going to be saved in.</param>
            public abstract void SaveSegmentValues(TSegment source);


            /// <summary>
            /// Load segment's value from another previously saved segment.
            /// <para></para>
            /// <br>This method is used for loading values between segments only.</br>
            /// <br>If loading values between molders is what you want, use the LoadMolderSegmentValues method instead.</br>
            /// </summary>
            /// <param name="source">The segment that was previously saved and now it's used to load from.</param>
            public abstract void LoadSegmentValues(TSegment source);
        }
    }
}