using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    public Character character;
    public CharacterAnimator anim;
    public PlayerInput playerInput;
    private Vector2 rawInputMovement;
    private Vector2 smoothInputMovement;
    public float movementSmoothingSpeed = 0.7f;

    Vector3 _dir;
    bool _isMoving;

    void Awake()
    {
        character = GetComponent<Character>();
        anim = GetComponentInChildren<CharacterAnimator>();
    }

    void Update()
    {
        //HandleInput();
        HandleMovement();
    }

    public void OnMovementJoystick(InputAction.CallbackContext value)
    {
        Vector2 inputMovement = value.ReadValue<Vector2>();
        _dir = new Vector2(inputMovement.x, inputMovement.y);
        print(_dir);
    }

    void HandleInput()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        _dir = new Vector2(horizontal, vertical).normalized;
    }

    void HandleMovement()
    {
        gameObject.transform.position += _dir * character.Speed * Time.deltaTime;

        if(_dir.x != 0)
        {
            anim.MoveX = _dir.x;

            if (_dir.x > 0) anim.FlipSprite(false);
            else anim.FlipSprite(true);
        }

        if (_dir != Vector3.zero) _isMoving = true;
        else _isMoving = false;

        anim.IsMoving = _isMoving;
    }

}
