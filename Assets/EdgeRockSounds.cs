using System.Collections;
using UnityEngine;

public class EdgeRockSounds : MonoBehaviour
{
    public AK.Wwise.Event soundEvent;
    private BoxCollider bc;
    public float soundCooldown = 10f;
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Start()
    {
        bc = GetComponent<BoxCollider>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerBehavior player))
        {
            //Debug.Log("fall rocks r falling");
            soundEvent.Post(gameObject);
            if (Haptics.instance != null)
                Haptics.instance.PulseHaptics(0.50f, 0.75f, 1f);
            StartCoroutine(SoundReset());
        }
        
    }
    IEnumerator SoundReset()
    {
        bc.enabled = false;
        yield return new WaitForSeconds(soundCooldown);
        bc.enabled = true;
    }
    
}
