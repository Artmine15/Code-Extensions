using UnityEngine;

namespace Artmine15.Packages.Utils.Extensions
{
    public static class TransformExtensions
    {
        public static void RotateToTargetByZ(this Transform transform, Quaternion fromAngle, Vector2 direction, float maxDegreesDelta = 360, float ZRotationFactor = 0)
        {
            Quaternion angle = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + ZRotationFactor);
            transform.rotation = Quaternion.RotateTowards(fromAngle, angle, maxDegreesDelta);
        }
    }
}
