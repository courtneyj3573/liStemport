using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class CatchFishQuestStep : QuestStep
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.CompareTag("Player"))
        {
            FinishQuestStep();
        }
    }
    //protected override void SetQuestStepState(string state)
    //{
        //no statee is needed for this quest step
        //throw new System.NotImplementedException();
    //}
}