using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tail Scriptable Object", menuName = "Scriptable Objects/Tail")]
public class TailPreferences : ScriptableObject
{
    /*
     * Thinking that this object should hold what position the tail, its sprite, and life points.
     */

    public Sprite mySprite;
    public Gradient lifeGradient;
}
