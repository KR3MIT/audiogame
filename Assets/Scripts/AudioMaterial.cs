using System;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class AudioMaterial : MonoBehaviour
{
    public AK.Wwise.Switch materialSwitch;

    public void Awake()
    {
        var rb = GetComponent<Rigidbody>();

        if (gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
        else
        {
            rb.isKinematic = true;
        }
    }
}
