
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public float m_moveSpeed;
    public int m_HP;
    public float jumpForce ;
    [SerializeField] private bool isJumping;
    [SerializeField] private bool isGrounded;
    public Transform groundCheckLeft;
    public Transform groundCheckRight;


    public void Update()
    {
            isGrounded = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }
        if (isJumping == true)
        {
            rigibody.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }

    }

    public override void OnDie()
    {
        animator.Play("Death");

    }
    public override void OnHit()
    {
        animator.Play("Hit");
        RemoveHP(1);

    }
    public void TryToRecognizeAttack()
    {

    }
    public void AddHP(int HP)
    {
        m_HP += HP;
    }
    public void RemoveHP(int HP)
    {
        m_HP -= HP;
    }
}