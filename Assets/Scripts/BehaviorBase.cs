using UnityEngine;
using UnityEngine.AI;

public abstract class BehaviorBase : MonoBehaviour
{
    [SerializeField] protected NavMeshAgent agent;

    protected abstract void PerformBehavior();

    protected void Update()
    {
        PerformBehavior();
    }
    
    //Base behavors
    protected void Follow(Vector3 location)
    {
        agent.SetDestination(location);
    }

    protected void Flee(Vector3 location)
    {
        Vector3 fleeVector = location - this.transform.position;
        agent.SetDestination(this.transform.position - fleeVector);
    }

}
