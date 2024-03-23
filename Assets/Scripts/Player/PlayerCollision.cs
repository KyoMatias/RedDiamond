using ScriptableObjectArchitecture;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private Transform m_player;
    [SerializeField] private BoxCollision _playerCollider;
    private List<BoxCollision> m_colliders = new List<BoxCollision>();

    [SerializeField] private float _pushDistance;

    [SerializeField] private BoolGameEvent _canPlayerInteract;
    public Interactable InteractableObject;

    private void OnEnable()
    {
        m_player = _playerCollider.transform.parent;
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

                continue;
            }

            if (!collider.IsInteractable)
            {
                Vector3 movement = Vector3.zero;

                float differenceX = m_player.position.x - collider.transform.position.x;
                float differenceZ = m_player.position.z - collider.transform.position.z;

                if (Mathf.Abs(differenceX)
                    > Mathf.Abs(differenceZ))
                {
                    movement = new Vector3(
                        0f,
                        0f,
                        Mathf.Sign(differenceZ) * _pushDistance);
                }
                else
                {
                    movement = new Vector3(
                        Mathf.Sign(differenceX) * _pushDistance,
                        0f,
                        0f);
                }

                m_player.transform.position += movement;

                continue;
            }

            InteractableObject = collider.GetComponentInParent<Interactable>();

            if (InteractableObject == null) continue;

            _canPlayerInteract.Raise(true);


            InteractableObject.GrabInteractableObjectName();

            break;
        }
    }
}
