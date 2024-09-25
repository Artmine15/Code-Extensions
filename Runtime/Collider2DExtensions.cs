using UnityEngine;

namespace Artmine15.Utils.Extensions
{
    public enum SpawnAccuracyLevel { None, MustBeInCollider }

    public static class Collider2DExtensions
    {
        private static Collider2D[] _resultColliders = new Collider2D[4];

        public static Vector2 GetRandomPointInCollider(BoxCollider2D areaCollider, SpawnAccuracyLevel spawnAccuracyLevel)
        {
            Bounds bounds = areaCollider.bounds;
            Vector2 randomPoint;
            switch (spawnAccuracyLevel)
            {
                case SpawnAccuracyLevel.None:
                    return GetRandomPoint(areaCollider);
                case SpawnAccuracyLevel.MustBeInCollider:
                    do
                    {
                        randomPoint = GetRandomPoint(areaCollider);
                    } while (!IsPointInCollider(randomPoint, areaCollider));
                    return randomPoint;
            }
            return Vector2.zero;
        }

        private static Vector2 GetRandomPoint(BoxCollider2D boxCollider)
        {
            //float randomX = Random.Range(boxCollider.transform.position.x - boxCollider.size.x / 2, boxCollider.transform.position.x + boxCollider.size.x / 2);
            //float randomY = Random.Range(boxCollider.transform.position.y - boxCollider.size.y / 2, boxCollider.transform.position.y + boxCollider.size.y / 2);
            Bounds bounds = boxCollider.bounds;
            float randomX = Random.Range(bounds.min.x, bounds.max.x);
            float randomY = Random.Range(bounds.min.y, bounds.max.y);
            return new Vector2(randomX, randomY);
        }

        private static bool IsPointInCollider(Vector2 point, BoxCollider2D collider)
        {
            return collider.bounds.Contains(point);
        }

        public static bool IsObjectOverlap(Collider2D objectCollider)
        {
            if (Physics2D.OverlapCircleNonAlloc(objectCollider.transform.position, 3, _resultColliders) >= 0)
            {
                //Debug.Log("True");
                return true;
            }
            else
            {
                //Debug.Log("False");
                return false;
            }

        }
    }
}
