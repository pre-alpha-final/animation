namespace Animation;

internal class Animation
{
    public async Task Run(int fps, int duration, bool renderWait, Func<int, double, Task> taskFunc)
    {
        var startTime = DateTime.Now;
        var currentTimestamp = 0;
        do
        {
            await RenderFrame(fps, duration, renderWait, taskFunc, currentTimestamp);
            currentTimestamp = (int)(DateTime.Now - startTime).TotalMilliseconds;
        }
        while (currentTimestamp < duration);

        currentTimestamp = duration;
        await RenderFrame(fps, duration, renderWait, taskFunc, currentTimestamp);
    }

    private async Task RenderFrame(int fps, int duration, bool renderWait, Func<int, double, Task> taskFunc, int currentTimestamp)
    {
        if (renderWait)
        {
            var worktask = Task.Run(() => taskFunc(currentTimestamp, (double)currentTimestamp / duration));
            var delayTask = Task.Delay(1000 / fps);
            await Task.WhenAll(worktask, delayTask);
        }
        else
        {
            _ = Task.Run(() => taskFunc(currentTimestamp, (double)currentTimestamp / duration));
            await Task.Delay(1000 / fps);
        }
    }
}
