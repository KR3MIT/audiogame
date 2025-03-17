using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    public LayerMask wallLayer;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == wallLayer)
        {
            Debug.Log("Player hit a wall!");
            //play Wall collision sound with Wwise ;) 
        }
    }
}
