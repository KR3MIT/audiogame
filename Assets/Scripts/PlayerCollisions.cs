using Unity.VisualScripting;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    public LayerMask wallLayer;
    private float radius = 0.5f;
    private float offset = 0.1f;
    public PlayerMovement playerMovement;
    
    public AK.Wwise.Event playerCollisionEvent;
    public AK.Wwise.Event stopRubEvent;

    
    private void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            Debug.Log("Player hit a wall!");
            playerCollisionEvent.Post(transform.root.gameObject);
            //play Wall collision sound with Wwise ;) 
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            stopRubEvent.Post(transform.root.gameObject);
            
        }
    }

}
