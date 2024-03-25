using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private string m_currentState;
    private string m_newState;
    private float m_playbackSpeed;

    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _crouchMultiplier;

    private float m_currentMovementSpeed;
    private bool m_isPlayerCrouching;

    private Vector2 m_inputVector;
    private Vector3 m_movementVector;

    private Vector3 m_nextPosition;
    private float m_step;

    private void Start()
    {
        m_currentMovementSpeed = _movementSpeed;

        m_playbackSpeed = 1f;
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
            m_playbackSpeed = 0f;

            UpdateAnimator(m_currentState, m_playbackSpeed, 0f);

            m_movementVector = Vector3.zero;

            return;
        }
        else
        {
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

            m_playbackSpeed = m_isPlayerCrouching ? _crouchMultiplier : 1f;
        }

        UpdateAnimator(m_newState, m_playbackSpeed, 0f);

        m_movementVector = new Vector3(m_inputVector.x, 0, m_inputVector.y);
    }

    public void CrouchInput(InputAction.CallbackContext input)
    {
        m_isPlayerCrouching = input.ReadValueAsButton();

        m_playbackSpeed = m_inputVector != Vector2.zero ?
            (m_isPlayerCrouching ? _crouchMultiplier : 1f) : 0f;

        m_currentMovementSpeed = m_isPlayerCrouching ?
            _movementSpeed * _crouchMultiplier : _movementSpeed;

        UpdateAnimator(m_currentState, m_playbackSpeed, 0f);
    }

    private void UpdateAnimator(string animationState, float playbackSpeed = 1f, float frameNumber = 0f)
    {
        AnimationClip clip = _animator.GetCurrentAnimatorClipInfo(0)[0].clip;

        float normalizedTime = frameNumber / clip.frameRate / clip.length;

        normalizedTime = Mathf.Clamp01(normalizedTime);

        _animator.speed = playbackSpeed;

        _animator.Play(animationState, 0, normalizedTime);

        m_currentState = animationState;
    }
}
