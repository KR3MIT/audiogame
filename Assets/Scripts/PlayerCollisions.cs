using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    public LayerMask wallLayer;
    private float radius = 0.5f;
    private float offset = 0.1f;

    
    private void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            Debug.Log("Player hit a wall!");
            //play Wall collision sound with Wwise ;) 
        }
    }
   
}
