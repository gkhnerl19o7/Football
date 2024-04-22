using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiControl : MonoBehaviour
{
    public Transform Ball,Goal,Dribbling;
    public GameObject DribblingGO;
    private NavMeshAgent agent;
    bool BallControl = false; //top ai'de mi ?
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ball")
        {
            BallControl = true;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag=="Ball")
        {
            Ball.transform.position = Dribbling.transform.position; 
            agent.destination = Goal.position;
        }          
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Ball")
        {
            BallControl = false;
        }
    }
    private void Update()
    {
        BallTarget();
    }
    void BallTarget()
    {
        if (BallControl==false)
        {
            agent.destination = Ball.position;
        }
    }
}
