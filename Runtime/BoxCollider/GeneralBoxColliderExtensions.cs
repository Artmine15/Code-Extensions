using UnityEngine;

namespace Artmine15.Utils.Extensions
{
    public static class GeneralBoxColliderExtensions
    {
        private static Collider[] _resultColliders = new Collider[4];

        public static Vector3 GetRandomPoint(BoxCollider boxCollider)
        {
            //float randomX = Random.Range(0 - boxCollider.size.x / 2, 0 + boxCollider.size.x / 2);
            //float randomY = Random.Range(0 - boxCollider.size.y / 2, 0 + boxCollider.size.y / 2);
            //float randomZ = Random.Range(0 - boxCollider.size.z / 2, 0 + boxCollider.size.z / 2);

            Bounds bounds = GetLocalBounds(boxCollider);

            float randomX = Random.Range(bounds.min.x, bounds.max.x);
            float randomY = Random.Range(bounds.min.y, bounds.max.y);
            float randomZ = Random.Range(bounds.min.z, bounds.max.z);

            Vector3 localPoint = new Vector3(randomX, randomY, randomZ);
            return boxCollider.transform.TransformPoint(localPoint);
        }

        public static Vector2 GetRandomPoint(BoxCollider2D boxCollider)
        {
            Bounds bounds = GetLocalBounds(boxCollider);

            float randomX = Random.Range(bounds.min.x, bounds.max.x);
            float randomY = Random.Range(bounds.min.y, bounds.max.y);

            Vector2 localPoint = new Vector2(randomX, randomY);
            return boxCollider.transform.TransformPoint(localPoint);
        }

        public static bool IsPointInCollider(Vector3 point, BoxCollider boxCollider)
        {
            Bounds fixedBounds = new Bounds();
            fixedBounds.center = boxCollider.transform.TransformPoint(boxCollider.center);
            fixedBounds.extents = boxCollider.bounds.extents;
            return fixedBounds.Contains(point);
        }

        public static bool IsPointInCollider(Vector2 point, BoxCollider2D boxCollider)
        {
            Bounds fixedBounds = new Bounds();
            fixedBounds.center = boxCollider.transform.TransformPoint(boxCollider.offset);
            fixedBounds.extents = boxCollider.bounds.extents;
            return fixedBounds.Contains(point);
        }

        

        public static Bounds GetLocalBounds(BoxCollider boxCollider)
        {
            Bounds localBounds = new Bounds();
            localBounds.max = boxCollider.size / 2;
            localBounds.min = -(boxCollider.size / 2);
            return localBounds;
        }

        public static Bounds GetLocalBounds(BoxCollider2D boxCollider)
        {
            Bounds localBounds = new Bounds();
            localBounds.max = boxCollider.size / 2;
            localBounds.min = -(boxCollider.size / 2);
            return localBounds;
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
