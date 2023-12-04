using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectFruitQuest : QuestStep
{
    private int fruitCollected = 0;
    private int fruitToComplete = 3;

    private void OnEnable()
    {
        GameEventsManager.instance.miscEvents.onFruitCollected += FruitCollected;
    }

    private void OnDisable()
    {
        GameEventsManager.instance.miscEvents.onFruitCollected -= FruitCollected;
    }

    private void FruitCollected()
    {
        if (fruitCollected < fruitToComplete)
        {
            fruitCollected++;
        }

        if (fruitCollected >= fruitToComplete)
        {
            FinishQuestStep();
        }
    }
}
