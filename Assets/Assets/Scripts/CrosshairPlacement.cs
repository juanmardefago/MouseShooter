using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairPlacement : MonoBehaviour {

    private Vector3 zFix;
    private Vector3 mousePositionFixed;
    private SpriteRenderer crosshairSpriteRenderer;

	// Use this for initialization
	void Start () {
        Cursor.visible = false;
        zFix = new Vector3(0, 0, 10);
        crosshairSpriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        mousePositionFixed = Input.mousePosition + zFix;
        transform.position = Camera.main.ScreenToWorldPoint(mousePositionFixed);
	}

    public void ChangeCrosshairColor(Color color)
    {
        crosshairSpriteRenderer.color = color;
    }
}
