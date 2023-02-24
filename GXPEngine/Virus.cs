using GXPEngine;
using GXPEngine.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiledMapParser;

public class Virus : AnimationSpriteAddOn
{
    private float xSpeed = (float)DesignerClass.xStartingSpeed;

    public Virus() : base(ArtistClass.virusFileName, ArtistClass.virusColumn, ArtistClass.virusRow, -1, false, false)
    {
        SetCycle(ArtistClass.virusFirstAnimationFrame - 1, ArtistClass.virusLastAnimationFrame - 1);
        width = DesignerClass.virusWidth; 
        height = DesignerClass.virusHeight;
    }

    void Update()
    {
        Animate(0.25f);
    }
}