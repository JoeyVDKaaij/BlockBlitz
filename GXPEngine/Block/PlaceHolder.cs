using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using GXPEngine.Core;
using TiledMapParser;

public class PlaceHolder : AnimationSpriteAddOn
{
    public event Action PlaceHolderReplaceWithBlockEvent;
    public event Action PlaceHolderDestroyEvent;
    private double xSpeed = 1;

    public PlaceHolder(string fileName, int colums, int rows, TiledObject groundObject = null) : base(fileName, colums, rows, -1, false, true)
    {
        width = DesignerClass.groundWidth;
        height = DesignerClass.groundHeight;
        //x = pX;
        //y = DesignerClass.wHeight - height * DesignerClass.groundCountDefault + pY * height;
    }

    void Update()
    {
        x -= (float)xSpeed;
        xSpeed += DesignerClass.groundXSpeedUp;
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