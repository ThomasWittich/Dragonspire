using UnityEngine;

public class MainCharController : MonoBehaviour
{
    private Animator animator;
    private bool isAlive = true;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
    }

    public void Idle()
    {
            animator.SetTrigger("Idle");
    }

    public void Walk()
    {
            animator.SetTrigger("Walk");
    }

    public void Attack()
    {
            animator.SetTrigger("Attack");
    }

    public void WalkBack()
    {
            animator.SetTrigger("WalkBack");
    }

    public void TakeDamage()
    {
            animator.SetTrigger("TakeDamage");
    }

    public void Death()
    {
            animator.SetTrigger("Death");
            isAlive = false;
    }
}
