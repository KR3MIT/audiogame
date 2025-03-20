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
        if (Input.GetKeyDown(KeyCode.R))
        {
            death();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Checkpoint")
        {
            //PLAY CHECKPOINT SOUND
            setCheckpoint(other.transform.position);
        }
    }
    public void setCheckpoint(Vector3 pos)
    {

       checkpoint = pos;
        //a checkpoint has been checked, play sound
    }
    public void takeDamage(int damage)
    {
        //PLAY DAMAGE NOISE
        health -= damage;
        Debug.Log("Player took "+ damage +" damage. Health is now: " + health);
        if (health <= 0)
        {
            death();
        }
    }
    IEnumerator death()
    {
        //PLAY DEATH SOUND
        controller.enabled = false;
        Debug.Log("A respawn has been respawned");
        yield return new WaitForSeconds(respawnTime);
        //play REVIVE SOUND
        transform.position = checkpoint;
        controller.enabled = true;
    }
  
}
