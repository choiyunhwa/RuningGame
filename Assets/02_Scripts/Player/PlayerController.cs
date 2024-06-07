using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Slider healthSlider;
    private Vector2 curMovementInput;
    private Camera mainCamera;
    private float minX = -3f;
    private float maxX = 3f;
    private Rigidbody rigidbody;
    private bool Ismouse = false;


    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        mainCamera =Camera.main;
    }

    public void OnMouseClik(InputAction.CallbackContext context)
    {
        Vector2 mousePostition = context.ReadValue<Vector2>();
    }
   
    public void OnMoveMouse(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
          
            curMovementInput = context.ReadValue<Vector2>();
            Ray ray = mainCamera.ScreenPointToRay(curMovementInput); //충동한위치 
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                //Debug.Log(hit.point);
                float xpos = Mathf.Clamp(hit.point.x, minX, maxX);
                transform.position =new Vector3(xpos,transform.position.y,transform.position.z);
                
            }
          
          

        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            curMovementInput = Vector2.zero;
            Ismouse = false;
        }
    }
 
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           

        }

    }
}
