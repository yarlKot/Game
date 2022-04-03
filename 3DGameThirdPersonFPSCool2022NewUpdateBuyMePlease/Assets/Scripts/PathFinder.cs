using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathFinder : MonoBehaviour
{
    public Vector3 point;
    public Transform Target;
    public float radius;
    public float speed = 2f;
    private Rigidbody rb;
    NavMeshAgent navMeshAgent;
    private int c = 0;

    void Start()
    {
        navMeshAgent=GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        c++;
        if (c > 10)
        {
            point = Target.position;
            if ((point - transform.position).magnitude > radius)
            {
                navMeshAgent.isStopped = false;
                navMeshAgent.SetDestination(point);
            }
            else
            {
                print("XD");
                navMeshAgent.isStopped = true;
            }
            c=0;
        }
        
    }
}
