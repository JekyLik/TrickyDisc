using JetBrains.Annotations;
using UnityEngine;

public class PlayerController: MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rigidbody;
    [SerializeField]
    private float _movementVelocity;
    [SerializeField]
    private SpriteRenderer _aimSprite;
    [SerializeField]
    private PlayerRotator _playerRotator;
    [SerializeField]
    private UserMoveTimeLimiter _userMoveTimeLimiter;
    [SerializeField]
    private AudioSource _moveAudioClip;
    [SerializeField]
    private ParticleSystem _deathParticlesPrefab;
    
    private Vector3 _startPosition;
    private bool _isMoving;
    
    private void Awake()
    {
        _startPosition = transform.position;
        _isMoving = false;
    }

    [UsedImplicitly]
    public void Move() //вызывается через коллбэк нажатия кнопки передвижения
    {
        if (!_isMoving)
        {
            _isMoving = !_isMoving;
            _aimSprite.enabled = false;
            _playerRotator.StopRotation();
            _userMoveTimeLimiter.StopTimeLimiter();
            _moveAudioClip.Play();
            
            _rigidbody.velocity = transform.up * _movementVelocity;
        }
    }
    
    [UsedImplicitly]
    public void ChangeDirection() //вызывается через ивент, при коллизии игрока с врагом
    {
        _rigidbody.velocity *= -1;
    }
    
    [UsedImplicitly]
    public void ResetPosition() //вызывается через ивент, при возвращении игрока в стар поинт триггер
    {
        if (_isMoving)
        {
            _isMoving = !_isMoving;
            _aimSprite.enabled = true;
            _playerRotator.StartRotation();
            _userMoveTimeLimiter.RestartTimeLimiter();

            _rigidbody.velocity = Vector2.zero;
            transform.position = _startPosition;
        }
    }
    
    [UsedImplicitly]
    public void OnPlayerDied() //вызывается по ивенту смерти игрока
    {
        Instantiate(_deathParticlesPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
