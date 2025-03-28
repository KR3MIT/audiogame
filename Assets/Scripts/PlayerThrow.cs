using System.Collections;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerThrow : MonoBehaviour
{
    public Task rockThrowTask;
    
    public float RockThrowRate = 2f;
    public GameObject RockPrefab; //set in editor
    private PlayerInput input;
    bool canThrow = true;
    [Header("Rock logic :nerdge:")]
    public static float force = 10f;
   

    private void Start()
    {
        input = GetComponent<PlayerInput>();
        //subsribe to the throw action
        input.actions["Attack"].performed += ctx => RockThrow();
    }
 
    void RockThrow()
    {
        if(!canThrow) return;
        Vector3 offset = transform.position + transform.forward + transform.up; 
        GameObject rock = Instantiate(RockPrefab, offset, quaternion.identity);
        Rigidbody rb = rock.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * force, ForceMode.Impulse);
        canThrow = false;
        Invoke("ResetRockCooldown", RockThrowRate);
        
        Haptics.instance.PulseHaptics(0.25f,0.75f, 0.1f);
        
        rockThrowTask?.CompleteTask();
    }
    private void ResetRockCooldown()
    {
        canThrow = true;
    }
}
