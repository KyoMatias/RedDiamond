using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private PlayerCollision _playerCollision;

    [SerializeField] private BoolGameEvent _canPlayerInteract;
    [SerializeField] private GameEvent _onPlayerInteract;

    private bool m_interactFlag;
    private bool m_interactInput;

    public void Interact()
    {
        Debug.Log("This was called!");
        _playerCollision.InteractableObject.Interact();
    }

    public void InteractInput(InputAction.CallbackContext input)
    {
        if (!m_interactFlag) return;

        m_interactInput = input.action.triggered;

        if (m_interactInput) _onPlayerInteract.Raise();
    }

    public void CanPlayerInteract(bool flag) => m_interactFlag = flag;
}
