using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="DataPlayer", menuName ="Data/Data Player")]
public class DataPlayer : ScriptableObject
{
    public float speedMove;
    public float jumpForce;
    public float maxJump;
}
