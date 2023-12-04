using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Movement 
    public float moveSpeed;
    private bool isMoving;
    private Vector2 input; //vector2 is built into unity for 2d movement

    //Animation
    private Animator animator;

    //Collision
    public LayerMask solidObjectsLayer;
    
    //interactables
    public LayerMask interactableLayer;    
    
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void HandleUpdate() 
    {
        if (!isMoving)
        {
            //movement
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");
            //proves movement in console
            Debug.Log("This is input.x" + input.x);
            Debug.Log("This is input.y" + input.y);

            if (input.x != 0) input.y = 0; //prevents diagonal movement

            if (input != Vector2.zero)
            {
                //animation
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);
                //movement
                var targetPosition = transform.position;
                targetPosition.x += input.x;
                targetPosition.y += input.y;

                if (IsWalkable(targetPosition))
                    StartCoroutine(Move(targetPosition));
            }

        }

        animator.SetBool("isMoving", isMoving);
        //interaction key
        if (Input.GetKeyDown(KeyCode.E))
            Interact();

    }

    //interaction with objects
    void Interact()
    {
        var facingDirection = new Vector3(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
        var interactPosition = transform.position + facingDirection;

        //draws a line from player position to interacting position
        //Debug.DrawLine(transform.position, interactPosition, Color.red, 1f);

        var collider = Physics2D.OverlapCircle(interactPosition, 0.01f, interactableLayer);
        if (collider != null)
        {
            collider.GetComponent<Interactable>()?.Interact();
        }
    }

    IEnumerator Move(Vector3 targetPosition)
    {
        isMoving = true;

        while ((targetPosition - transform.position).sqrMagnitude > Mathf.Epsilon) //any movement bigger than 0 mean the user is moving 
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPosition;

        isMoving = false;
    }

    private bool IsWalkable(Vector3 targetPosition)
    {
        //stops walking when near solid objects and interactables
        if(Physics2D.OverlapCircle(targetPosition, 0.01f, solidObjectsLayer | interactableLayer) != null)
        {
            return false;
        }
        return true;
    }

}
