namespace uWidgets.Animations;

public interface IAnimation
{
    public void Animate(int currentFrame, int totalFrames);
    public bool Active();
}