using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Input Actions")]
    public InputAction moveAction;

    public int moveSpeed;

    private Rigidbody2D rb;
    private Vector2 moveDir;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnEnable(){
        if (moveAction != null) moveAction.Enable();
    }

    void OnDisable(){
        if (moveAction != null) moveAction.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputDir = moveAction.ReadValue<Vector2>();
        float x = inputDir.x;
        float y = inputDir.y;

        moveDir = new Vector2(x, y).normalized;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = moveDir * moveSpeed;
    }
}
