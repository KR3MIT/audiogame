using UnityEngine;
using System.Linq;
public class InteractableClose : MonoBehaviour
{

    public LayerMask interactLayer;
    public float searchDistance = 5f;
    public float duration = 0.5f;

    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, searchDistance, interactLayer);
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
                Haptics.instance.PulseHaptics(intensity, intensity, duration);
        }
        else
        {
            if (Haptics.instance != null)
                Haptics.instance.ResetHaptics();
        }

    }
}
