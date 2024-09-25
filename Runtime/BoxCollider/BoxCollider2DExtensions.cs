using UnityEngine;

namespace Artmine15.Utils.Extensions
{
    public static class BoxCollider2DExtensions
    {
        private static Collider2D[] _resultColliders = new Collider2D[4];

        public static Vector2 GetRandomPointInCollider(BoxCollider2D areaCollider, SpawnAccuracyLevel spawnAccuracyLevel)
        {
            Bounds bounds = areaCollider.bounds;
            Vector2 randomPoint;
            switch (spawnAccuracyLevel)
            {
                case SpawnAccuracyLevel.None:
                    return GeneralBoxColliderExtensions.GetRandomPoint(areaCollider);
                case SpawnAccuracyLevel.MustBeInCollider:
                    int attempts = 0;
                    do
                    {
                        randomPoint = GeneralBoxColliderExtensions.GetRandomPoint(areaCollider);
                        attempts++;
                    } while (!GeneralBoxColliderExtensions.IsPointInCollider(randomPoint, areaCollider));
                    if (attempts >= 1000)
                        Debug.LogError("Failed to find a point within the collider after 1000 attempts.");
                    return randomPoint;
            }
            return Vector2.zero;
        }
    }
}
