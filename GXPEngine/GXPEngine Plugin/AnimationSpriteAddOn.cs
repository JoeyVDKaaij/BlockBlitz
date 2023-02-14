using System;
using GXPEngine.Core;

namespace GXPEngine
{
    /// <summary>
    /// Animated Sprite add-on. Has all the functionality of a regular AnimationSprite, but it includes more features.
    /// </summary>
    public class AnimationSpriteAddOn : AnimationSprite
    {

        private bool _endReached = false;

        private float _animationFrameCounter = 0;

        //------------------------------------------------------------------------------------------------------------------------
        //														AnimSprite()
        //------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the <see cref="GXPEngine.AnimSprite"/> class.
        /// </summary>
        /// <param name='filename'>
        /// The name of the file to be loaded. Files are cached internally.
        /// Texture sizes should be a power of two: 1, 2, 4, 8, 16, 32, 64 etc.
        /// The width and height don't need to be the same.
        /// If you want to load transparent sprites, use .PNG with transparency.
        /// </param>
        /// <param name='cols'>
        /// Number of columns in the animation.
        /// </param>
        /// <param name='rows'>
        /// Number of rows in the animation.
        /// </param>
        /// <param name='frames'>
        /// Optionally, indicate a number of frames. When left blank, defaults to width*height.
        /// </param>
        /// <param name="keepInCache">
        /// If <c>true</c>, the sprite's texture will be kept in memory for the entire lifetime of the game. 
        /// This takes up more memory, but removes load times.
        /// </param> 
        /// <param name="addCollider">
        /// If <c>true</c>, this sprite will have a collider that will be added to the collision manager.
        /// </param> 
        public AnimationSpriteAddOn(string filename, int cols, int rows, int frames = -1, bool keepInCache = false, bool addCollider = true) : base(filename, cols, rows, frames, keepInCache, addCollider)
        {
        }

        //------------------------------------------------------------------------------------------------------------------------
        //														PreviousFrame()
        //------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Goes to the previous frame. At the start of the animation, it jumps back to the last frame. (It loops)
        /// </summary>
        public void PreviousFrame()
        {
            int frame = _currentFrame - 1;
            if (frame < _startFrame)
            {
                frame = _startFrame + _frames;
            }
            SetFrame(frame);
        }

        //------------------------------------------------------------------------------------------------------------------------
        //														ReverseAnimate()
        //------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// If the current animation frame has been shown for [_animationDelay] game frames, this
        /// jumps to the previous animation frame in the cycle.
        /// Call this method every update, and use it in combination with SetCycle to 
        /// create a timed sprite animation.
        /// Smaller values for deltaFrameTime slow down the animation. 
        /// </summary>
        public void ReverseAnimate(float deltaFrameTime = 1)
        {
            _animationFrameCounter += deltaFrameTime;
            if (_animationFrameCounter >= _animationDelay)
            {
                PreviousFrame();
                _animationFrameCounter -= _animationDelay;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------
        //														AnimateForwardAndBack()
        //------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// If the current animation frame has been shown for [_animationDelay] game frames, this
        /// jumps to the next animation frame in the cycle.
        /// If the animation reaches the last frame, reverse the loop.
        /// If the animation reaches the first frame, reverse the loop again.
        /// Call this method every update, and use it in combination with SetCycle to 
        /// create a timed sprite animation.
        /// Smaller values for deltaFrameTime slow down the animation. 
        /// </summary>
        public void AnimateForwardAndBack(float deltaFrameTime = 1)
        {
            _animationFrameCounter += deltaFrameTime;
            if (_endReached)
            {
                if (_animationFrameCounter >= _animationDelay)
                {
                    PreviousFrame();
                    _animationFrameCounter -= _animationDelay;
                }
                if (_currentFrame <= _startFrame)
                {
                    _endReached = false;
                }
            }
            else
            {
                if (_animationFrameCounter >= _animationDelay)
                {
                    NextFrame();
                    _animationFrameCounter -= _animationDelay;
                }
                if (_currentFrame >= _frames + _startFrame - 1)
                {
                    _endReached = true;
                }
            }
        }
    }
}
