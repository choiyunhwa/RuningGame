using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public HealthBar healthBar;
    public float speed;
    private Vector2 curMovementInput;
    private Camera mainCamera;
    private float minX = -3f;
    private float maxX = 3f;
    public Rigidbody rigidbody;
    private bool Ismouse =false;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public void OnMoveMouse(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            curMovementInput= context.ReadValue<Vector2>();
            Ismouse = true;
        }
        else if (context.phase == InputActionPhase.Canceled)  
        {
            curMovementInput = Vector2.zero;
            Ismouse = false;
        }
    }

   
    private void Move()
    {
        Vector3 go =  transform.right * curMovementInput.x *speed*Time.deltaTime;
        Vector3 newgo = transform.position + go;
        newgo.x = Mathf.Clamp(newgo.x, minX, maxX);
        transform.position = newgo;

        
    }


        // Start is called before the first frame update
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            Debug.Log(curMovementInput.x);
        if (Ismouse)
        {
        Move();

        }

    }
}
