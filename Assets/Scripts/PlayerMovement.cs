using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private PlayerInput input;

    public float movespeed = 5.0f;
    public float lookspeed = 0.1f;
    public float lookX = 0;
   
    public float speed {get; private set;}
    void Start()
    {
       controller = GetComponent<CharacterController>();
       input = GetComponent<PlayerInput>();

    }


    // Update is called once per frame
    void Update()
    {
        //move logic
        Vector2 move = input.actions["Move"].ReadValue<Vector2>();
        Vector3 moveDirection = new Vector3(move.x, 0, move.y);
        moveDirection = transform.TransformDirection(moveDirection);
        Vector3 moveVec = moveDirection * movespeed;
        controller.Move(moveVec * Time.deltaTime);
        controller.Move(Physics.gravity * Time.deltaTime);
        speed = moveVec.magnitude;
        
        //look logic
        Vector2 look = input.actions["Look"].ReadValue<Vector2>();     
        lookX += look.x * lookspeed;
        transform.rotation = Quaternion.Euler(0, lookX, 0);
    }

    
}
