namespace AdventOfCode.Day2;

public class SubmarineControls
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