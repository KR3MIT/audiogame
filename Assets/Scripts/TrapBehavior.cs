using System.Collections;
using UnityEngine;

public class TrapBehavior : MonoBehaviour
{
    public AK.Wwise.Event spikeExtendTrapSound;  
    public AK.Wwise.Event spikeRetractTrapSound;
    
    public int spikeTrapDamage = 25;
    public float spikeRate;
    public int spikeClosedDuration;
    private BoxCollider bc;
    private MeshRenderer mr;
    void Start()
    {
       bc = GetComponent<BoxCollider>();
       mr = GetComponent<MeshRenderer>();
       StartCoroutine(SpikeTrap());
 
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerBehavior behaviour))
        {
            Debug.Log("Player hit a spike trap!");
            behaviour.TakeDamage(spikeTrapDamage);
        }
    }
    IEnumerator SpikeTrap()
    {
        while (true)
        {
            //PLAY SPIKE EXTEND TRAP SOUND
            spikeExtendTrapSound.Post(gameObject);
            bc.enabled = true;
            mr.enabled = true;
            yield return new WaitForSeconds(spikeRate);
            //PLAY SPIKE RETRACT TRAP SOUND
            spikeRetractTrapSound.Post(gameObject);
            bc.enabled = false;
            mr.enabled = false;
            yield return new WaitForSeconds(spikeClosedDuration);
        }
    }

}
