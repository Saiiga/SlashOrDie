using System.Collections;
using UnityEngine;

namespace Assets.Script.Common.PowerObjects
{
    public class Shield : PowerObject
    {
        public override void OnHit()
        {
        }

        protected override void Action(Player player)
        {
            if(player != null)
            {
                StartCoroutine(ShieldLifeTimeCoroutine(player));
            }
        }

        IEnumerator ShieldLifeTimeCoroutine(Player player)
        {
            player.ShieldRenderer.enabled = true;
            yield return new WaitForSeconds(bonusTime);
            player.ShieldRenderer.enabled = false;
            Destroy(this.gameObject);
        }
    }
}