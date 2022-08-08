using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimMove : MonoBehaviour
{
  Animator anim;
  public FSM fsm;
  void Start()
  {
    anim = GetComponent<Animator>();
  }
  void Update()
  {
    switch (fsm.currentState)
    {
      case FSM.CharacterState.Idle:
        break;
      case FSM.CharacterState.Death:
        anim.SetBool("isDying", true);
        break;
      case FSM.CharacterState.Slash:
        anim.SetBool("isSlashing", true);
        break;
      case FSM.CharacterState.Hit:
        anim.SetBool("isHit", true);
        break;
      case FSM.CharacterState.Punch:
        anim.SetBool("isPunching", true);
        break;
      case FSM.CharacterState.Block:
        anim.SetBool("isBlocking", true);
        break;
      case FSM.CharacterState.Strafe:
        anim.SetBool("isStrafing", true);
        break;
      case FSM.CharacterState.Walk:
        anim.SetBool("isWalking", true);
        break;
    }
  }
}
