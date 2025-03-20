using System.Collections;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerThrow : MonoBehaviour
{
    public float RockThrowRate = 2f;
    public GameObject RockPrefab; //set in editor
    private PlayerInput input;
    bool canThrow = true;
    private Vector3 offset;

    private void Start()
    {
        input = GetComponent<PlayerInput>();
        offset = transform.position + new Vector3(0, 1, 0);
        //subsribe to the throw action
        input.actions["Attack"].performed += ctx => RockThrow();
    }
 
    void RockThrow()
    {   
        
        GameObject rock = Instantiate(RockPrefab, offset, quaternion.identity);
        Rigidbody rb = rock.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 10, ForceMode.Impulse);
    }
    

    

    
}
