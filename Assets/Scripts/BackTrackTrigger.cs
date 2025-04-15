using UnityEngine;

public class BackTrackTrigger : MonoBehaviour
{
    public FairyController fairy;
    public int triggerID;

    private void Start()
    {
        fairy = GameObject.Find("Fairy").GetComponent<FairyController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (fairy.currentSpline > triggerID || fairy.currentSpline == fairy.splines.Count - 1)
            {
                StartCoroutine(fairy.Backtrack(triggerID));
            }
        }
    }
}
