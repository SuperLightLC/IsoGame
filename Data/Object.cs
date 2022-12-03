namespace IsoGame;

public abstract class Object
{
    protected readonly string id = "empty_id";
    public string Name { get; protected set; } = "Object";

    public Object(string id)
    {
        this.id = id;
        Init();
        Start();
    }

    public abstract void Init();
    public abstract void Start();
    public abstract void Update();
}