using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
     public float look_radius=10f;

    private float timer;
    public float wanderTimer=2f;
    bool isPatrolling = true;
    Transform target;
    NavMeshAgent agent;
    CharacterCombat combat;

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        combat = GetComponent<CharacterCombat>();
        timer = wanderTimer;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        timer += Time.deltaTime;

        if (timer >= wanderTimer&&isPatrolling)
        {
            Vector3 newPos = RandomNavSphere(transform.position, look_radius, -1);
            agent.SetDestination(newPos);
            timer = 0;
        }
        if (distance <= look_radius)
        {
            isPatrolling = false;
            agent.SetDestination(target.position);

            if (distance <= agent.stoppingDistance)
            {
                ChatacterStats targetStats=target.GetComponent<ChatacterStats>();
                //attack player

                if(targetStats!=null)
                {
                    combat.Attack(targetStats);
                    Animator anim = GetComponentInChildren<Animator>();
                    float rand = Random.Range(0, 1);
                    anim.SetFloat("Attack",rand);

                }

                FaceTarget();

            }
        }

      
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation,Time.deltaTime*2f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, look_radius);
    }
}
