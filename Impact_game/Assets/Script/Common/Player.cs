
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public override void OnDie()
    {
        throw new System.NotImplementedException();
    }

    public override void OnHit()
    {
        throw new System.NotImplementedException();
    }
} /*H�ritage Entity

attributs:
Collider hitbox
Rigibody rigibody
Sprite sprite
Animator animator
List<Bonus> bonus
float moveSpeed

fonction:
Attack TryToRecognizeAttack()
void AddBonus(Bonus)
void RemoveBonus(Bonus)
void OnHit() (ajouter le traitement si touch� par projectile et bonus)*/