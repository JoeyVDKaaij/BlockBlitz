using GXPEngine;
using GXPEngine.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiledMapParser;

public class Coin : AnimationSpriteAddOn 
{
    public Coin(string fileName, int colums, int rows, TiledObject coinObject = null) : base(fileName, colums, rows, -1, false, true)
    {
        if (coinObject != null)
        {
        }
    }
}
