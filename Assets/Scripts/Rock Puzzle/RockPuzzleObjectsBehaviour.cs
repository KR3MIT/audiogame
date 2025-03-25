using UnityEngine;

public class RockPuzzleObjectsBehaviour : MonoBehaviour
{
    private Vector3 startPosition;
    private int direction = 1; // 1 for right, -1 for left
    private float distanceMoved = 0f;

    [SerializeField] private bool isCircular; // Toggle between linear and circular pathing

    [Header("Linear Pathing Settings")]
    [SerializeField] private bool moveX;
    [SerializeField] private bool moveZ;
    [SerializeField] private float moveDistance = 10f;
    [SerializeField] private float moveSpeed = 2f;

    [Header("Circular Pathing Settings")]
    [SerializeField] private float radius = 5f;
    [SerializeField] private float rotationSpeed = 0.5f;

    private float angle = 0f; // Current angle for circular pathing

    void Start()
    {
        startPosition = transform.position; // Record the starting position
        // play Wwise Sound hovering noise
    }

    void Update()
    {
        if (isCircular)
        {
            MoveInCircle();
        }
        else
        {
            MoveLinearly();
        }
    }

    private void MoveLinearly()
    {
        // Move the object in a straight line
        float moveStep = moveSpeed * Time.deltaTime * direction;

        if (moveX)
        {
            transform.Translate(moveStep, 0, 0); // Move along the X axis
        }
        else if (moveZ)
        {
            transform.Translate(0, 0, moveStep); // Move along the Z axis
        }

        distanceMoved += Mathf.Abs(moveStep);
        MoveDirection();
    }

    private void MoveDirection()
    {
        // Check if the object needs to change direction
        if (direction == 1 && distanceMoved >= moveDistance) // Moving right
        {
            direction = -1; // Change direction to left
            distanceMoved = 0f;
        }
        else if (direction == -1 && distanceMoved >= moveDistance) // Moving left
        {
            direction = 1; // Change direction to right
            distanceMoved = 0f;
        }
    }

    private void MoveInCircle()
    {
        // Increment the angle based on rotation speed
        angle += rotationSpeed * Time.deltaTime;

        // Calculate the new position using trigonometry
        float x = startPosition.x + Mathf.Cos(angle) * radius;
        float z = startPosition.z + Mathf.Sin(angle) * radius;

        // Update the object's position
        transform.position = new Vector3(x, transform.position.y, z);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Rock"))
        {
            // play Wwise Sound collision
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        // play Wwise Sound destroy
    }
}
