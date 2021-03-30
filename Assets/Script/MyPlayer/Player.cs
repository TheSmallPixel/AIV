using UnityEngine;

public class Player : MonoBehaviour
{

    Vector3 characterScale;
    float characterScaleX;

    public Animator anim;

    void Start()
    {
        characterScale = transform.localScale;
        characterScaleX = characterScale.x;
        this.anim = this.gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        //Move the Character:
        transform.Translate(Input.GetAxis("Horizontal") * 20f * Time.deltaTime, 0f, 0f);
        bool moving = false;
        //Flip the Character
        if (Input.GetAxis("Horizontal") < 0)
        {
            characterScale.x = -characterScaleX;
            moving = true;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            characterScale.x = characterScaleX;
            moving = true;
        }
        anim.SetBool("isRunning", moving);
        transform.localScale = characterScale;
    }
}
