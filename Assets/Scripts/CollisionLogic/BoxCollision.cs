using UnityEngine;

public class BoxCollision : Shape
{
    private float m_width => transform.localScale.x;
    private float m_height => transform.localScale.y;
    private float m_length => transform.localScale.z;

    public float MinimumX => transform.position.x - (m_width * .5f);
    public float MaximumX => transform.position.x + (m_width * .5f);

    public float MinimumY => transform.position.y - (m_height * .5f);
    public float MaximumY => transform.position.y + (m_height * .5f);

    public float MinimumZ => transform.position.z - (m_length * .5f);
    public float MaximumZ => transform.position.z + (m_length * .5f); 

    public Vector2 Point1 => new Vector3(MinimumX, MinimumY);
    public Vector2 Point2 => new Vector3(MinimumX, MaximumY);
    public Vector2 Point3 => new Vector3(MaximumX, MaximumY);
    public Vector2 Point4 => new Vector3(MaximumX, MinimumY);

    private Vector2[] m_vectorArray;

    public override void DrawCollider()
    {
        base.DrawCollider();

        m_vectorArray = new Vector2[] { Point1, Point2, Point3, Point4 };

        for (int i = 0; i < m_vectorArray.Length; i++)
        {
            var point1 = m_vectorArray[i];
            var point2 = m_vectorArray[(i + 1) % m_vectorArray.Length];

            Gizmos.DrawLine(point1, point2);
        }
    }
}