using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {

    private float _cameraOffset = 7f;
    private Rigidbody _rb;
    private InputAction _move;
    private InputAction _attack;
    private InputSystem_Actions _playerControls;
    private Animator _animator;

    [SerializeField] Camera camera;
    [SerializeField] float _moveForce;

    private void Awake() {
        _playerControls = new InputSystem_Actions();
        _animator = GetComponent<Animator>();
    }

    void Start() {
        _rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        PlayerMovement();
    }
    private void OnEnable() {
        _move = _playerControls.Player.Move;
        _move.Enable();
    }
    private void OnDisable() {
        _move.Disable();
    }
    private void PlayerMovement() {
        Vector2 input = _move.ReadValue<Vector2>();
        Vector3 direction = new Vector3(input.x, 0, input.y);
        _rb.AddForce(direction*_moveForce, ForceMode.Acceleration);
        Vector3 velocity = _rb.GetPointVelocity(_rb.worldCenterOfMass);
        float speed = new Vector3(velocity.x, 0, velocity.z).magnitude;

        _animator.SetFloat("_speed", speed);
        Vector3 cameraPosition = transform.position + new Vector3(0, 3, -_cameraOffset);
        camera.transform.position = cameraPosition;
    }
}
