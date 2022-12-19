using System;

namespace AG.DS
{
    [Serializable]
    public abstract partial class SegmentFrameBase
    {
        [Serializable]
        public abstract class Regular<TSegmentData> : SegmentBase
            where TSegmentData : SegmentDataBase
        {
            // ----------------------------- Serialization -----------------------------
            /// <summary>
            /// Save the segment values to the given data.
            /// </summary>
            /// <param name="data">The given data to save to.</param>
            public abstract void SaveSegmentValues(TSegmentData data);


            /// <summary>
            /// Load the segment values from the given data.
            /// </summary>
            /// <param name="data">The given data to load from.</param>
            public abstract void LoadSegmentValues(TSegmentData data);
        }
    }
}