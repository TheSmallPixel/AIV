using System.Collections;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Animation))]
public class Jump : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator ani;
    private Animation animation;
    bool jump = true;
    bool doubleJump = true;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        animation = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("up") || Input.GetKeyDown("space"))
        {
            JumpIfPossible();
        }
    }

    private void JumpAction()
    {
        print("JUMP!");
        rb.AddForce(transform.up * 400f);
        ani.SetTrigger("jump");

    }
    private void JumpIfPossible()
    {
        if (jump)
        {

            jump = false;
            resetJump();
            JumpAction();
        }
        else if (doubleJump)

        {


            doubleJump = false;
            resetDoubleJump();
            JumpAction();

        }
    }
    bool AnimatorIsPlaying()
    {
        return ani.GetCurrentAnimatorStateInfo(0).length >
               ani.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }

    private IEnumerator resetJ()
    {

        //yield on a new YieldInstruction that waits for 5 seconds.

        yield return new WaitForSecondsRealtime(1.3f);
        jump = true;
    }
    private IEnumerator resetDJ()
    {

        //yield on a new YieldInstruction that waits for 5 seconds.

        yield return new WaitForSecondsRealtime(1.3f);
        doubleJump = true;
    }
    void resetJump()
    {
        Coroutine c = StartCoroutine(resetJ());

    }
    void resetDoubleJump()
    {
        StartCoroutine(resetDJ());

    }
}
