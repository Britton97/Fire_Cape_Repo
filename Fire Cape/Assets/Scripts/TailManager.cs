using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailManager : MonoBehaviour
{
    [SerializeField] private TailPreferences tailPreferences;
    public List<Tail> tailList = new List<Tail>();
    public List<GameObject> tailObj = new List<GameObject>();


    private void Awake()
    {
        /*
        foreach(Tail t in tailList)
        {
            t.SetUp(tailPreferences.mySprite, tailPreferences.lifeGradient, this.gameObject);
        }
        */
    }

    private void Start()
    {
        foreach (Transform tail in transform)
        {
            tailObj.Add(tail.gameObject);
        }

        /*
        Vector3 i = new Vector3(1, 1, 1);
        Vector3 o = new Vector3(2, 2, 2);
        Debug.Log(i + o);
        */
    }

    public void PlayerChangedPosition(Vector3 oldPlayerPos)
    {
        Vector3 nextMovesHere = oldPlayerPos;
        Vector3 hold = tailObj[0].transform.localPosition;
        tailObj[0].transform.localPosition = oldPlayerPos;

        tailObj[0].GetComponent<BoxCollider2D>().offset = new Vector2(1, 1);
        tailObj[0].GetComponent<BoxCollider2D>().offset = new Vector2(0, 0);

        tailObj[1].transform.localPosition = new Vector3(hold.x + oldPlayerPos.x, hold.y + oldPlayerPos.y, 0);
        hold = tailObj[1].transform.localPosition;

        /*
        tailObj[2].transform.localPosition = new Vector3(hold.x + oldPlayerPos.x, hold.y + oldPlayerPos.y, 2);
        hold = tailObj[2].transform.localPosition;
        */
    }
}
