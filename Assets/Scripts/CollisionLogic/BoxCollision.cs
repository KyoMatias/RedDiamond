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

  public Vector2 point1 => new Vector3(MinimumX, MinimumY);
  public Vector2 point2 => new Vector3(MinimumX, MaximumY);
  public Vector2 point3 => new Vector3(MaximumX, MaximumY);
  public Vector2 point4 => new Vector3(MaximumX, MinimumY);

  public override void DrawCollider()
  {
      base.DrawCollider();

      var VectorArray = new Vector2[] { point1, point2, point3, point4 };

      for (int i = 0; i < VectorArray.Length; i++)
      {
          var v = VectorArray[i];
          var v2 = VectorArray[(i + 1) % VectorArray.Length];
          Gizmos.DrawLine(v, v2);
      }
  }
}