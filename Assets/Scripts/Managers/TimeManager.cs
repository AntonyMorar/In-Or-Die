using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float slowDownFactor = 0.01f;

    public void SlowMotion(bool doSlow=true)
    {
        if (doSlow)
        {
            Time.timeScale = slowDownFactor;
        }
        else
        {
            Time.timeScale = 1;
        }

        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }
}
