using System.Collections.Generic;
using Scenes.Scripts.Enemy_States;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{ 
    
    public EnemyBaseState currentState;
    
    public ChaseState chaseState = new ChaseState();
    public IddleState iddleState = new IddleState();
    public TeleportState teleportState = new TeleportState();
    public PatrolState patrolState = new PatrolState();
    
    private NavMeshAgent _agent;
    private Transform _target;

    [SerializeField]
    private float speed = 10;
    
    [SerializeField]
    List<Transform> waypoints = new List<Transform>();
        
    void Start()
    {
        _target = PlayerController.Instance.transform;
        
        _agent = GetComponent<NavMeshAgent>();    
        
        currentState = patrolState;
        currentState.EnterState(this);
    }


    void Update()
    {
        currentState.UpdateState(this);
        
    }

   public Transform GetPlayerTransform() => PlayerController.Instance.transform;


   #region Navigation
   public void ChasePlayer()
   {
       speed = 20;
       _agent.destination = _target.position;
   }


   public void StopMoving()
   {
       speed = 0;
       _agent.speed = 0f;
   }
   public void SetPatrol()
   {
       if(waypoints.Count > 0)
       {
           speed = 10;
           int point = Random.Range(0, waypoints.Count);
           _agent.SetDestination(waypoints[point].position);
       }
       else
       {
           Debug.Log("No waypoints in list!");
       }
   }
   
   
   
   
   
   #endregion
}
