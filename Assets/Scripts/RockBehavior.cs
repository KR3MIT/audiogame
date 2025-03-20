using UnityEngine;
using UnityEngine.Rendering.Universal;

public class RockBehavior : MonoBehaviour
{
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent <Rigidbody>();

    }
    void Update()
    {
        if (rb.IsSleeping())
        {
            Debug.Log("Rock is sleeping");
            Destroy(gameObject);
        }
    }

}
