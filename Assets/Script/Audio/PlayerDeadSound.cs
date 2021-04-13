using UnityEngine;
using UnityEngine.Audio;

public class PlayerDeadSound : MonoBehaviour
{
    [SerializeField]
    private AudioMixerSnapshot _normalGame;
    [SerializeField]
    private AudioMixerSnapshot _deadGame;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _normalGame.TransitionTo(0.01f);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            _deadGame.TransitionTo(0.01f);
        }
    }
}
