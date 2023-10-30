namespace Shared.Interfaces;

public interface IGridSizeConverter
{
    public int GetGridSize(double pixels);

    public double GetPixels(int gridSize);
}