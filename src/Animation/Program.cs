namespace Animation;

internal class Program
{
    private static async Task Main(string[] args)
    {
        // Same animation 1 fps
        await new Animation().Run(1, 4000, true, async (timestamp, progress) =>
        {
            await WriteStuff(progress);
        });
        Console.Clear();

        // Same animation 10 fps
        await new Animation().Run(10, 4000, true, async (timestamp, progress) =>
        {
            await WriteStuff(progress);
        });
        Console.Clear();

        // Same animation 30 fps
        await new Animation().Run(30, 4000, true, async (timestamp, progress) =>
        {
            await WriteStuff(progress);
        });
        Console.Clear();

        // Same animation 60 fps
        await new Animation().Run(60, 4000, true, async (timestamp, progress) =>
        {
            await WriteStuff(progress);
        });
        Console.Clear();

        Console.WriteLine("Done");
        Console.ReadKey();
    }

    private static Task WriteStuff(double progress)
    {
        Console.SetCursorPosition(0, 0);
        Console.Write($"Progress: {progress}");
        Console.WriteLine($"          ");
        for (var i = 0; i < progress * 100; i++)
        {
            Console.Write(" ");
        }
        Console.Write("*");

        return Task.CompletedTask;
    }
}
