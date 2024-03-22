using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _crouchMultiplier;

    [SerializeField] private float m_pushForceMagnitude;


    private float m_currentMoveSpeed;
    private bool m_isPlayerCrouching;

    private Vector2 m_inputVector;
    private Vector3 m_movementVector;

    private Vector3 m_previousPosition;
    private Vector3 m_nextPosition;
    private float m_step;

    [SerializeField] private BoolVariable _canPlayerMove;

    private void Update()
    {
        if (!m_isPlayerCrouching) m_currentMoveSpeed = _movementSpeed;
    }

    private void FixedUpdate()
    {
        m_step = m_currentMoveSpeed * Time.deltaTime;

        if (!_canPlayerMove) m_movementVector = -m_movementVector;

        m_nextPosition = transform.position + m_movementVector;

        transform.position = Vector3.Lerp(transform.position, m_nextPosition, m_step);
    }

    public void MoveInput(InputAction.CallbackContext input)
    {
        m_inputVector = input.ReadValue<Vector2>();

        if (m_inputVector == Vector2.zero)
        {
            m_movementVector = Vector3.zero;
            return;
        }
        
        m_movementVector = new Vector3(m_inputVector.x, 0, m_inputVector.y);
    }

    public void CrouchInput(InputAction.CallbackContext input)
    {
        m_isPlayerCrouching = input.ReadValueAsButton();

        if (m_isPlayerCrouching) m_currentMoveSpeed = _movementSpeed * _crouchMultiplier;
    }
}
