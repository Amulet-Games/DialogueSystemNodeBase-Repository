using System;
using UnityEngine;

namespace AG
{
    [Serializable]
    public class FloatVariable : VariableFrameBase<float>
    {
        /// <inheritdoc />
        public override bool Equal(float target) => Mathf.Approximately(Value, target);


        /// <inheritdoc />
        public override bool EqualOrBigger(float target) => Value > target || Mathf.Approximately(Value, target);


        /// <inheritdoc />
        public override bool EqualOrSmaller(float target) => Value < target || Mathf.Approximately(Value, target);


        /// <inheritdoc />
        public override bool Bigger(float target) => Value > target;


        /// <inheritdoc />
        public override bool Smaller(float target) => Value < target;
    }
}