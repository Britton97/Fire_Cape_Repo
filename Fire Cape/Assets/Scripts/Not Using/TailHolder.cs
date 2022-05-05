using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TailHolder : MonoBehaviour
{
    public bool setTailOrder = false;
    public List<Vector2> myTails = new List<Vector2>();
    [SerializeField] public Player player;

    void Update()
    {
        if (setTailOrder)
        {
            myTails.Clear();
            //ArrangeTail();
            //player.tailLength = myTails.Count;
            setTailOrder = false;
        }
    }
    /*
    private void ArrangeTail()
    {
        int i = 0;
        foreach (Transform child in transform)
        {
            Tail t = child.GetComponent<Tail>();
            Vector3 tailPos = t.GetLocalPos();
            Vector3 newPos = new Vector3(Mathf.Round(tailPos.x), Mathf.Round(tailPos.y), tailPos.z);
            //Vector2 returned = t.SetLocalPos(newPos);
            if(myTails.Contains(returned))
            {
                Debug.LogError($"Something went wrong with {child.transform.name}\r\nPerhaps it is overlapping with something");
                return;
            }
            myTails.Add(returned);
            child.name = $"{i}";
            i++;
        }
    }
    */
}
