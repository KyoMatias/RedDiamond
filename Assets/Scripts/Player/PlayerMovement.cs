using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private string m_currentState;
    private string m_newState;

    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _crouchMultiplier;

    private float m_currentMovementSpeed;
    private bool m_isPlayerCrouching;

    private Vector2 m_inputVector;
    private Vector3 m_movementVector;

    private Vector3 m_nextPosition;
    private float m_step;

    private void Update()
    {
        m_currentMovementSpeed = _movementSpeed;
    }

    private void FixedUpdate()
    {
        m_step = m_currentMovementSpeed * Time.deltaTime;

        m_nextPosition = transform.position + m_movementVector;

        transform.position = Vector3.Lerp(transform.position, m_nextPosition, m_step);
    }

    public void MoveInput(InputAction.CallbackContext input)
    {
        m_inputVector = input.ReadValue<Vector2>();

        if (m_inputVector == Vector2.zero)
        {
            UpdateAnimator(m_currentState, 0, 8f);

            m_movementVector = Vector3.zero;
            return;
        }

        m_newState = "Player";

        if (m_inputVector.y > 0)
        {
            m_newState += "North";
        }
        else if (m_inputVector.y < 0)
        {
            m_newState += "South";
        }

        if (m_inputVector.x > 0)
        {
            m_newState += "East";
        }
        else if (m_inputVector.x < 0)
        {
            m_newState += "West";
        }

        UpdateAnimator(m_newState);

        m_movementVector = new Vector3(m_inputVector.x, 0, m_inputVector.y);
    }

    public void CrouchInput(InputAction.CallbackContext input)
    {
        m_isPlayerCrouching = input.ReadValueAsButton();

        if (!m_isPlayerCrouching)
        {
            UpdateAnimator(m_currentState);

            m_currentMovementSpeed = _movementSpeed;

            return;
        }

        UpdateAnimator(m_currentState, .3f);

        m_currentMovementSpeed = _movementSpeed * _crouchMultiplier;
    }

    private void UpdateAnimator(string animationState, float playbackSpeed = 1f, float frameNumber = 0f)
    {
        if (playbackSpeed >= 0f)
        {
            _animator.speed = playbackSpeed;

            AnimationClip clip = _animator.GetCurrentAnimatorClipInfo(0)[0].clip;

            float normalizedTime = frameNumber / clip.frameRate / clip.length;

            normalizedTime = Mathf.Clamp01(normalizedTime);

            _animator.Play(animationState, 0, normalizedTime);

            return;
        }

        _animator.speed = playbackSpeed;

        _animator.Play(animationState);

        m_currentState = animationState;
    }
}
