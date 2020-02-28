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

    [Header("Player Params")]
    const float playerMaxSlowTime = 5f;
    public float playerSlowTime { get; private set; }
    public bool isTimesUp { get; private set; }

    [Header("Slow Down")]
    [SerializeField] private float slowDownFactor = 0.01f;
    [SerializeField] private bool isSlowMotion;

    private void Start()
    {
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
}
