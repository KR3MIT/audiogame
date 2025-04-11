using System.Linq;
using UnityEngine;

public class DangerClose : MonoBehaviour
{
    public LayerMask dangerLayer;
    public float searchDistance = 5f;

    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, searchDistance, dangerLayer);
        if (colliders.Any())
        {
           
            float closestDistance = float.MaxValue;
            foreach (Collider collider in colliders)
            {
              //  if (collider.gameObject.layer )

                float distance = Vector3.Distance(transform.position, collider.transform.position);
                if (distance < closestDistance)
                    closestDistance = distance;
            }

            var intensity = Mathf.Lerp(1, 0, closestDistance / searchDistance);

            Debug.Log($"Closest object: {colliders.First().name}, Distance: {intensity}");
            if (Haptics.instance != null)
                Haptics.instance.SetMotorSpeeds(intensity, intensity);
        }
        else
        {
            if (Haptics.instance != null)
                Haptics.instance.ResetHaptics(); 
        }

    }
}
