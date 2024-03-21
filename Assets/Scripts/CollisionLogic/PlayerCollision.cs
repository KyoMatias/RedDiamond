using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BoxCollision))]
public class PlayerCollision : MonoBehaviour
{
    private BoxCollision m_playerCollider => GetComponent<BoxCollision>();

    private void Update()
    {
        HandleCollision();
    }

    public void HandleCollision()
    {
        var Colliders = FindObjectsOfType<BoxCollision>();

        foreach (var c in Colliders)
        {
            if (m_playerCollider == c) continue;

            if (CollisionLibrary.CheckCollision(m_playerCollider, c))
            {
                // playerStat.Damage(-1);
                Destroy(c.gameObject);
            }
        }
    }

    private void OnDrawGizmos()
    {
        var Colliders = FindObjectsOfType<Shape>();
        foreach (var c in Colliders)
        {
            c.DrawCollider();
        }
    }
}

