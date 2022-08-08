// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class GuardBehavior : MonoBehaviour
// {
//     private Animator animator;

//     //proximity triggers
//     private Transform playerHead;
//     private Transform playerTorso;
//     private Transform playerLeftArm;
//     private Transform playerLeftHand;
//     private Transform playerLeftLeg;
//     private Transform playerRightArm;
//     private Transform playerRightHand;
//     private Transform playerRightLeg;

//     private float health = 1f;

//     private float kickDist = 1.3f;
//     private float punchDist = 1.7f;
//     private float headbuttDist = 1.8f;
//     public bool hasAddedMove = false;

//     private List<string> attacks = new List<string>(5);
//     private List<string> blocks = new List<string>(5);

//     void Start()
//     {
//         animator = GetComponent<Animator>();
//         playerHead = GameObject.FindWithTag("Player_Head").transform;
//         playerTorso = GameObject.FindWithTag("Player_Torso").transform;
//         playerLeftArm = GameObject.FindWithTag("Player_Left_Arm").transform;
//         playerLeftHand = GameObject.FindWithTag("Player_Left_Hand").transform;
//         playerLeftLeg = GameObject.FindWithTag("Player_Left_Leg").transform;
//         playerRightArm = GameObject.FindWithTag("Player_Right_Arm").transform;
//         playerRightHand = GameObject.FindWithTag("Player_Right_Hand").transform;
//         playerRightLeg = GameObject.FindWithTag("Player_Right_Leg").transform;

//         attacks.Add("Headbutt");
//         attacks.Add("PunchElbow");
//         attacks.Add("PunchHook");
//         attacks.Add("PunchRight");
//         attacks.Add("Kick");

//         blocks.Add("Duck");
//         blocks.Add("BlockRight");
//         blocks.Add("BlockLeft");
//     }

//     void Update()
//     {
//         bool isMakingMove = false;
//         for (int i = 0; i < attacks.Count; i++) {
//             if (animator.GetCurrentAnimatorStateInfo(0).IsName(attacks[i])) {
//                 //isMakingMove is false for multiple frames, letting the code add multiple attacks to the queue
//                 isMakingMove = true;
//                 hasAddedMove = false;
//                 //hasAddedMove basically ensures a trigger is set ONCE after each attack animation
//             }
//         } 
//         for (int i = 0; i < blocks.Count; i++) {
//             if (animator.GetCurrentAnimatorStateInfo(0).IsName(blocks[i])) {
//                 //isMakingMove is false for multiple frames, letting the code add multiple attacks to the queue
//                 isMakingMove = true;
//                 hasAddedMove = false;
//                 //hasAddedMove basically ensures a trigger is set ONCE after each attack animation
//             }
//         }
//         for (int i = 0; i < blocks.Count; i++) {
//             if (animator.GetCurrentAnimatorStateInfo(0).IsName(blocks[i])) {
//                 isMakingMove = true;
//                 hasAddedMove = false;
//             }
//         }
//         if (isMakingMove == false) {
//             //the isMakingMove thing is to make sure the AI "updates" faster-- otherwise it will continue to attack even if
//             // the player is away from its target zone (or not use attacks that have a smaller proximity range)
//             List<string> possibleMoves = new List<string>();

//             if (Vector3.Distance(transform.position, playerTorso.position) <= headbuttDist) {
//                 possibleMoves.Add(attacks[0]);
//                 possibleMoves.Add(attacks[1]);    
//                 if (Vector3.Distance(transform.position, playerTorso.position) <= punchDist) {
//                     possibleMoves.Add(attacks[2]);
//                     possibleMoves.Add(attacks[3]);  
//                     if (Vector3.Distance(transform.position, playerTorso.position) <= kickDist) {
//                         possibleMoves.Add(attacks[4]);
//                     }
//                 }
//             }
//             if (possibleMoves.Count > 0 && !hasAddedMove) {
//                 animator.SetTrigger(possibleMoves[Random.Range(0, possibleMoves.Count)]);
//                 hasAddedMove = true;
//             }
//         }
//         //possibility to add enemy movement down here
//     }

//     void OnTriggerEnter(Collider other)
//     {
//         Debug.Log(other.gameObject.name);
//         if (other.gameObject.name == "Guard_Player") {
//             if (!hasAddedMove) {
//                 animator.SetTrigger(blocks[Random.Range(0, blocks.Count)]);
//                 hasAddedMove = true;
//             }
//         }
//     }
// }
