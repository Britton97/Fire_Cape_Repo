using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tail_Test
{
    public SpriteRenderer tailSprite;
    public Gradient myGradient;
    public float myLife = 1f;
    public int myPosInQueue;

    public Tail_Test(int myPlaceInQueue)
    {
        myPosInQueue = myPlaceInQueue;
    }

    public float DecreaseMyLife(float howMuch)
    {
        if (howMuch > 1f)
        {
            howMuch = 1f;
        }
        else if (howMuch < 0f)
        {
            howMuch = 0f;
        }

        myLife -= howMuch;

        if (myLife <= 0)
        {
            //print("I am deceased");
            return -1;  //if it returns -1 then remove from the list
        }
        else
        {
            tailSprite.color = myGradient.Evaluate(myLife);
            return myLife;
        }
    }

    /*
    public Vector3 MoveMe(Vector3 newPos)
    {
        Vector3 returnPos = transform.position;
        transform.position = newPos;
        return returnPos;
    }

    public void DestroyMe()
    {
        Destroy(this.gameObject);
    }
    */
}
