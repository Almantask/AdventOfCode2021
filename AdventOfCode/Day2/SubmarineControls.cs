namespace AdventOfCode.Day2;

public interface ISubmarineControls
{
    int Depth { get; }
    int Horizon { get; }

    void Down(int amount);
    void Forward(int amount);
    void Up(int amount);
}

public class SubmarineControlsV1 : ISubmarineControls
{
    public int Depth { get; private set; }
    public int Horizon { get; private set; }

    public void Forward(int amount)
    {
        Horizon += amount;
    }

    public void Up(int amount)
    {
        Depth -= amount;
    }

    public void Down(int amount)
    {
        Depth += amount;
    }
}

public class SubmarineControlsV2 : ISubmarineControls
{
    public int Aim { get; private set; }
    public int Depth { get; private set; }
    public int Horizon { get; private set; }

    public void Forward(int amount)
    {
        Horizon += amount;
        Depth += amount * Aim;
    }

    public void Up(int amount)
    {
        Aim -= amount;
    }

    public void Down(int amount)
    {
        Aim += amount;
    }
}