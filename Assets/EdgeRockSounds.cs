using System.Collections;
using UnityEngine;

public class EdgeRockSounds : MonoBehaviour
{
    public AK.Wwise.Event soundEvent;
    public BoxCollider bc;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Start()
    {
        bc = GetComponent<BoxCollider>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerBehavior player))
        {
            Debug.Log("fall rocks r falling");
            soundEvent.Post(gameObject);
            StartCoroutine(SoundReset());
        }
        
    }
    IEnumerator SoundReset()
    {
        bc.enabled = false;
        yield return new WaitForSeconds(10f);
        bc.enabled = true;
    }
    
}
