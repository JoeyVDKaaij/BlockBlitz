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

    private float xSpeedMultiplier = 1;
    
    public EndPoint(string fileName, int colums, int rows, TiledObject circleObject = null) : base(fileName, colums, rows, -1, false, true)
    {
        if (circleObject != null)
        {

        }
    }

    void Update()
    {

    }
}