using System.Collections;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerThrow : MonoBehaviour
{
    public Task rockThrowTask;
    public AK.Wwise.Event RockThrowReleaseEvent;

    public float RockThrowRate = 2f;
    public GameObject RockPrefab; //set in editor
    private PlayerInput input;
    bool canThrow = true;
    [Header("Rock logic :nerdge:")]
    public static float force = 10f;
    public CharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        input = GetComponent<PlayerInput>();
        //subsribe to the throw action
        input.actions["Attack"].performed += ctx => RockThrow();
        RockThrowReleaseEvent.Post(gameObject);
    }
 
    void RockThrow()
    {
        if(!canThrow) return;
        Vector3 offset = transform.position + transform.up; 
        GameObject rock = Instantiate(RockPrefab, offset, quaternion.identity);
        Rigidbody rb = rock.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * force + characterController.velocity, ForceMode.Impulse);
        canThrow = false;
        Invoke("ResetRockCooldown", RockThrowRate);             //lefunnymemeface
        RockThrowReleaseEvent.Post(gameObject);

        if (Haptics.instance != null)
        Haptics.instance.PulseHaptics(0.1f,0.1f, 0.05f);
        
      
        rockThrowTask?.CompleteTask();
    }
    private void ResetRockCooldown()
    {
        canThrow = true;
    }
}
