using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class PlayerAnimationSettter : MonoBehaviour
{
    public Animator animator;
    public AILerp AILerp;
    public bool isFacingRight;
    public float turnAroundSpeed;
    public GameObject shadow;
    void Update()
    {
        animator.SetFloat("PlayerVelocity", AILerp.velocity.magnitude);
        TurnAround(isFacingRight);
        if (AILerp.velocity.x > 0.1f)
            isFacingRight = true;
        if (AILerp.velocity.x < 0.1f)
            isFacingRight = false;
    }
    void TurnAround(bool facingRight)
    {
        if (facingRight && transform.localEulerAngles.y <= 150)
        {
            transform.RotateAround(transform.position, transform.up, +turnAroundSpeed * Time.deltaTime);
            shadow.transform.localScale -= new Vector3 (turnAroundSpeed * Time.deltaTime / 90, 0, 0);
        }
        else if (facingRight)
        {
            transform.localEulerAngles = new Vector3(0, 180, 0);
            shadow.transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (!facingRight && transform.localEulerAngles.y >= 30)
        {
            transform.RotateAround(transform.position, transform.up, +turnAroundSpeed * Time.deltaTime);
            shadow.transform.localScale += new Vector3(turnAroundSpeed * Time.deltaTime / 90, 0, 0);
        }
        else if (!facingRight)
        {
            transform.localEulerAngles = new Vector3(0, 0, 0);
            shadow.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
