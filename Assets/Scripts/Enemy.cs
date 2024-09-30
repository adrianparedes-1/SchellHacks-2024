using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
using UnityEngine.XR;

public class Enemy : MonoBehaviour
{
    RaycastHit2D detectionRayCastHit;

    RaycastHit2D attackingRayCast;

    Vector2 playerPosition;

    Vector2 randomPosition;

    NavMeshAgent agent;

    [SerializeField] float patrollingRange;

    [SerializeField] float seekingRange;

    [SerializeField] float attackingRange;

    Rigidbody2D rigidBody;

    BoxCollider2D collider;

    [SerializeField]float lungeForce;

    int state = 0;


    // Start is called before the first frame update
    void Start()
    {
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        Rigidbody2D rigidBody = GetComponent<Rigidbody2D>();


        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        // state = 0 is watching
        // state = 1 is seeking
        // state = 2 is attacking
        switch(state){
            case 0:{ // Patrolling
                BasicPlayerDetection();
                break;
            }
            case 1:{ // Move towards Player
                moveTowardsPlayer();
                break;
            }
            case 2:{ // Attack
                attack();
                break;
            }
        }


    }

    void BasicPlayerDetection(){
       
        detectionRayCastHit = Physics2D.CircleCast(new Vector2(transform.position.x , transform.position.y),7f,new Vector2(transform.position.x , transform.position.y));


        Debug.DrawLine(new Vector2(transform.position.x , transform.position.y ),new Vector2(transform.position.x + seekingRange , transform.position.y + 5f),Color.blue);
        if(detectionRayCastHit.collider.name.CompareTo("Player") == 0){
            Debug.Log("PlayerBeingSeeked");
            playerPosition = detectionRayCastHit.collider.transform.position;
            state = 1;
        }
        else{
            state = 0;
        }
        // else{
        //     if(!agent.hasPath){
        //         randomPosition = new Vector2(UnityEngine.Random.Range(transform.position.x - patrollingRange,transform.position.x + patrollingRange),UnityEngine.Random.Range(transform.position.y - patrollingRange,transform.position.y + patrollingRange));
        //         agent.SetDestination(randomPosition);
        //         state = 0;
        //     }
        //     else{
        //         state = 1;
        //     }
        // }
    }

    void moveTowardsPlayer(){
        agent.SetDestination(playerPosition);
        BasicPlayerDetection();
        if(canAttack()){
            Debug.Log("CANATTACK");
            state = 2;
        }
    }

    Boolean canAttack(){
        attackingRayCast = Physics2D.CircleCast(new UnityEngine.Vector2(transform.position.x , transform.position.y),attackingRange,new Vector2(transform.position.x , transform.position.y));
        if(attackingRayCast.collider.name.CompareTo("Player") == 0){
            return true;
        }
        else{
            return false;
        }
        // Can attack
    }
    void attack(){
        // Swing at player
        Debug.Log("attacking");
        state = 1;
    }
}
