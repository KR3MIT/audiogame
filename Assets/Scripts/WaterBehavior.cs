using UnityEngine;

public class WaterBehavior : MonoBehaviour
{
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerBehavior playerBehavior))
        {
            PlayerBehavior.instance.StartCoroutine(PlayerBehavior.instance.Death());
        }
    }
}
