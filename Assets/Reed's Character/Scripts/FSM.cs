using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM : MonoBehaviour
{
  public enum CharacterState
  {
    Idle, Death, Hit,
    Punch, Slash, Block,
    Strafe, Walk
  }
  public CharacterState currentState;
  public Sight sightSensor;
  public AnimMove mover;

  void Update()
  {
    switch (currentState)
    {
      case CharacterState.Idle:
        Idle();
        break;
      case CharacterState.Death:
        Death();
        break;
      case CharacterState.Slash:
        Slash();
        break;
      case CharacterState.Hit:
        Hit();
        break;
      case CharacterState.Punch:
        Punch();
        break;
      case CharacterState.Block:
        Block();
        break;
      case CharacterState.Strafe:
        Strafe();
        break;
      case CharacterState.Walk:
        Walk();
        break;
    }
  }

  void Idle()
  {
    // Debug.Log("Idle");
  }
  void Death()
  {
    // Debug.Log("Die");
  }
  void Slash()
  {
    // Debug.Log("Slash");
  }
  void Hit()
  {
    // Debug.Log("Hit");
  }
  void Punch()
  {
    // Debug.Log("Punch");
  }
  void Block()
  {
    // Debug.Log("Block");
  }
  void Strafe()
  {
    // Debug.Log("Strafe");
  }
  void Walk()
  {
    // Debug.Log("Walk");
  }
}
