
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Entity
{
    public float m_moveSpeed;
    public int m_HP;
    public float jumpForce ;
    [SerializeField] private bool isJumping;
    [SerializeField] private bool isGrounded;
    public Transform groundCheckLeft;
    public Transform groundCheckRight;
    [SerializeField] Image[] LifeContainers;


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
       // LifeContainers[m_HP].sprite = Resources.Load<Sprite>("\Impact_game\Assets\Sprite")
        m_HP -= HP;
        
       // for(int i = LifeContainers.Length - 1; i >= 0 ; i--)
       // {
           // if (LifeContainers[i].active)
       // }
        if (HP < 1)  
        {
            OnDie();
        }
    }
    public void Start()
    {
        LifeContainers = GameObject.Find("LifeContainer").GetComponents<Image>();

    }
} 
