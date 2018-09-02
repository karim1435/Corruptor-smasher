using UnityEngine;
using System.Collections;
public class Tower : MonoBehaviour {

    public delegate void CollisionEnemy(Collider2D collision);
    public event CollisionEnemy onCollisionEnemy;

    #region SerializeField
    [SerializeField]
    private float hp;
    [SerializeField]
    #endregion
    public float Hp { get { return hp; } }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (onCollisionEnemy != null)
            onCollisionEnemy(collision);
    }
}
