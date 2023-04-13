using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace uWidgets.UserInterface.Animations;

public class AnimationBuilder
{
    public AnimationBuilder(int totalFrames)
    {
        TotalFrames = totalFrames;
        Animations = new List<IAnimation>();
    }

    public int TotalFrames { get; }
    public List<IAnimation> Animations { get; }

    public AnimationBuilder Add(IAnimation animation)
    {
        Animations.Add(animation);

        return this;
    }

    public void Animate()
    {
        Enumerable
            .Range(0, TotalFrames + 1)
            .ToList()
            .ForEach(frame =>
            {
                Animations.ForEach(animation => animation.Animate(frame, TotalFrames));
                Thread.Sleep(1);
            });
    }
}