/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Fruit : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private float respawnTimeSeconds = 8;
    [SerializeField] private int fruitGained = 1;

    private CircleCollider2D circleCollider;
    private SpriteRenderer visual;

    private void Awake() 
    {
        circleCollider = GetComponent<CircleCollider2D>();
        visual = GetComponentInChildren<SpriteRenderer>();
    }

    private void CollectFruit() 
    {
        circleCollider.enabled = false;
        visual.gameObject.SetActive(false);
        GameEventsManager.instance.fruitEvents.FruitGained(fruitGained);
        GameEventsManager.instance.miscEvents.FruitCollected();
        StopAllCoroutines();
        StartCoroutine(RespawnAfterTime());
    }

    private IEnumerator RespawnAfterTime()
    {
        yield return new WaitForSeconds(respawnTimeSeconds);
        circleCollider.enabled = true;
        visual.gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider) 
    {
        if (otherCollider.CompareTag("Player"))
        {
            CollectFruit();
        }
    }
}
*/