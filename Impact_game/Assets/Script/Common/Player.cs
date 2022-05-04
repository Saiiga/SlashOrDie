
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
    [SerializeField] private SpriteRenderer shieldRenderer;

    public SpriteRenderer ShieldRenderer { get => shieldRenderer; set => shieldRenderer = value; }

    public void Update()
    {
            isGrounded = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position);
        if (GameController.GetKeyboard().spaceKey.wasPressedThisFrame && isGrounded)
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
        Debug.Log("ded");
    }

    public override void OnHit()
    {
        if(ShieldRenderer.enabled)
        {
            ShieldRenderer.enabled = false;
            Debug.Log("protected");
            return;
        }
        animator.Play("Hit");
        RemoveHP(1);
        Debug.Log("hit, new hp :"+ m_HP);
        
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
        if (HP < 1)  
        {
            OnDie();
        }
    }
} 
