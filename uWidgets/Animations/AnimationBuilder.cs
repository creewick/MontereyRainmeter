using System;
using System.Collections.Generic;
using System.Windows.Threading;

namespace uWidgets.Animations;

public class AnimationBuilder
{
    private readonly int totalFrames;
    private int currentFrame;
    private readonly List<IAnimation> animations;
    private readonly DispatcherTimer timer;

    public AnimationBuilder(int totalFrames)
    {
        this.totalFrames = totalFrames;
        currentFrame = 0;
        timer = new DispatcherTimer();
        timer.Interval = TimeSpan.FromMilliseconds(1);
        timer.Tick += (_, _) => Tick();
        animations = new List<IAnimation>();
    }
    
    public AnimationBuilder Add(IAnimation animation)
    {
        if (animation.Active()) animations.Add(animation);
        return this;
    }

    public void Animate()
    {
        if (animations.Count == 0) return;

        timer.Start();
    }
    
    private void Tick()
    {
        currentFrame++;
        
        if (currentFrame > totalFrames)
            timer.Stop();
        else
        {
            foreach (var animation in animations)
            {
                animation.Animate(currentFrame, totalFrames);
            }
        }
    }
}