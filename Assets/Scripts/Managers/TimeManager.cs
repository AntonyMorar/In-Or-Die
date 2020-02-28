using UnityEngine;

public class TimeManager : MonoBehaviour
{
    // Start thr Singleton
    public static TimeManager instance;

    private void Awake()
    {
        MakeSingleton();
    }

    private void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    // End of thr Singleton

    public float playerMaxSlowTime { get; private set; }
    public float playerSlowTime { get; private set; }
    public bool isTimesUp { get; private set; }

    [Header("Slow Down")]
    [SerializeField] private float slowDownFactor = 0.01f;
    [SerializeField] private bool isSlowMotion;

    private void Start()
    {
        playerMaxSlowTime = 5f;
        playerSlowTime = playerMaxSlowTime;
    }

    private void Update()
    {
        if (isSlowMotion)
        {
            if (playerSlowTime <= 0)
            {
                isTimesUp = true;
            }
            playerSlowTime -= Time.unscaledDeltaTime;
        }
    }

    public void SlowMotion(bool doSlow=true)
    {
        if (doSlow)
        {
            Time.timeScale = slowDownFactor;
            isSlowMotion = true;
        }
        else
        {
            Time.timeScale = 1;
            isSlowMotion = false;
        }

        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }

    public void ResetPlayerTimeStatus()
    {
        playerSlowTime = playerMaxSlowTime;
        isTimesUp = false;
    }

    public void AddSlowTime(float _time)
    {
        playerSlowTime += _time;
        playerSlowTime = Mathf.Clamp(playerSlowTime, 0f, playerMaxSlowTime);
    }
}
