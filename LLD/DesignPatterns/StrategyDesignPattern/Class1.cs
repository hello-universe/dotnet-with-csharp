namespace StrategyDesignPattern;

//--------- Strategy Interface for Walk ------------
public interface IWalkableRobot
{
    void Walk();
}

public class NormalWalk : IWalkableRobot
{
    public void Walk()
    {
        Console.WriteLine("Walking normally");
    }
}

public class NoWalk : IWalkableRobot
{
    public void Walk()
    {
        Console.WriteLine("Cannot Walk");
    }
}

// ------------ Strategy Interface for Talk ---------------
public interface ITalkableRobot
{
    void Talk();
}

public class NormalTalk : ITalkableRobot
{
    public void Talk()
    {
        Console.WriteLine("Talking normally");
    }
}

public class NoTalk : ITalkableRobot
{
    public void Talk()
    {
        Console.WriteLine("Cannot Talk");
    }
}


// ------------------ Strategy Interface for Fly ----------------

public interface IFlyableRobot
{
    void Fly();
}

public class NormalFly : IFlyableRobot
{
    public void Fly()
    {
        Console.WriteLine("Flying normally");
    }
}

public class NoFly : IFlyableRobot
{
    public void Fly()
    {
        Console.WriteLine("Cannot Fly");
    }
}

// --------------- Robot Base Class -------------

public abstract class Robot
{
    protected IWalkableRobot _walkableRobot;
    protected ITalkableRobot _talkableRobot;
    protected IFlyableRobot _flyableRobot;

    public Robot(IWalkableRobot walkableRobot, ITalkableRobot talkableRobot, IFlyableRobot flyableRobot)
    {
        _walkableRobot = walkableRobot;
        _talkableRobot = talkableRobot;
        _flyableRobot = flyableRobot;
    }

    public void Walk()
    {
        _walkableRobot.Walk();
    }

    public void Talk()
    {
        _talkableRobot.Talk();
    }

    public void Fly()
    {
        _flyableRobot.Fly();
    }
    public abstract void Projection();
}

// ------------ Concrete Robot Types ----------------

public class CompanionRobot : Robot
{
    public CompanionRobot(IWalkableRobot walkableRobot, ITalkableRobot talkableRobot, IFlyableRobot flyableRobot)
    : base(walkableRobot, talkableRobot, flyableRobot)
    {
        
    }
    public override void Projection()
    {
        Console.WriteLine("Displaying Companion Robot");
    }
}public class WorkerRobot : Robot
{
    public WorkerRobot(IWalkableRobot walkableRobot, ITalkableRobot talkableRobot, IFlyableRobot flyableRobot)
    : base(walkableRobot, talkableRobot, flyableRobot)
    {
        
    }
    public override void Projection()
    {
        Console.WriteLine("Displaying Worker Robot");
    }
}