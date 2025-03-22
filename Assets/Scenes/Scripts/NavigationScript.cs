using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class NavigationScript : MonoBehaviour
{
    //navigation API 
    
    
    //Features:
    //patrol
    //teleport
    //chase
    //stop to interact

    
    private NavMeshAgent _agent;
    private Transform _target;

    [SerializeField]
    private float speed = 10;
    
    [SerializeField]
    List<Transform> waypoints = new List<Transform>();
    
    
    private void Start()
    {

        _target = PlayerController.Instance.transform;
        
        _agent = GetComponent<NavMeshAgent>();    
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            SetPatrol();
        }
        else if (Input.GetKeyUp(KeyCode.C))
        {
            ChasePlayer();
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            StopMoving();
        }
        _agent.speed = speed;
    }


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
    
    
}
