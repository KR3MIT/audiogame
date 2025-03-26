using System.Collections;
using UnityEngine;

public class TrapBehavior : MonoBehaviour
{
    public int spikeTrapDamage = 25;
    public int spikeRate;
    private BoxCollider bc;
    private MeshRenderer mr;
    void Start()
    {
       bc = GetComponent<BoxCollider>();
       mr = GetComponent<MeshRenderer>();
       StartCoroutine(SpikeTrap());
       
        spikeRate = Random.Range(1, 5);
      
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
            bc.enabled = true;
            mr.enabled = true;
            yield return new WaitForSeconds(spikeRate);
            //PLAY SPIKE RETRACT TRAP SOUND
            bc.enabled = false;
            mr.enabled = false;
            yield return new WaitForSeconds(spikeRate);
        }
    }

}
