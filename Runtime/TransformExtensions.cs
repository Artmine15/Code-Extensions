using UnityEngine;

namespace Artmine15.Extensions
{
    public static class TransformExtensions
    {
        /// <summary>
        /// Rotate transform using Mathf.Atan2() and Quaternion.RotateTowards().
        /// </summary>
        /// <param name="fromAngle">Start angle that Quaternion.RotateTowards() using.</param>
        public static void RotateToTargetByZ(this Transform transform, Quaternion fromAngle, Vector2 direction, float maxDegreesDelta = 360, float zRotationFactor = 0)
        {
            //Quaternion angle = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + ZRotationFactor);
            Quaternion angle = transform.GetZAngleFromDirection(direction, zRotationFactor);
            transform.rotation = Quaternion.RotateTowards(fromAngle, angle, maxDegreesDelta);
        }

        /// <returns>Returns quaternion angle from direction using Mathf.Atan2().</returns>
        public static Quaternion GetZAngleFromDirection(this Transform transform, Vector2 direction, float zRotationFactor = -90)
        {
            Quaternion angle = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + zRotationFactor);
            return angle;
        }
    }
}
