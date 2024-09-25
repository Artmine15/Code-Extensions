
using UnityEngine;

namespace Artmine15.Utils.Extensions
{
    public enum SpawnAccuracyLevel { None, MustBeInCollider }

    public static class BoxColliderExtensions
    {
        public static Vector3 GetRandomPointInCollider(BoxCollider boxCollider, SpawnAccuracyLevel spawnAccuracyLevel)
        {
            Bounds bounds = boxCollider.bounds;
            Vector3 randomPoint;
            switch (spawnAccuracyLevel)
            {
                case SpawnAccuracyLevel.None:
                    return GeneralBoxColliderExtensions.GetRandomPoint(boxCollider);
                case SpawnAccuracyLevel.MustBeInCollider:
                    int attempts = 0;
                    do
                    {
                        randomPoint = GeneralBoxColliderExtensions.GetRandomPoint(boxCollider);
                        attempts++;
                    } while (!GeneralBoxColliderExtensions.IsPointInCollider(randomPoint, boxCollider) && attempts < 1000);
                    if (attempts >= 1000)
                        Debug.LogError("Failed to find a point within the collider after 1000 attempts.");
                    return randomPoint;
            }
            return Vector3.zero;
        }
    }
}
