namespace IsoGame;

public abstract class Component : Object
{
    public Component() : base("component")
    {
        Name = "Component";
    }

    public override void OverrideParameter()
    {

    }

    public override abstract void Init();
    public override abstract void Start();
    public override abstract void Update();
}