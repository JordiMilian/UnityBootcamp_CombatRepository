using UnityEngine;

public static class UsefullMethods 
{
    //Im not sure if these methods work with Vector3 properly. They were created with Vector2 in mind

    public static Vector3 angle2Vector(float angleRad)
    {
        float x = Mathf.Sin(angleRad);
        float z = Mathf.Cos(angleRad);
        return new Vector3(x, 0, z);
    }
    public static float vector2Angle(Vector3 vector)
    {
        Vector3 normalized = vector.normalized;
        return Mathf.Atan2(normalized.z, normalized.x);
    }
    public static Vector3 RotateVectorByDirection(Vector3 VectorToRotate, Vector3 NewForwardDirection)
    {
        return (NewForwardDirection * VectorToRotate.z) + (new Vector3(NewForwardDirection.z, 0, -NewForwardDirection.x) * VectorToRotate.x);
    }
}
