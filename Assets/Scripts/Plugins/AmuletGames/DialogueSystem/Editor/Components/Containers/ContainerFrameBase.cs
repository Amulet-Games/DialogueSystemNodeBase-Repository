using System;

namespace AG.DS
{
    [Serializable]
    public abstract class ContainerFrameBase : IReversible
    {
        // ----------------------------- IReversible -----------------------------
        /// <summary>
        /// Read summary from <see cref="IReversible"/> Interface.
        /// </summary>
        public abstract byte[] StashData();


        /// <summary>
        /// Read summary from <see cref="IReversible"/> Interface.
        /// </summary>
        public abstract void ReverseTo(byte[] array);
    }
}