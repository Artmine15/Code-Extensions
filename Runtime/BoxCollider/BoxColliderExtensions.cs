using UnityEngine;

namespace Artmine15.Packages.Utils.Extensions
{
    public static class BoxColliderExtensions
    {
        internal static Vector3 GetRandomPoint(this BoxCollider collider)
        {
            //float randomX = Random.Range(0 - boxCollider.size.x / 2, 0 + boxCollider.size.x / 2);
            //float randomY = Random.Range(0 - boxCollider.size.y / 2, 0 + boxCollider.size.y / 2);
            //float randomZ = Random.Range(0 - boxCollider.size.z / 2, 0 + boxCollider.size.z / 2);

            Bounds bounds = GetLocalBounds(collider);

            float randomX = Random.Range(bounds.min.x, bounds.max.x);
            float randomY = Random.Range(bounds.min.y, bounds.max.y);
            float randomZ = Random.Range(bounds.min.z, bounds.max.z);

            Vector3 localPoint = new Vector3(randomX, randomY, randomZ);
            return collider.transform.TransformPoint(localPoint);
        }

        public static Bounds GetLocalBounds(this BoxCollider collider)
        {
            Bounds localBounds = new Bounds();
            localBounds.max = collider.size / 2;
            localBounds.min = -(collider.size / 2);
            return localBounds;
        }

        public static bool IsPointInCollider(this BoxCollider collider, Vector3 worldPoint)
        {
            Bounds fixedBounds = new Bounds();
            fixedBounds.center = collider.transform.TransformPoint(collider.center);
            fixedBounds.extents = collider.bounds.extents;
            return fixedBounds.Contains(worldPoint);
        }

        public static Vector3 GetRandomPoint(this BoxCollider collider, SpawnAccuracyLevel spawnAccuracyLevel)
        {
            Vector3 randomPoint;
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
                    } while (!IsPointInCollider(collider, randomPoint) && attempts < 1000);
                    if (attempts >= 1000)
                        Debug.LogError("Failed to find a point within the collider after 1000 attempts.");
                    return randomPoint;
            }
            return Vector3.zero;
        }

        //public static bool IsObjectOverlap(Collider objectCollider)
        //{
        //    if (Physics.OverlapSphereNonAlloc(objectCollider.transform.position, 3, _resultColliders) >= 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
    }
}
