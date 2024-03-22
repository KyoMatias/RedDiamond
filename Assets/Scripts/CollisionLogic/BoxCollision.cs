using TMPro;
using UnityEditor;
using UnityEngine;

public class BoxCollision : Shape
{
    private float m_width => transform.localScale.x;
    private float m_height => transform.localScale.y;
    private float m_length => transform.localScale.z;

    public float ExtentsX => (m_width * .5f);
    public float ExtentsY => (m_height * .5f);
    public float ExtentsZ => (m_length * .5f);

    public float MinimumX => transform.position.x - ExtentsX;
    public float MaximumX => transform.position.x + ExtentsX;
    public float MinimumY => transform.position.y - ExtentsY;
    public float MaximumY => transform.position.y + ExtentsY;
    public float MinimumZ => transform.position.z - ExtentsZ;
    public float MaximumZ => transform.position.z + ExtentsZ;

    private void OnEnable()
    {
        ShapeType = ShapeType.Box;
    }

    private Vector3[] m_frontSide
    {
        get
        {
            return new Vector3[]
            {
            new Vector3(MinimumX, MinimumY, MinimumZ),
            new Vector3(MinimumX, MaximumY, MinimumZ),
            new Vector3(MaximumX, MaximumY, MinimumZ),
            new Vector3(MaximumX, MinimumY, MinimumZ)
            };
        }
    }

    private Vector3[] m_backSide
    {
        get
        {
            return new Vector3[]
            {
            new Vector3(MinimumX, MinimumY, MaximumZ),
            new Vector3(MinimumX, MaximumY, MaximumZ),
            new Vector3(MaximumX, MaximumY, MaximumZ),
            new Vector3(MaximumX, MinimumY, MaximumZ)
            };
        }
    }

    private Vector3[] m_leftSide
    {
        get
        {
            return new Vector3[]
            {
                m_frontSide[0], m_frontSide[1], m_backSide[1], m_backSide[0]
            };
        }
    }

    private Vector3[] m_rightSide
    {
        get
        {
            return new Vector3[]
            {
                m_frontSide[2], m_frontSide[3], m_backSide[3], m_backSide[2]
            };
        }
    }

    public override void DrawCollider()
{
        base.DrawCollider();

        DrawLine(m_frontSide);
        DrawLine(m_backSide);
        DrawLine(m_rightSide);
        DrawLine(m_leftSide);
    }

    public override void DrawLine(Vector3[] vectorArray)
    {
        base.DrawLine(vectorArray);

        for (int i = vectorArray.Length - 1; i >= 0; i--)
        {
            var firstPoint = vectorArray[i];

            var secondPoint = vectorArray[(i + 1) % vectorArray.Length];

            Gizmos.DrawLine(firstPoint, secondPoint);
        }
    }
}