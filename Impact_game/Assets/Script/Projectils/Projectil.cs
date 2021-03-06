using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class Projectil : Entity
{
    [SerializeField] private int m_difficulty;
    [SerializeField] private TextMesh textMeshToShow;
    [SerializeField] private int currentIndex = 0;
    [SerializeField] private float speed;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] public List<ButtonControl> inputsToDo;
    [SerializeField] public ProjectilType projectilType;

    private Player player;
    private GameObject attackIndicator;

    public void Start()
    {
        player = FindObjectOfType<Player>();
        attackIndicator = GameObject.Find("AttackIndicator");
        inputsToDo = new List<ButtonControl>();

        ButtonControl[] availableInput = GameController.GetAuthorizedCodes();
        //Depend of projectil's difficulty, allow to use all possible input or not
        int maxDifferentInputType = (int)(m_difficulty < 4 ? availableInput.Length - 1 : System.Math.Floor(availableInput.Length / 2d));

        for(int i=0; i<m_difficulty; i++)
        {
            ButtonControl newKey = availableInput[Random.Range(0, maxDifferentInputType)]; 
            while(i > 0 && newKey == inputsToDo[i-1])
                newKey = availableInput[Random.Range(0, maxDifferentInputType)]; 
            inputsToDo.Add(newKey);
        }
        ChangeInputToShow();
    }

    public void Update()
    {
        Move();
        if(IsDrestroyable())
        {
            CheckInput();
        }
    }

    private bool IsDrestroyable()
    {
        return transform.position.x <= attackIndicator.transform.position.x;
      
    }

    public override void OnDie()
    {
        animator.Play("Death");
        Destroy(this.gameObject);
    }

    public override void OnHit()
    {
        OnDie();
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {

        Player player = collider.GetComponent<Player>();

        if (player != null)
        {
            player.OnHit();
            OnHit();
        }
    }
    private void CheckInput()
    {
        if (inputsToDo[currentIndex].wasPressedThisFrame)
        {
            currentIndex++;
            if (currentIndex == inputsToDo.Count)
            {
                player.animator.Play("Slash");
                OnDie();
                return;
            }
            ChangeInputToShow();
        }
        else if (GameController.GetKeyboard().anyKey.wasPressedThisFrame)
        {
            currentIndex = 0;
            ChangeInputToShow();
        }
    }
    private void ChangeInputToShow()
    {
        textMeshToShow.text = Utils.QwertyToAzerty(inputsToDo[currentIndex].name.ToUpper());
    }

    private void Move()
    {
        rigibody.velocity = new Vector3(-speed, 0, 0);
    }
}
