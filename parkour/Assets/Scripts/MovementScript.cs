using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MovementScript : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI SpeedText;
    public float speedFloat; 

    [Header("Camera")]
    private float yaw, pitch;
    public Transform camera;

    [Header("Movement")]
    private Rigidbody rb;
    public float  sensitivity, jumpforce;
    private float speed;
    public float walkSpeed;
    public float sprintSpeed;
    [Header("Dush")]
    public float dushPower;
    public bool canDush;
    public int todush = 1;
    public int dushs = 2;

    [Header("Jump")]
    private Vector3 jump;
    public bool isGrounded;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode sprintKey = KeyCode.LeftShift;
    public KeyCode dushKey = KeyCode.Space;

    [Header("MovementState")]
    public MovementState state;

    public enum MovementState{
        walking,
        sprinting,
        air,
    }
    private void Start()
    {
        SpeedText.text = speedFloat.ToString();

        jump = new Vector3(0.0f, 2.0f, 0.0f);
        Cursor.lockState = CursorLockMode.Locked;
        rb = gameObject.GetComponent<Rigidbody>();
    }
    void OnCollisionStay()
    {
        dushs = 2;
        todush = 1;
        isGrounded = true;
    }

    private void Update()
    {
        if (todush == 0){
            canDush = true;
        }else{
            canDush = false;
        }
        StateHandler();
        // speed counter
        speedFloat = rb.velocity.magnitude;
        SpeedText.text = speedFloat.ToString("F1");

        //Camera Controll
        pitch -= Input.GetAxisRaw("Mouse Y") * sensitivity;
        pitch = Mathf.Clamp(pitch, -90, 90);
        yaw += Input.GetAxisRaw("Mouse X") * sensitivity;
        Camera.main.transform.localRotation = Quaternion.Euler(pitch, yaw, 0);

        //Jump
        if (Input.GetKeyDown(jumpKey) && isGrounded)
        {
            todush -= 1;
            rb.AddForce(jump * jumpforce, ForceMode.Impulse);
            isGrounded = false;
        }
        if (Input.GetKeyDown(dushKey) && canDush && dushs >= 1)
        {
            rb.AddForce(camera.transform.forward * dushPower * 10000);
            dushs -= 1;
        }

    }
    private void FixedUpdate()
    {
        //Movement
        Vector2 axis = new Vector2(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal")) * speed;
        Vector3 forward = new Vector3(-Camera.main.transform.right.z, 0, Camera.main.transform.right.x);
        Vector3 wishDirection = (forward * axis.x + Camera.main.transform.right * axis.y + Vector3.up * rb.velocity.y);
        rb.velocity = wishDirection;
    }
    private void StateHandler(){
        if(isGrounded && Input.GetKey(sprintKey)){
            state = MovementState.sprinting;
            speed = sprintSpeed;
        }
        else if(isGrounded){
            state = MovementState.walking;
            speed = walkSpeed;
        }
        else{
            state = MovementState.air;
        }
    }
}
