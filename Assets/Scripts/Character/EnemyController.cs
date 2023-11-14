using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
    private Animator animator;
    private bool isAlive = true;
    public float walkSpeed = 3.0f;

    private bool isWalking = false;
    private bool isAttacking = false;
    private bool isWalkingBack = false;
    private bool isTakingDamage = false;

    public GameObject EnemyAttack;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Walk()
    {
        animator.SetBool("Walk", isWalking);
        if (isWalking){
            transform.Translate(Vector3.forward * walkSpeed * Time.deltaTime);
        }
    }

    private void Attack()
    {
        animator.SetBool("Attack", true);
    }

    private void WalkBack()
    {
        animator.SetBool("WalkBack", true);
    }

    public void TakeDamage()
    {
        animator.SetBool("TakeDamage", true);
    }

    public void Death()
    {
        animator.SetBool("Death", true);
    }
}
