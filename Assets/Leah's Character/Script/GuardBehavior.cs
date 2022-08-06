using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardBehavior : MonoBehaviour
{
    private Animator animator;

    //proximity triggers
    private Transform playerHead;
    private Transform playerTorso;
    private Transform playerLeftArm;
    private Transform playerLeftHand;
    private Transform playerLeftLeg;
    private Transform playerRightArm;
    private Transform playerRightHand;
    private Transform playerRightLeg;

    private float health = 1f;

    private float kickDist = 1.3f;
    private float punchDist = 1.7f;
    private float headbuttDist = 1.8f;
    public bool hasAddedMoves = false;

    private List<string> moves = new List<string>(5);
    void Start()
    {
        animator = GetComponent<Animator>();
        playerHead = GameObject.FindWithTag("Player_Head").transform;
        playerTorso = GameObject.FindWithTag("Player_Torso").transform;
        playerLeftArm = GameObject.FindWithTag("Player_Left_Arm").transform;
        playerLeftHand = GameObject.FindWithTag("Player_Left_Hand").transform;
        playerLeftLeg = GameObject.FindWithTag("Player_Left_Leg").transform;
        playerRightArm = GameObject.FindWithTag("Player_Right_Arm").transform;
        playerRightHand = GameObject.FindWithTag("Player_Right_Hand").transform;
        playerRightLeg = GameObject.FindWithTag("Player_Right_Leg").transform;

        moves.Add("Headbutt");
        moves.Add("PunchElbow");
        moves.Add("PunchHook");
        moves.Add("PunchRight");
        moves.Add("Kick");
    }

    void Update()
    {
        bool isAttacking = false;
        for (int i = 0; i < moves.Count; i++) {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName(moves[i])) {
                //isAttacking is false for multiple frames, letting the code add multiple attacks to the queue
                isAttacking = true;
                hasAddedMoves = false;
                //hasAddedMoves basically ensures a trigger is set ONCE after each attack animation
            }
        }
        if (isAttacking == false) {
            //the isAttacking thing is to make sure the AI "updates" faster-- otherwise it will continue to attack even if
            // the player is away from its target zone (or not use attacks that have a smaller proximity range)
            List<string> possibleMoves = new List<string>();

            if (Vector3.Distance(transform.position, playerTorso.position) <= headbuttDist) {
                possibleMoves.Add(moves[0]);
                possibleMoves.Add(moves[1]);    
                if (Vector3.Distance(transform.position, playerTorso.position) <= punchDist) {
                    possibleMoves.Add(moves[2]);
                    possibleMoves.Add(moves[3]);  
                    if (Vector3.Distance(transform.position, playerTorso.position) <= kickDist) {
                        possibleMoves.Add(moves[4]);
                    }
                }
            }
            if (possibleMoves.Count > 0 && !hasAddedMoves) {
                animator.SetTrigger(possibleMoves[Random.Range(0, possibleMoves.Count)]);
                hasAddedMoves = true;
            }
        }
        //possibility to add enemy movement down here
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Guard_Player (Test)") {
            //todo
        }
    }
}
