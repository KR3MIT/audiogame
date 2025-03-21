using UnityEngine;

public class AxeTrap : MonoBehaviour
{

    public int axeTrapDamage = 50;
    private BoxCollider bc;
    void Start()
    {
        bc = GetComponent<BoxCollider>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerBehavior behaviour))
        {
            Debug.Log("Player hit a spike trap!");
            behaviour.TakeDamage(axeTrapDamage);
        }
    }
}
