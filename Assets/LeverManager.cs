using UnityEngine;
using UnityEngine.Events;

public class LeverManager : MonoBehaviour
{
    public UnityEvent OnComplete;
  
    public float leverPullTime;
    public float leverPullTime2;

    public float timeToBeat = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    
    public void FirstLeverPulled()
    {
        leverPullTime = Time.time;
        if(leverPullTime2 != 0)
        {
            if(leverPullTime - leverPullTime2 < timeToBeat)
            {
                Debug.Log("Levers Pulled in time");
                OnComplete?.Invoke();
            }
            else
            {
                Debug.Log("Levers not Pulled in time");
                leverPullTime = 0;
                leverPullTime2 = 0;
            }
        }

    }
    public void SecondLeverPulled()
    {
        leverPullTime2 = Time.time;
        if (leverPullTime != 0)
        {
            if (leverPullTime2 - leverPullTime < timeToBeat)
            {
                Debug.Log("Levers Pulled in time");
                OnComplete?.Invoke();
            }
            else
            {
                Debug.Log("Levers not Pulled in time");
                leverPullTime = 0;
                leverPullTime2 = 0;
            }
        }
    }
   


}
