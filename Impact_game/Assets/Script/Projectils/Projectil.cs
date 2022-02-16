


class Projectil : Entity
{
    ProjectileType type;

    private void OnTriggerEnter2D(Collider2D other) {

    }
}


/*Héritage d'Entity

attribut:
ProjectileType type

fonction:
(surcharger OnHit)
OnContact(Object) (si assez proche et/ou toucher par l'arme)*/