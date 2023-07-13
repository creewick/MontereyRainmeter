using System;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace uWidgets.Services;

public static class StoryboardExtensions
{
    public static async Task BeginAsync(this Storyboard storyboard)
    {
        var taskCompletionSource = new TaskCompletionSource<bool>();

        void OnCompleted(object? sender, EventArgs e)
        {
            storyboard.Completed -= OnCompleted;
            storyboard.Remove();
            taskCompletionSource.SetResult(true);
        }

        storyboard.Completed += OnCompleted;
        storyboard.Begin();

        await taskCompletionSource.Task;
    } 
}