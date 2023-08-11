using System;
using UnityEngine;

namespace AG
{
    [Serializable]
    public struct SerializableVector3
    {
        /// <summary>
        /// The x axis value of the vector3.
        /// </summary>
        public float x;


        /// <summary>
        /// The y axis value of the vector3.
        /// </summary>
        public float y;


        /// <summary>
        /// The z axis value of the vector3.
        /// </summary>
        public float z;


        /// <summary>
        /// Constructor of the serializable vector3 struct.
        /// </summary>
        public SerializableVector3
        (
            float x,
            float y,
            float z
        )
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }


        // ----------------------------- Operators -----------------------------
        /// <summary>
        /// Allows explicit conversion from variable type serializable vector3 value to vector3.
        /// </summary>
        /// <param name="v">The serializable vector3 variable to convert from.</param>
        public static explicit operator Vector3(SerializableVector3 v)
        {
            return new Vector3(v.x, v.y, v.z);
        }


        /// <summary>
        /// Allows explicit conversion from variable type vector3 to serializable vector3.
        /// </summary>
        /// <param name="v">The vector3 variable to convert from.</param>
        public static explicit operator SerializableVector3(Vector3 v)
        {
            return new SerializableVector3(v.x, v.y, v.z);
        }


        /// <summary>
        /// Serializable vector3 struct's == operator.
        /// </summary>
        /// <param name="a">The serializable vector3 variable to compare from.</param>
        /// <param name="b">The serializable vector3 variable to compare to.</param>
        /// <returns>Returns true if the two variables' value are equal.</returns>
        public static bool operator ==(SerializableVector3 a, SerializableVector3 b)
        {
            return a.x == b.x
                && a.y == b.y
                && a.z == b.z;
        }


        /// <summary>
        /// Serializable vector3 struct's != operator.
        /// </summary>
        /// <param name="a">The serializable vector3 variable to compare from.</param>
        /// <param name="b">The serializable vector3 variable to compare to.</param>
        /// <returns>Returns true if the two variables' value are not equal.</returns>
        public static bool operator !=(SerializableVector3 a, SerializableVector3 b)
        {
            return a.x != b.x
                || a.y != b.y
                || a.z != b.z;
        }


        // ----------------------------- Overrides -----------------------------
        /// <summary>
        /// Serializable vector3 struct's Equals method.
        /// </summary>
        /// <param name="obj">The object to compare to.</param>
        /// <returns>Return true if the value of the comparing object this variable is equal.</returns>
        public override bool Equals(object obj)
        {
            // return true if the given object isn't null
            return obj != null

                // and the given object is a serializable vector3 variable 
                && obj is SerializableVector3 serializableVector3

                // and its value equals to this variable's value.
                && serializableVector3 == this;
        }


        /// <summary>
        /// Serializable vector3 struct's GetHashCode method.
        /// </summary>
        /// <returns>Returns the hash code of the serializable vector3 variable.</returns>
        public override int GetHashCode()
        {
            return x.GetHashCode() * 1610612741
                 * y.GetHashCode() * 24593
                 ^ z.GetHashCode();
        }
    }
}