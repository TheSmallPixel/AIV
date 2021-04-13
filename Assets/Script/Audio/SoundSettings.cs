using UnityEngine;
using UnityEngine.Audio;

public class SoundSettings : MonoBehaviour
{
    public static SoundSettings Singleton;

    [SerializeField]
    private AudioMixer _masterAudioMixer;

    [SerializeField]
    public SoundSettingsData SettingsData;

    void Awake()
    {
        if (Singleton == null)
        {
            DontDestroyOnLoad(this);
            Singleton = this;
            UpdateMix();
        }
        else
        {
            Destroy(this);
        }
    }

    public void Set(string key, float value)
    {
        if (SettingsData.SoundTable.ContainsKey(key))
        {
            SettingsData.SoundTable[key] = value;
            UpdateMix();
        }

    }

    private void UpdateMix()
    {
        foreach (var val in SettingsData.SoundTable)
        {
            _masterAudioMixer.SetFloat(val.Key, Mathf.Log(val.Value) * 20);
        }
    }

}
