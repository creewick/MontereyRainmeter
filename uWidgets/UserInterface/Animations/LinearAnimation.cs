using System;

namespace uWidgets.UserInterface.Animations;

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

    public void Animate(int frame, int totalFrames) => action(from + (to - from) * frame / totalFrames);
}