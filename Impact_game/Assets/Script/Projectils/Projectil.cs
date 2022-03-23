using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class Projectil : Entity
{
    [SerializeField] private int m_difficulty;
    [SerializeField] private TextMesh textMeshToShow;
    [SerializeField] private int currentIndex = 0;

    [SerializeField] public List<ButtonControl> inputsToDo;
    [SerializeField] public ProjectilType projectilType;

    public void Start()
    {
        inputsToDo = new List<ButtonControl>();

        ButtonControl[] availableInput = GameController.GetAuthorizedCodes();
        //Depend of projectil's difficulty, allow to use all possible input or not
        int maxDifferentInputType = (int)(m_difficulty > 4 ? availableInput.Length - 1 : System.Math.Ceiling(availableInput.Length / 2d));

        for(int i=0; i<m_difficulty; i++)
        {
            inputsToDo.Add(availableInput[Random.Range(0, maxDifferentInputType)]);
        }
        ChangeInputToShow();
    }

    public void Update()
    {
        if(IsDrestroyable())
        {
            CheckInput();
        }
    }

    public bool IsDrestroyable()
    {
        return transform.position.x <= GameController.pointAttackAvailable.x;
      
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

}
