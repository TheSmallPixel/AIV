using Assets.Script;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Velocity;
    private Effect _currentEffect;
    private Rigidbody2D _rigidbody2D;
    private float _timer;
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

    }
    void Update()
    {

        float moveH = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        gameObject.transform.Translate(moveH * Velocity * Time.deltaTime, moveY * Velocity * Time.deltaTime, 0);


        if (_timer < Time.time)
        {
            _currentEffect?.RemoveEffect(this);

            _currentEffect = null;
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        var effect = collision.gameObject.GetComponent<GameObjectEffector>()?.Effect;

        if (effect != null)
        {
            _currentEffect?.RemoveEffect(this);
            LevelLoader.Singleton.Respawn(collision.gameObject);
            _currentEffect = effect;
            _timer = effect.Duration + Time.time;
            _currentEffect.AddEffect(this);


        }
    }

}
