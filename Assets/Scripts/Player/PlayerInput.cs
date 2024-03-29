using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput: MonoBehaviour
{
    private InputControls _inputControls;
    
    [SerializeField]
    private PlayerController _playerController;
    
    private void Awake()
    {
        _inputControls = new InputControls();
        _inputControls.Player.Move.performed += OnMove;
    }

    private void OnEnable()
    {
        _inputControls.Enable();
    }

    private void OnMove(InputAction.CallbackContext obj)
    {
        _playerController.Move();
    }

    private void OnDisable()
    {
        _inputControls.Disable();
    }

    private void OnDestroy()
    {
        _inputControls.Player.Move.performed -= OnMove;
    }
}
