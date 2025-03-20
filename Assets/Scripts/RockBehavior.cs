using UnityEngine;
using UnityEngine.Rendering.Universal;

public class RockBehavior : MonoBehaviour
{
    public AK.Wwise.Event rockHitEvent;
    
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
            audioMaterial.materialSwitch.SetValue(gameObject);
            rockHitEvent.Post(gameObject);
        }
    }
}
