using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

public class Block : Sprite
{

    public event Action BlockDestroyEvent;

    public Block(float pX, float pY) : base("colors.png", false, true)
    {
        width = DesignerClass.groundWidth;
        height = DesignerClass.groundHeight;
        x = pX;
        y = pY;
    }

    void Update()
    {
        /*
        x--;

        if (x + width < 0)
        {
            BlockDestroyEvent.Invoke();
        }
        */
    }
}