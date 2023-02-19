using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using TiledMapParser;

public class Hud : EasyDraw
{
    public static int currentScore = 0;
    public static int score = 0;


    public Hud() : base(DesignerClass.wWidth, DesignerClass.wHeight, false)
    {
    }

    void Update()
    {
        /*
        Clear(Color.Black);
        Text("Score: " + score, 50, 50);
        currentScore++;
        score = currentScore / 5;
        */
    }
}
