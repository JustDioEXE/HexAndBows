using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public int moveSpeed;

    private Rigidbody2D rb;
    private Vector2 moveDir;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
