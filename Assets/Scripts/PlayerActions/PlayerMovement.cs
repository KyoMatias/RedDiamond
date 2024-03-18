using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _crouchMultiplier;

    private Vector3 m_movementVector;
    private float m_currentMoveSpeed;

    private void FixedUpdate()
    {
        m_currentMoveSpeed = _movementSpeed;

        if (Keyboard.current.leftShiftKey.isPressed) m_currentMoveSpeed *= _crouchMultiplier;

        transform.Translate(m_movementVector * m_currentMoveSpeed * Time.deltaTime);

        Vector3 nextPosition = transform.position
            + m_movementVector;

        transform.position = Vector3.Lerp(transform.position, nextPosition, m_currentMoveSpeed * Time.deltaTime);
    }

    public void Move(InputAction.CallbackContext input)
    {
        Vector2 inputVector = input.ReadValue<Vector2>();

        if (inputVector == Vector2.zero)
        {
            m_movementVector = Vector3.zero;
            return;
        }
        
        m_movementVector = new Vector3(inputVector.x, 0, inputVector.y);
    }
}
