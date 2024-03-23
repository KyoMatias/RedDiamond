public static class CollisionLibrary
{
    public static bool CheckCollision(Shape shapeA, Shape shapeB)
    {
        if (shapeA.ShapeType == ShapeType.Box && shapeB.ShapeType == ShapeType.Box)
        {
            return DidBoxCollide((BoxCollision)shapeA, (BoxCollision)shapeB);
        }

        return false;
    }

    public static bool DidBoxCollide(BoxCollision boxA, BoxCollision boxB)
    {
        return BoxCheck(boxA.MinimumX, boxA.MaximumX, boxB.MinimumX, boxB.MaximumX)
            && BoxCheck(boxA.MinimumY, boxA.MaximumY, boxB.MinimumY, boxB.MaximumY)
            && BoxCheck(boxA.MinimumZ, boxA.MaximumZ, boxB.MinimumZ, boxB.MaximumZ);
    }

    private static bool BoxCheck(float minA, float maxA, float minB, float maxB)
    {
        return maxA >= minB
            && minA <= maxB;
    }
}