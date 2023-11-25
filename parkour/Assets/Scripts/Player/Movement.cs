using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Movement : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI speed_text;
    private float speed_float; 

    [Header("Camera")]
    private float yaw, pitch;
    public Transform camera_transform;
    public float sensitivity;

    [Header("Movement")]
    private float speed;
    public float walk_speed;
    public float sprint_speed;

    [Header("Jump")]
    public float jump_force;
    private Vector3 jump;
    private bool is_grounded;

    [Header("Keybinds")]
    public KeyCode jump_key = KeyCode.Space;
    public KeyCode sprint_key = KeyCode.LeftShift;

    [Header("MovementState")]
    public MovementState state;

    // COMPONENTS
    private Rigidbody rb;

    public enum MovementState{
        walking,
        sprinting,
        air,
    }

    private void Start()
    {
        speed_text.text = speed_float.ToString();

        jump = new Vector3(0.0f, 2.0f, 0.0f);
        Cursor.lockState = CursorLockMode.Locked;
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void OnCollisionStay()
    {
        is_grounded = true;
    }

    private void Update()
    {
        StateHandler();

        // SPEED COUNTER
        speed_float = rb.velocity.magnitude;
        speed_text.text = speed_float.ToString("F1");

        // CAMERA
        pitch -= Input.GetAxisRaw("Mouse Y") * sensitivity;
        pitch = Mathf.Clamp(pitch, -90, 90);
        yaw += Input.GetAxisRaw("Mouse X") * sensitivity;
        Camera.main.transform.localRotation = Quaternion.Euler(pitch, yaw, 0);

        // JUMP 
        if (Input.GetKeyDown(jump_key) && is_grounded)
        {
            rb.AddForce(jump * jump_force, ForceMode.Impulse);
            is_grounded = false;
        }
    }

    private void FixedUpdate()
    {
        // MOVEMENT
        Vector2 axis = new Vector2(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal")) * speed;
        Vector3 forward = new Vector3(-Camera.main.transform.right.z, 0, Camera.main.transform.right.x);
        Vector3 wishDirection = (forward * axis.x + Camera.main.transform.right * axis.y + Vector3.up * rb.velocity.y);
        rb.velocity = wishDirection;
    }

    private void StateHandler()
    {
        if(is_grounded && Input.GetKey(sprint_key))
        {
            state = MovementState.sprinting;
            speed = sprint_speed;
        }
        else if(is_grounded)
        {
            state = MovementState.walking;
            speed = walk_speed;
        }
        else
        {
            state = MovementState.air;
        }
    }
}
