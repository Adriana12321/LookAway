using System.Collections;
using System.Collections.Generic;
using Scenes.Scripts.Enemy_States;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{ 
    
    public EnemyBaseState currentState;
    
    public ChaseState chaseState = new ChaseState();
    public IddleState iddleState = new IddleState();
    public TeleportState teleportState = new TeleportState();
    public PatrolState patrolState = new PatrolState();


    void Start()
    {
        
        currentState.EnterState(this);
    }


    void Update()
    {
        
    }
}
