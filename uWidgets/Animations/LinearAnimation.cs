using System;

namespace uWidgets.Animations;

public class LinearAnimation : IAnimation
{
    private readonly Action<double> action;
    private readonly double from;
    private readonly double to;

    public LinearAnimation(Action<double> action, double from, double to)
    {
        this.action = action;
        this.from = from;
        this.to = to;
    }

    public bool Active() => Math.Abs(from - to) > 1;
    
    public void Animate(int currentFrame, int totalFrames)
    {
        action(from + (to - from) * currentFrame / totalFrames);
    }
}