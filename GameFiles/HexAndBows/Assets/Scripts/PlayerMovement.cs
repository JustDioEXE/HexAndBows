using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Input Actions")]
    public InputAction moveAction;

    public int moveSpeed;

    private Rigidbody2D rb;
    private Vector2 moveDir;

    private Transform hands;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Get the Rigidbody2D component attached to the player object
        rb = GetComponent<Rigidbody2D>();

        // Get the hands transform to use for aiming
        hands = transform.Find("Hands");
    }

    void OnEnable(){
        // Enable the move action when the script is enabled to allow input to be processed
        if (moveAction != null) moveAction.Enable();
    }

    void OnDisable(){
        // Disable the move action when the script is disabled to prevent input from being processed
        if (moveAction != null) moveAction.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate movement direction based on input
        Vector2 inputDir = moveAction.ReadValue<Vector2>();
        float x = inputDir.x;
        float y = inputDir.y;

        CalcHandsRotation();

        // Normalize the movement direction to ensure consistent speed in all directions
        moveDir = new Vector2(x, y).normalized;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = moveDir * moveSpeed;
    }

    private void CalcHandsRotation()
    {
        // Get the mouse position in world space
        Vector3 mouseScreenPos = Mouse.current.position.ReadValue();
        
        // Set the z-coordinate to the camera's z position to ensure correct depth
        mouseScreenPos.z = Mathf.Abs(Camera.main.transform.position.z); 

        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);

        // Set the z-coordinate to 0 to ensure the hands are rotated in the correct plane
        mouseWorldPos.z = 0f; 

        Vector3 aimDir = mouseWorldPos - hands.position;

        float angle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;

        // Adjust this value based on the initial orientation of the hands sprite
        float rotationalOffset = 90f; 

        hands.rotation = Quaternion.Euler(0f, 0f, angle - rotationalOffset);

    }
}
