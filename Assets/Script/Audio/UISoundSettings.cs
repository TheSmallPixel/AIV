using UnityEngine;
using UnityEngine.UI;

public class UISoundSettings : MonoBehaviour
{
    [SerializeField]
    private GameObject _preafSlider;

    private SoundSettings _soundSettings;

    void Start()
    {
        _soundSettings = SoundSettings.Singleton;

        foreach (var key in _soundSettings.SettingsData.SoundTable.Keys)
        {
            var sliderGM = Instantiate(_preafSlider, transform);
            var slider = sliderGM.GetComponent<Slider>();
            slider.value = _soundSettings.SettingsData.SoundTable[key];
            slider.onValueChanged.AddListener((x) =>
            {
                _soundSettings.Set(key, x);
            });
        }
    }
}
