using UnityEngine;
using System.Collections;
public class StaticSoundSource : MonoBehaviour
{
    public AK.Wwise.Event soundEvent;
    private float _randomTime;

    public float Delay = 1f;
    private bool isPlaying;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
  
    void FixedUpdate()
    {
        if(!isPlaying)
            StartCoroutine(PlaySound());
        
        
    }
    IEnumerator PlaySound()
    {
        var temp = Random.Range(0, 100);
        _randomTime = temp / 100f + 0.5f;

        isPlaying = true;
            
        yield return new WaitForSeconds(Delay + _randomTime);
        //Debug.Log("Playing Sound");
        soundEvent.Post(gameObject);
        isPlaying = false;
    }

}
