using GXPEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Ground : Sprite
{
    public Ground() : base("square.png", false, true) 
    {
        height = 50;
        width = 50;
        y = DesignerClass.wHeight - height;
    }

    void Update()
    {

    }
}
