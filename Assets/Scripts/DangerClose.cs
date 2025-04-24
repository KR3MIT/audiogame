using System.Linq;
using UnityEngine;

public class DangerClose : MonoBehaviour
{
    public LayerMask dangerLayer;
    public float searchDistance = 3f;
    private bool shouldStop = false;
    private Collider trapCollider;

    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, searchDistance, dangerLayer);
        if (colliders.Any())
        {
            shouldStop = true;
           
            float closestDistance = float.MaxValue;
            foreach (Collider collider in colliders)
            {

                float distance = Vector3.Distance(transform.position, collider.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    trapCollider = collider;
                }
            }

            var intensity = Mathf.Lerp(1, 0, closestDistance / searchDistance);

            //Debug.Log($"Closest object: {colliders.First().name}, Distance: {intensity}");
            if (Haptics.instance != null)
                if (trapCollider.gameObject.TryGetComponent(out AxeTrap axeTrap))
                {
                    axeTrap.applyHapticsForAxe = true;
                } 
                else
                {

                    Haptics.instance.SetMotorSpeeds(intensity, intensity);
                }
        }
        else
        {
            if (Haptics.instance != null && shouldStop)
            {
                Haptics.instance.SetMotorSpeeds(0f, 0f); 
                shouldStop = false;
            }
        }

    }
}
