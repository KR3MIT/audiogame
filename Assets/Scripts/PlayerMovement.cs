using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public static event System.Action OnMove;
    public static event System.Action OnStopMove;
    
    public ContinuousTask lookTask;
    public ContinuousTask moveTask;
    
    private CharacterController _controller;
    private PlayerInput _input;

    public float moveSpeed = 5.0f;
    public float mouseSensitivity;
    public float controllerSensitivity;
    
    private float _lookX = 0;
    private float _sens;
   
    public float Speed {get; private set;}
    public static float NormalizedSpeed {get; private set;}
    public AK.Wwise.RTPC playerSpeedRTPC;
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _input = GetComponent<PlayerInput>();
        
        Cursor.lockState = CursorLockMode.Locked;
    }
    // Update is called once per frame
    void Update()
    {
        #region PlayerControl
        if (_controller.enabled == false) {return; }
        //move logic
        Vector2 move = _input.actions["Move"].ReadValue<Vector2>();
        Vector3 moveDirection = new Vector3(move.x, 0, move.y);
        moveDirection = transform.TransformDirection(moveDirection);
        Vector3 moveVec = moveDirection * moveSpeed;
        
        var moveVector = (moveVec * Time.deltaTime) + (Physics.gravity * Time.deltaTime);
        _controller.Move(moveVector);
        //controller.Move(Physics.gravity * Time.deltaTime);
        Speed = moveVec.magnitude;
        
        //speed for rtpc
        var horizontalSpeed = new Vector2(_controller.velocity.x, _controller.velocity.z).magnitude;
        NormalizedSpeed = horizontalSpeed / moveSpeed;
        if (NormalizedSpeed > 0)
        {
            OnMove?.Invoke();
        }else
        {
            OnStopMove?.Invoke();
        }
        
        playerSpeedRTPC.SetValue(gameObject, NormalizedSpeed);
        
        if (moveTask != null)
        {
            moveTask.TrackAmount(Speed);
        }
        #endregion
        
        #region CameraControl
        
        //rotation logic
        Vector2 look = _input.actions["Look"].ReadValue<Vector2>();     
        _lookX += look.x * _sens;
        transform.rotation = Quaternion.Euler(0, _lookX, 0);

        if (lookTask != null)
            lookTask.TrackAmount(look.x);
        #endregion
        
        #region InputSensitivity
        if (_input.currentControlScheme == "Keyboard&Mouse")
            _sens = mouseSensitivity;
        else if (_input.currentControlScheme == "Gamepad")
            _sens = controllerSensitivity;
        #endregion
    }
}
