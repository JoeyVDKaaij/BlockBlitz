using GXPEngine;
using GXPEngine.Core;
using GXPEngine.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiledMapParser;

public class EndPoint : AnimationSpriteAddOn
{

    public static event Action EndLevelEvent;

    private double xSpeed = -1;

    public EndPoint(string fileName, int colums, int rows, TiledObject circleObject = null) : base(fileName, colums, rows, -1, false, true)
    {
        if (circleObject != null)
        {

        }
    }

    void Update()
    {
        

        Collision c = MoveUntilCollision((float)xSpeed, 0);
        if (c != null && c.other is Player)
        {
            EndLevelEvent.Invoke();
        }
        else if (c != null && c.other is Ground || c != null && c.other is PlaceHolder)
        {
            x += (float)xSpeed;
        }
        xSpeed -= DesignerClass.groundXSpeedUp;
    }
}