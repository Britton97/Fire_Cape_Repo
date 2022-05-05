using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tail : MonoBehaviour
{
    private GameObject tailManager;
    private Sprite tailSprite;
    private Gradient myGradient;
    public float myLife = 1f;
    private SpriteRenderer myRenderer;


    private void Awake()
    {
        foreach(Transform t in transform)
        {
            if (gameObject.transform.name.Contains("tail"))
            {
                myRenderer = t.GetComponent<SpriteRenderer>();
            }
        }
    }
    private void Start()
    {

    }

    public void SetUp(Sprite mySprite, Gradient gradient, GameObject yourManager)
    {
        myRenderer.sprite = mySprite;
        myGradient = gradient;
        tailManager = yourManager;
    }
    public void SetLocalPos(Vector3 pos)
    {
        transform.localPosition = transform.InverseTransformPoint(pos);
        //transform.localPosition = pos;
        BoxCollider2D i = GetComponent<BoxCollider2D>();
        i.offset = new Vector2(1, 1); // have to do this part because of a bug
        i.offset = Vector2.zero; // here too
    }

    public Vector3 GetLocalPos()
    {
        return transform.TransformPoint(transform.position);
    }
}
