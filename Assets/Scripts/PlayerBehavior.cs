using NUnit.Framework;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public int health = 100;
    public Transform checkpoint;
    
    public void setCheckpoint(Vector3 pos)
    {
       checkpoint.position = pos;
        //a checkpoint has been checked, play sound
    }
    public void takeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Player took "+ damage +" damage. Health is now: " + health);

        if(health <= 0)
        { 
            transform.position = checkpoint.position;
            Debug.Log("A respawn has been respawned");
        }
    }
}
