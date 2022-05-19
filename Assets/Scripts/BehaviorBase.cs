using UnityEngine;
using UnityEngine.AI;

public abstract class BehaviorBase : MonoBehaviour
{
    [SerializeField] protected NavMeshAgent agent;
    [SerializeField] protected BehaviourTree behavior;

    protected virtual void Start()
    {
        //subscribe to pause and unpause events to disable behavior when paused
        EventManager.Instance.Subscribe(EventTypes.Events.GAME_PAUSE, PauseBehavior);
        EventManager.Instance.Subscribe(EventTypes.Events.GAME_UNPAUSE, ResumeBehavior);
    }

    protected abstract void PerformBehavior();

    protected void Update()
    {
        // behavior.Process();
        PerformBehavior();
    }

    public void PauseBehavior()
    {
        this.enabled = false;
    }

    public void ResumeBehavior()
    {
        this.enabled = true;
    }

    private void OnDestroy()
    {
        EventManager.Instance.Unsubscribe(EventTypes.Events.GAME_PAUSE, PauseBehavior);
        EventManager.Instance.Unsubscribe(EventTypes.Events.GAME_UNPAUSE, ResumeBehavior);
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
