using ScriptableObjectArchitecture;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private Shape _playerCollider;
    private List<Shape> m_colliders = new List<Shape>();

    [SerializeField] private BoolVariable _canPlayerMove;

    [SerializeField] private BoolGameEvent _canPlayerInteract;

    public Interactable InteractableObject;

    private void OnEnable()
    {
        m_colliders.AddRange(FindObjectsOfType<Shape>());
    }

    private void FixedUpdate()
    {
        HandleCollision();
    }

    private void HandleCollision()
    {
        foreach (Shape collider in m_colliders) 
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
        var Colliders = FindObjectsOfType<Shape>();

        foreach (var c in Colliders)
        {
            c.DrawCollider();
        }
    }
}

