namespace IsoGame;

public abstract class Component : Object
{
    public GameObject gameObject { get; private set; }

    public Component(string id) : base(id)
    {
        Name = "Component";
    }

    public override abstract void Init();
    public override abstract void Start();
    public override abstract void Update();
}