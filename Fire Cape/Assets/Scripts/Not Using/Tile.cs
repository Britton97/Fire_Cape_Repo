using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color baseColor, offsetColor, notWalkable;
    private Color myColor;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private GameObject highlight;

    public bool isWalkable = true;

    public void Init(bool isOffset)
    {

        if (isOffset)
        {
            myColor = baseColor;
        }
        else
        {
            myColor = offsetColor;
        }

        _renderer.color = myColor;
    }

    public void ChangeWalkableStatus()
    {
        if (isWalkable)
        {
            isWalkable = false;
            _renderer.color = notWalkable;
        }
        else
        {
            isWalkable = true;
            _renderer.color = myColor;
        }
    }

    private void OnMouseEnter()
    {
        highlight.SetActive(true);
    }

    private void OnMouseExit()
    {
        highlight.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print($"Something entered. I'm {gameObject.name}");
    }
}
