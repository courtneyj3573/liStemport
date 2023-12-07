using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventsManager : MonoBehaviour
{
    public static GameEventsManager instance { get; private set; }

    public InputEvents inputEvents;
    public PlayerEvents playerEvents;
    //public FruitEvents fruitEvents;
    public MiscEvents miscEvents;
    public QuestEvents questEvents;

    private void Awake()
    {
        Debug.Log("GameEventsManager Awake");
        if (instance != null)
        {
            Debug.LogError("Found more than one Game Events Manager in the scene.");
            
        }
        instance = this;

        //initialize all events
        inputEvents = new InputEvents();
        playerEvents = new PlayerEvents();
        //fruitEvents = new FruitEvents();
        miscEvents = new MiscEvents();
        questEvents = new QuestEvents();
    }   
}
