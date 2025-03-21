using UnityEngine;

public class AxeTrap : MonoBehaviour
{

    public int axeTrapDamage = 50;
    private BoxCollider bc;
    public bool turbo = false;
    public Animator anim;
    void Start()
    {
        bc = GetComponent<BoxCollider>();
        anim = GetComponentInParent<Animator>();
        TurboMode(turbo);
    }

    public void TurboMode(bool turbo)
    {
        if (turbo)
        {
            anim.SetBool("Turbo", true);
        }
        else
        {
            anim.SetBool("Turbo", false);
        }
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
