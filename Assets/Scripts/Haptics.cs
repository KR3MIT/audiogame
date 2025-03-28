using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
public class Haptics : MonoBehaviour
{
    [Header("Only PS 4 and Xbox controllers are supported")]
    public static Haptics instance;
    private Gamepad _gamepad; 
    private void Awake()
    {
        if (instance == null)
            instance = this;
        SetController();
    }
    private void SetController()
    {
        _gamepad = Gamepad.current;
    }
    public void SetMotorSpeeds(float lowFrequency, float highFrequency)
    {
        SetController();
        _gamepad.SetMotorSpeeds(lowFrequency, highFrequency);
    }
    public void PauseHaptics()
    {
        _gamepad.PauseHaptics();
    }
    public void ResumeHaptics()
    {
        _gamepad.ResumeHaptics();
    }
    public void ResetHaptics()
    {
        _gamepad.ResetHaptics();
    }
    public void PulseHaptics(float lowFrequency, float highFrequency, float duration)
    {
        if (IsInvoking("Pulse"))
            return;
        StartCoroutine(Pulse(lowFrequency, highFrequency, duration));
    }
    public IEnumerator Pulse(float lowFrequency, float highFrequency, float duration)
    {
        SetMotorSpeeds(lowFrequency, highFrequency);
        yield return new WaitForSeconds(duration);
        PauseHaptics();
    }
}
