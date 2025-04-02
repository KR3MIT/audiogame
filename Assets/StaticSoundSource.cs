using UnityEngine;

public class StaticSoundSource : MonoBehaviour
{
    public AK.Wwise.Event soundEvent;
    private float _randomTime;
    [Range(0, 1)]
    public float chance = 0.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
  
    void Update()
    {
        var temp = Random.Range(1, 100);
        _randomTime = temp / 100f;
        if (_randomTime > chance)
        {
            soundEvent.Post(gameObject);
        }
    }

}
