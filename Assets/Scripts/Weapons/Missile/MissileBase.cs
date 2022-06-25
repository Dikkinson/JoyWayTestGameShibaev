using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MissileType { Fire, Bullet, Water }
public class MissileBase : MonoBehaviour
{
    public MissileType missileType;
}
