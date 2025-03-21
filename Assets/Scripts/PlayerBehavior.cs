using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class PlayerBehavior : MonoBehaviour
{
    public int health = 100;
    public Vector3 checkpoint;
    private CharacterController controller;
    public float respawnTime;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        checkpoint = transform.position;
    }
    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    StartCoroutine(Death());
        //}
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Checkpoint")
        {
            //PLAY CHECKPOINT SOUND
            SetCheckpoint(other.transform.position);
        }
    }
    public void SetCheckpoint(Vector3 pos)
    {

       checkpoint = pos;
        //a checkpoint has been checked, play sound
    }
    public void TakeDamage(int damage)
    {
        //PLAY DAMAGE NOISE
        health -= damage;
        Debug.Log("Player took "+ damage +" damage. Health is now: " + health);
        if (health <= 0)
        {
            StartCoroutine(Death());
        }
    }
    IEnumerator Death()
    {
        //PLAY DEATH SOUND
        controller.enabled = false;
        Debug.Log("A respawn has been respawned");
        transform.position = checkpoint;
        yield return new WaitForSeconds(respawnTime);
        //play REVIVE SOUND
        health = 100;
        controller.enabled = true;
    }
 
    void Interact()
    {
        if(Physics.CheckSphere(transform.position, 5))
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, 5);
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.gameObject.tag == "Chest")
                {
                    hitCollider.gameObject.GetComponent<ChestBehavior>().OpenChest();
                }
            }
        }
    }
}
