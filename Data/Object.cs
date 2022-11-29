namespace IsoGame;

public abstract class Object
{
    protected readonly string id = "EMPTY_ID";
    public string Name { get; protected set; } = "Object";

    public Object(string id)
    {
        this.id = id;
        OverrideParameter();
    }

    public abstract void OverrideParameter();
    public abstract void Init();
    public abstract void Start();
    public abstract void Update();
}