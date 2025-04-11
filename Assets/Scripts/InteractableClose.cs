using UnityEngine;
using System.Linq;
using System.Collections;
using UnityEngine.InputSystem.Haptics;
public class InteractableClose : MonoBehaviour
{

    public LayerMask interactLayer;
    public float searchDistance = 5f;
    public float delay = 0.5f;
    public float duration = 0.1f;
    public float intensity = 0.5f;
    public float closestDistance;
    private Coroutine pulseCoroutine;

    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, searchDistance, interactLayer);
        if (colliders.Any())
        {

            closestDistance = float.MaxValue;
            foreach (Collider collider in colliders)
            {
                //  if (collider.gameObject.layer )

                float distance = Vector3.Distance(transform.position, collider.transform.position);
                if (distance < closestDistance)
                    closestDistance = distance;
            }

             //intensity = Mathf.Lerp(1, 0, closestDistance / searchDistance);

            Debug.Log($"Closest object: {colliders.First().name}, Distance: {intensity}");
            if (Haptics.instance != null && pulseCoroutine == null)
            {
                Debug.Log("Started Coroutine" + pulseCoroutine);
                pulseCoroutine = StartCoroutine(Pulse());
            }
        }
        else
        {
            StopAllCoroutines();
        }
       

    }
    IEnumerator Pulse()
    {
        while (closestDistance<searchDistance)
        {
            Debug.Log("GOOOOATED");
            Haptics.instance.PulseHaptics(intensity, intensity, duration);
            yield return new WaitForSeconds(delay);
            
        }
        pulseCoroutine = null;
        Debug.Log("STOPPED");
    }
}
