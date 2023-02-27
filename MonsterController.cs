using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MonsterController : MonoBehaviour
{
    public float sightRange = 10f;
    public float attackRange = 2f;
    public float attackCooldown = 2f;
    public int attackDamage = 10;
    public float movementSpeed = 5f;

    private Transform target;
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    private float attackTimer = 0f;

    private static readonly int AttackAnimationHash = Animator.StringToHash("Attack");

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        navMeshAgent.speed = movementSpeed;
    }

    private void Update()
    {
        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        if (distanceToTarget <= sightRange)
        {
            navMeshAgent.SetDestination(target.position);

            if (distanceToTarget <= attackRange)
            {
                if (attackTimer <= 0f)
                {
                    Attack();
                    attackTimer = attackCooldown;
                }
            }
            else
            {
                StopAttack();
            }
        }
        else
        {
            StopAttack();
            navMeshAgent.SetDestination(transform.position);
        }

        attackTimer -= Time.deltaTime;
    }

    private void Attack()
    {
        animator.SetTrigger(AttackAnimationHash);

        if (target != null)
        {
            PlayerHealth playerHealth = target.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(attackDamage);
            }
        }
    }

    private void StopAttack()
    {
        animator.ResetTrigger(AttackAnimationHash);
    }
}