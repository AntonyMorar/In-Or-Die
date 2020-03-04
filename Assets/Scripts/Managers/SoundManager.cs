using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;

    [Range(0, 1)] public float volume = 0.7f;
    [SerializeField][Range(-3, 3)] private float pitch = 1f;
    public bool loop;

    private AudioSource source;

    public void SetSource(AudioSource _source)
    {
        source = _source;
        source.clip = clip;
    }

    public void Play()
    {
        source.volume = volume;
        source.pitch = pitch;
        source.loop = loop;
        source.Play();
    }

    public void Stop()
    {
        source.Stop();
    }

    public void ChangePitch(float level)
    {
        source.pitch = level;
    }
}

public class SoundManager : MonoBehaviour
{
    // Start Singleton
    public static SoundManager instance;

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
    // End Singleton
    [SerializeField] Sound[] sounds;

    private void Start()
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            GameObject _go = new GameObject("Sound" + sounds[i].name);
            _go.transform.SetParent(transform);
            sounds[i].SetSource(_go.AddComponent<AudioSource>());
        }
    }

    public void PlaySound(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == _name)
            {
                sounds[i].Play();
                return;
            }
        }

        //No sound with name
        Debug.LogError("SoundManager: No sound with name " + _name);
    }

    public void PauseSound(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == _name)
            {
                sounds[i].Stop();
                return;
            }
        }

        //No sound with name
        Debug.LogError("SoundManager: No sound with name " + _name);
    }

    public void ChangePitch(string _name, float level)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == _name)
            {
                sounds[i].ChangePitch(level);
                return;
            }
        }
        //No sound with name
        Debug.LogError("SoundManager: No sound with name " + _name);
    }
}
