using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using GXPEngine.Core;

public class PlaceHolder : Sprite
{
    public event Action PlaceHolderReplaceWithBlockEvent;
    public event Action PlaceHolderDestroyEvent;

    public PlaceHolder(int pX, int pY) : base("checkers.png", false, true)
    {
        width = DesignerClass.groundWidth;
        height = DesignerClass.groundHeight;
        x = pX;
        y = DesignerClass.wHeight - height * DesignerClass.groundCountDefault + pY * height;
    }

    void Update()
    {
        /*
        Collision placeHolder = MoveUntilCollision(-1, 0);

        if (x + width < 0)
        {
            PlaceHolderDestroyEvent.Invoke();
        }

        if (ControlClass.up) PlaceHolderReplaceWithBlockEvent.Invoke();
        */
    }
}