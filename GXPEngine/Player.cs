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

    private float keepCollisionSlideX = 0;
    private bool collisionNeedsSlide = false;

    private SoundChannel soundEffectSC;

    public static float playerX;

    Sound crouchSoundEffect = new Sound(DesignerClass.slideSoundEffect);
    Sound grabTheCoinSoundEffect = new Sound(DesignerClass.grabCoinSoundEffect);
    Sound deadSoundEffect = new Sound(DesignerClass.deathSoundEffect);

    public Random rand = new Random();
    
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
        playerX = x;

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
                Sound jumpSoundEffect = new Sound(DesignerClass.jumpSoundEffect[rand.Next(3)]);
                soundEffectSC = jumpSoundEffect.Play(false, 0, DesignerClass.soundEffectVolume, 0);
                y -= 1;
                ySpeed = -DesignerClass.playerJumpHeight;
                SetCycle(ArtistClass.playerJumpFrame - 1, 1);
            }

            /*
            if (c.other.y < y && keepCollisionSlideX == 0)
            {
                if (!collisionNeedsSlide)
                {
                    keepCollisionSlideX = c.other.y;
                    SetCycle(ArtistClass.playerCrouchFrame - 1, 1);
                    collisionNeedsSlide = true;
                    height = height / 2;
                    y += height / 2;
                }
            }
            else if (collisionNeedsSlide && keepCollisionSlideX != y - height / 2)
            {
                collisionNeedsSlide = false;
                y -= height / 2;
                height = maxHeight;
            }
            */

            if (!(c.other is Block) && c.other.x > x + 10 && c.other.y < y + 86 && c.other.y > y && !currentlyCrouched || c.other is Block && c.other.x > x + 10 && c.other.y < y && !currentlyCrouched)
            {
                soundEffectSC = deadSoundEffect.Play(false, 0, DesignerClass.soundEffectVolume, 0);
                MyGame.hitSpike = true;
            }

            // Crouch
            if (ControlClass.crouch)
            {
                if (!currentlyCrouched)
                {
                    soundEffectSC = crouchSoundEffect.Play(false, 0, DesignerClass.soundEffectVolume, 0);
                    currentlyCrouched = true;
                    height = height / 2;
                    y += height / 2;
                }
                SetCycle(ArtistClass.playerCrouchFrame - 1, 1);
            }
            else if (currentlyCrouched)
            {
                    currentlyCrouched = false;
                    y -= height / 2;
                    height = maxHeight;
            }

            // If the spike got got hit reset the level
            // If it's something else continue walking
            if (c.other is Spike)
            {
                soundEffectSC = deadSoundEffect.Play(false, 0, DesignerClass.soundEffectVolume, 0);
                MyGame.hitSpike = true;
            }
            else if (c.other is EndPoint)
            {
                MyGame.hitEnd = true;
            }
            else if (c.other is Coin)
            {
                soundEffectSC = grabTheCoinSoundEffect.Play(false, 0, DesignerClass.soundEffectVolume, 0);
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
