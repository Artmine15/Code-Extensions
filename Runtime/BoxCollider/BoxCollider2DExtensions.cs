using UnityEngine;

namespace Artmine15.Packages.Utils.Extensions
{
    public static class BoxCollider2DExtensions
    {
        internal static Vector2 GetRandomPoint(this BoxCollider2D collider)
        {
            Bounds bounds = collider.GetLocalBounds();

            float randomX = Random.Range(bounds.min.x, bounds.max.x);
            float randomY = Random.Range(bounds.min.y, bounds.max.y);

            Vector2 localPoint = new Vector2(randomX, randomY);
            return collider.transform.TransformPoint(localPoint);
        }

        public static Bounds GetLocalBounds(this BoxCollider2D collider)
        {
            Bounds localBounds = new Bounds();
            localBounds.max = collider.size / 2;
            localBounds.min = -(collider.size / 2);
            return localBounds;
        }

        public static bool IsPointInCollider(this BoxCollider2D collider, Vector2 worldPoint)
        {
            Bounds fixedBounds = new Bounds();
            fixedBounds.center = collider.transform.TransformPoint(collider.offset);
            fixedBounds.extents = collider.bounds.extents;
            return fixedBounds.Contains(worldPoint);
        }

        public static Vector2 GetRandomPoint(this BoxCollider2D collider, SpawnAccuracyLevel spawnAccuracyLevel)
        {
            Bounds bounds = collider.bounds;
            Vector2 randomPoint;
            switch (spawnAccuracyLevel)
            {
                case SpawnAccuracyLevel.None:
                    return collider.GetRandomPoint();
                case SpawnAccuracyLevel.MustBeInCollider:
                    int attempts = 0;
                    do
                    {
                        randomPoint = collider.GetRandomPoint();
                        attempts++;
                    } while (!collider.IsPointInCollider(randomPoint) && attempts < 1000);
                    if (attempts >= 1000)
                        Debug.LogError("Failed to find a point within the collider after 1000 attempts.");
                    return randomPoint;
            }
            return Vector2.zero;
        }
    }
}
