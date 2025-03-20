using UnityEditor.Rendering.Universal.ShaderGraph;
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
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<AudioMaterial>() != null)
        {
           var type = collision.gameObject.GetComponent<AudioMaterial>().type;
            //send to Wwise (good luck guys)
        }
    }
}
