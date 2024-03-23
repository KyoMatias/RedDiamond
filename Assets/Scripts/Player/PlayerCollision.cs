using ScriptableObjectArchitecture;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private BoxCollision _playerCollider;
    private List<BoxCollision> m_colliders = new List<BoxCollision>();

    [SerializeField] private BoolVariable _canPlayerMove;

    private Vector3 m_playerPosition;
    private float m_playerExtentsX;
    private float m_playerExtentsZ;

    private Vector3 m_colliderPosition;

    private Vector3 m_slideDistance;
    private Vector3 m_slideDirection;
    private Vector3 m_direction;

    [SerializeField] private BoolGameEvent _canPlayerInteract;
    public Interactable InteractableObject;

    private void OnEnable()
    {
        m_colliders.AddRange(FindObjectsOfType<BoxCollision>());
    }

    private void FixedUpdate()
    {
        HandleCollision();
    }

    private void HandleCollision()
    {
        foreach (BoxCollision collider in m_colliders)
        {
            if (collider == _playerCollider) continue;

            if (!CollisionLibrary.CheckCollision(_playerCollider, collider))
            {
                InteractableObject = null;

                _canPlayerInteract.Raise(false);

                _canPlayerMove.Value = true;

                continue;
            }

            if (!collider.IsInteractable)
            {
                _canPlayerMove.Value = false;

                continue;
            }

            InteractableObject = collider.GetComponentInParent<Interactable>();

            if (InteractableObject == null) continue;

            InteractableObject.GrabInteractableObjectName();

            _canPlayerInteract.Raise(true);

            break;
        }
    }


    private void OnDrawGizmos()
    {
        var Colliders = FindObjectsOfType<BoxCollision>();

        foreach (var c in Colliders)
        {
            c.DrawCollider();
        }
    }
}

