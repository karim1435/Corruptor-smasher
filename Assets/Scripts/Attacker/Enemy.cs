using UnityEngine;
using System.Collections;
using Assets.Scripts.Attacker;

public class Enemy : MonoBehaviour
{
    #region SerializeField
    [SerializeField]
    private float hp;
    [SerializeField]
    private float attackPower;
    [SerializeField]
    private float moveSpeed;
    #endregion

    #region Properties
    public float AttackPower { get { return this.attackPower; } }
    public float Hp { get { return this.hp; } }
    public float MoveSpeed { get { return this.moveSpeed; } }
    #endregion

}

