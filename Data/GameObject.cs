using System.Collections.Generic;

namespace IsoGame;

public class GameObject : Object
{
    public delegate void GameObjectRegister(object sender, GameObject gameObject);
    public static event GameObjectRegister Register;

    protected List<Component> components { get; private set; } = new List<Component>();

    public GameObject() : base("game_object")
    {
        Name = "GameObject";

        Register.Invoke(this, this);
    }

    public GameObject(string name) : base("GameObject")
    {
        Name = name;

        Register.Invoke(this, this);
    }

    public override void OverrideParameter()
    {

    }

    public override void Init()
    {

    }

    public override void Start()
    {

    }

    public override void Update()
    {

    }

    public string GetId()
    {
        return id;
    }

    public List<Component> GetAllComponent()
    {
        return components;
    }
}