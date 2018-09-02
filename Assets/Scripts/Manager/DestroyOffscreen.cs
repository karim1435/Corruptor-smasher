using UnityEngine;
using System.Collections;
using System;

public class DestroyOffscreen : MonoBehaviour {

    private float offset = 10f;
    private float offScreenY;

    private Rigidbody2D body2d;

	void Awake()
    {
        body2d = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        offScreenY = (Screen.height / Camera.main.pixelHeight) / 2 +offset;
    }
    void Update()
    {
        if (checkOffScreen())
            outOfBounds();
    }
    private bool checkOffScreen()
    {
        var posY = transform.position.y;
        var directionY = body2d.velocity.y;

        bool offScreenTop = directionY < 0 && posY < -offScreenY;
        var offScreenBottom = directionY > 0 && posY > offScreenY;

        if (Mathf.Abs(posY)>offScreenY)
        {
            if (offScreenTop || offScreenBottom)
                return true;
        }
        return false;
    }
    private void outOfBounds()
    {
        gameObject.SetActive(false);
    }
}
