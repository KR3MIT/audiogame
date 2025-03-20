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
      
        if(collision.gameObject.TryGetComponent(out AudioMaterial audioMaterial))
        {
            var type = audioMaterial.type;
            //send to Wwise (good luck guys)
            Debug.Log("Rock hit " + type);
        }
    }
}
