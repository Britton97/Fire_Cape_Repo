using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Tail")]
    [SerializeField] private TailManager tailManager;
    [SerializeField] public List<Tail> tailList = new List<Tail>();
    [Header("Movement")]
    public float waitPeriod = 1f;
    private float time = 0.0f;

    // Update is called once per frame
    void Update()
    {        
        time += Time.deltaTime;
        if (time >= waitPeriod)
        {
            Movement();
        }
    }

    //Uses Input.GetAxisRaw() to determine what direction to move.
    //Will make a vector3 that will test if the move position is viable
    //Then will call TestIfWalkable passing in the test move and raycast at the test move position
    //if it return true then it will move the player to that position
    private void Movement()
    {
        if(Input.GetAxisRaw("Vertical") != 0)
        {
            Vector3 orginal = transform.position;
            float verticalMovement = Input.GetAxisRaw("Vertical");
            Vector3 tryMove = new Vector3(transform.position.x, transform.position.y + verticalMovement, transform.position.z);
            RaycastHit2D hit = Physics2D.Raycast(tryMove, -Vector3.forward);
            if (TestIfWalkable(tryMove, hit))
            {
                transform.position = tryMove;
                tailManager.PlayerChangedPosition(new Vector3(0, -verticalMovement, 0));
                time = 0.0f;
            }
        }
        else if (Input.GetAxisRaw("Horizontal") != 0)
        {
            Vector3 original = transform.position;
            float horizontalMovement = Input.GetAxisRaw("Horizontal");
            Vector3 tryMove = new Vector3(transform.position.x + horizontalMovement, transform.position.y, transform.position.z);
            RaycastHit2D hit = Physics2D.Raycast(tryMove, -Vector3.forward);
            if (TestIfWalkable(tryMove, hit))
            {
                transform.position = tryMove;
                tailManager.PlayerChangedPosition(new Vector3(-horizontalMovement,0,0));
                time = 0.0f;
            }
        }
    }

    private bool TestIfWalkable(Vector3 tryMove, RaycastHit2D hit)
    {
        if (hit && hit.transform.name == "Ground_Map" && !hit.transform.name.Contains("tail"))
        {
            Debug.Log(hit.transform.name);
            return true;
        }
        return false;
    }
}
