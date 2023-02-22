using GXPEngine;
using GXPEngine.Core;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using TiledMapParser;

public class Player : AnimationSpriteAddOn
{
    private float xSpeed = (float)DesignerClass.xStartingSpeed;
    private float ySpeed;
    public static float playerXStartPosition;
    private int maxHeight;

    public static bool currentlyCrouched = false;
    public static float xCrouchSpeed = DesignerClass.playerCrouchStartingSpeed;

    private bool crouchButtonReleased = true;

    private SoundChannel soundEffectSC;

    Sound jumpSoundEffect = new Sound(DesignerClass.jumpSoundEffect);
    Sound crouchSoundEffect = new Sound(DesignerClass.jumpSoundEffect);

    public Player(TiledObject tiledObjectPlayer = null) : base(ArtistClass.playerFileName, ArtistClass.playerColumn, ArtistClass.playerRow, -1, false, true)
    {
        if (tiledObjectPlayer != null)
        {
            ySpeed = tiledObjectPlayer.GetFloatProperty("ySpeed");
            playerXStartPosition = tiledObjectPlayer.GetFloatProperty("X");
        }
        //x = DesignerClass.playerSpawnX;
        //y = DesignerClass.playerSpawnY;

        maxHeight = height;

        SetCycle(ArtistClass.playerFirstWalkAnimationFrame-1, ArtistClass.playerLastWalkAnimationFrame-1);

        if (soundEffectSC != null)
            soundEffectSC.Stop();
    }

    void Update()
    {
        Animate(0.2f);
        //Collision c = MoveUntilCollision(xSpeed, ySpeed);
        Collision c = MoveUntilCollision(xSpeed, ySpeed);

        xSpeed += (float)DesignerClass.XSpeedUp;

        // If player collides
        if (c != null)
        {
            //Walk cycle
            SetCycle(ArtistClass.playerFirstWalkAnimationFrame - 1, ArtistClass.playerLastWalkAnimationFrame - 1);

            ySpeed = 1;

            // Jump
            if (ControlClass.jump)
            {
                soundEffectSC = jumpSoundEffect.Play(false, 0, DesignerClass.soundEffectVolume, 0);
                y -= 1;
                ySpeed = -DesignerClass.playerJumpHeight;
                SetCycle(ArtistClass.playerJumpFrame - 1, 1);
            }

            // Crouch
            if (ControlClass.crouch)
            {
                if (crouchButtonReleased)
                {
                    soundEffectSC = crouchSoundEffect.Play(false, 0, DesignerClass.soundEffectVolume, 0);
                    crouchButtonReleased = false;
                }
                SetCycle(ArtistClass.playerCrouchFrame - 1, 1);
                if (!currentlyCrouched)
                {
                    height = height / 2;
                    y += height / 2;
                    currentlyCrouched = true;
                }
            }
            else if (currentlyCrouched)
            {
                currentlyCrouched = false;
                y -= height / 2;
                height = maxHeight;
                crouchButtonReleased = false;
            }
            else
            {
                crouchButtonReleased = true;
            }

            // If the spike got got hit reset the level
            // If it's something else continue walking
            if (c.other is Spike)
            {
                MyGame.hitSpike = true;
            }
            else if (c.other is EndPoint)
            {
                MyGame.hitEnd = true;
            }
            else if (c.other is Coin)
            {
                c.other.LateDestroy();
                Hud.coinCounter++;
            }
            else
            {
                //Change speed when crouched
                if (Player.currentlyCrouched)
                {
                    x += xSpeed * xCrouchSpeed;
                    xCrouchSpeed -= DesignerClass.playerCrouchSpeedDecrease;
                    if (xCrouchSpeed < 0 && DesignerClass.crouchStill) xCrouchSpeed = 0;
                    if (xCrouchSpeed < DesignerClass.crouchMinSpeed) xCrouchSpeed = DesignerClass.crouchMinSpeed;
                }
                else
                {
                    x += xSpeed;
                    xCrouchSpeed = DesignerClass.playerCrouchStartingSpeed;
                }

            }
        }
        else
        {
            y -= 1;
            ySpeed = (float)(ySpeed + DesignerClass.playerGravity);
        }
    }
}
