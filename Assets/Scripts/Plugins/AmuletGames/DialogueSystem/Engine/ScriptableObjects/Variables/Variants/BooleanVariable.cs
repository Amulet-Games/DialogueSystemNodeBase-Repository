using System;

namespace AG
{
    [Serializable]
    public class BooleanVariable : VariableFrameBase<bool>
    {
        /// <inheritdoc />
        public bool True() => Value == true;


        /// <inheritdoc />
        public bool False() => Value == false;
    }
}