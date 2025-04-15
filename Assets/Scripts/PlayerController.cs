using UnityEngine;

public class PlayerController : MonoBehaviour {

    private float _cameraOffset = 7f;

    private Rigidbody _rb;

    [SerializeField] Camera camera;
    [SerializeField] float _playerSpeed;
 
    void Start() {
        _rb = GetComponent<Rigidbody>();
    }

    void Update() {
        PlayerMovement();
    }

    private void PlayerMovement() {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
        _rb.MovePosition(_rb.position+ direction * _playerSpeed * Time.deltaTime);
        //transform.Translate(direction * _playerSpeed * Time.deltaTime);
        Vector3 cameraPosition = transform.position + new Vector3(0, 3, -_cameraOffset);
        camera.transform.position = cameraPosition;
    }
}
