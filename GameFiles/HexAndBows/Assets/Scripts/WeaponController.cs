using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponController : MonoBehaviour
{
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack(InputAction.CallbackContext cntxt)
    {
        if (cntxt.started)
        {
            Debug.Log("Attack! " + cntxt.phase);
        }
        
        // Implement attack logic here
        
    }
}
