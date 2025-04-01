using UnityEngine;
using AK;
public class AxeTrap : MonoBehaviour
{
    public int axeTrapDamage = 50;
    public bool turbo = false;
    public Animator anim;
    private float _randomTime;
    public AK.Wwise.Event axeSwingEvent;
    void Start()
    {
        var temp = Random.Range(0, 100);
        _randomTime = temp / 100f;
        
        anim = GetComponentInParent<Animator>();

        if (turbo)
            anim.Play("AxeSwingFast",0, _randomTime);
        else
            anim.Play("AxeSwingSlow",0, _randomTime);
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
