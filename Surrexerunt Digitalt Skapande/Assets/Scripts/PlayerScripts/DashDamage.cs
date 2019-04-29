using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashDamage : MonoBehaviour
{
    private PlayerMovement playerMovement;
    [SerializeField] private int dashDmg;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    void DealDamageInDash(Collider2D enemy)
    {
        if (playerMovement.dashState == PlayerMovement.DashState.Dashing && enemy.tag == "Boss")
        {
            enemy.GetComponent<BossManager>().TakeDamage();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DealDamageInDash(collision);
    }
}
