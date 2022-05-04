using System.Collections;
using UnityEngine;

namespace Assets.Script.Common.PowerObjects
{
    public class ItemBox : PowerObject
    {

        [SerializeField] private PowerObject[] availableItems;

        public override void OnHit()
        {
        }

        protected override void Action(Player player)
        {
            Instantiate(availableItems[Random.Range(0, availableItems.Length)],transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }

    }
}