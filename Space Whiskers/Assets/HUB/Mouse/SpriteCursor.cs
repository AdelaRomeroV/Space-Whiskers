using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteCursor : MonoBehaviour
{
    public Texture2D cursortex;
    private Vector2 cursorHotspot;


    // Start is called before the first frame update
    void Start()
    {
        cursorHotspot = new Vector2(cursortex.width / 2, cursortex.height / 2);
        Cursor.SetCursor(cursortex, cursorHotspot, CursorMode.Auto);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
