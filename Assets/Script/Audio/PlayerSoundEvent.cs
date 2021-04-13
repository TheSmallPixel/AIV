using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class PlayerSoundEvent : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField]
    private AudioClip[] _audio;
    // Start is called before the first frame update
    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            _audioSource.PlayOneShot(_audio[Random.Range(0, _audio.Length)]);
        }
    }
}
