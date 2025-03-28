using UnityEngine;
using AK;
public class AxeTrap : MonoBehaviour
{
    public int axeTrapDamage = 50;
    public bool turbo = false;
    public Animator anim;
    private float _randomTime;
    public AK.Wwise.Event axeSwingEvent;
    public bool axeSwinging = false;
    void Start()
    {
        var temp = Random.Range(0, 100);
        _randomTime = temp / 100f;
        
        anim = GetComponentInParent<Animator>();

        if (turbo)
            anim.SetBool("Turbo", true);

        //PlayerSounds.FootstepEvent += PlaySound;

    }

    private void Update()
    {
        if (axeSwinging)
        {
            //Debug.Log("Axe is swinging");
            axeSwingEvent.Post(transform.root.gameObject);
            //Debug.Log("Axe Swing Event Posted");
            axeSwinging = false;
            //Debug.Log("Axe Swinging is now false");
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
