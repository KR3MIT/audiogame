using System.Collections;
using UnityEngine;

public class TrapBehavior : MonoBehaviour
{
    public int SpikeTrapDamage = 100;
    void Start()
    {
        StartCoroutine(SpikeTrap());
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Debug.Log("Player hit a spike trap!");
            //PLAY SPIKE TRAP SOUND 
            other.gameObject.GetComponent<PlayerBehavior>().takeDamage(SpikeTrapDamage);
        }
    }
    IEnumerator SpikeTrap()
    {
        while (true)
        {
            //PLAY SPIKE TRAP SOUND
            gameObject.GetComponent<BoxCollider>().enabled = true;
            yield return new WaitForSeconds(3);
            gameObject.GetComponent<BoxCollider>().enabled = false;
            yield return new WaitForSeconds(3);
        }
    }

}
