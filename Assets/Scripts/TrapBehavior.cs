using System.Collections;
using UnityEngine;

public class TrapBehavior : MonoBehaviour
{
    public int spikeTrapDamage = 100;
    public int spikeRate = 2;
    private BoxCollider bc;
    void Start()
    {
       bc = GetComponent<BoxCollider>();
       StartCoroutine(SpikeTrap());

    }
    private void OnTriggerEnter(Collider other)
    {
        if(TryGetComponent(out PlayerBehavior behaviour))
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
            yield return new WaitForSeconds(spikeRate);
            //PLAY SPIKE RETRACT TRAP SOUND
            bc.enabled = false;
            yield return new WaitForSeconds(spikeRate);
        }
    }

}
