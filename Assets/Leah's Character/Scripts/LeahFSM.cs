using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeahFSM: MonoBehaviour
{
    public enum CharacterState 
    {
        Idle, AdvanceTowardOpponent, RetreatFromOpponent, 
        PunchLeft,
        PunchRight,
        DefendLeftMiddle,
        DefendRightMiddle,
        KickMiddle, KickHigh
    }
    public CharacterState currentState;
    public Sight sightSensor;
    private Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (sightSensor.detectedObject != null) {
            Debug.Log(sightSensor.detectedObject.gameObject);
            if (sightSensor.detectedObject.gameObject.CompareTag("Player_Left_Hand")) {
                currentState = CharacterState.DefendLeftMiddle;
            }
        }
        switch (currentState) {
            case CharacterState.Idle:
                Idle();
                break;
            case CharacterState.AdvanceTowardOpponent:
                AdvanceTowardOpponent();
                break;
            case CharacterState.RetreatFromOpponent:
                RetreatFromOpponent();
                break;
            case CharacterState.PunchLeft:
                PunchLeft();
                break;
            case CharacterState.PunchRight:
                PunchRight();
                break;
            case CharacterState.DefendLeftMiddle:
                DefendLeftMiddle();
                break;
            case CharacterState.DefendRightMiddle:
                DefendRightMiddle();
                break;
            case CharacterState.KickMiddle:
                KickMiddle();
                break;
            case CharacterState.KickHigh:
                KickHigh();
                break;
        }
    }

    void Idle() {
        print("Idle");
    }

    void AdvanceTowardOpponent() {
        print("AdvanceTowardOpponent");
    }

    void RetreatFromOpponent() {
        print("RetreatFromOpponent");
    }

    void PunchRight() {
        print("PunchRight");
    }

    void PunchLeft() {
        print("PunchLeft");
    }

    void DefendLeftMiddle() {
        print("DefendLeftMiddle");
        animator.SetTrigger("BlockLeft");
    }

    void DefendRightMiddle() {
        print("DefendRightMiddle");
        animator.SetTrigger("BlockRight");
    }

    void KickMiddle() {
        print("KickMiddle");
    }

    void KickHigh() {
        print("KickHigh");
    }
}
