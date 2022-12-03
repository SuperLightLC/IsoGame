using Microsoft.Xna.Framework;

namespace IsoGame.UI;

public class UiComponent : Component
{
    public UiComponent() : base("ui_component")
    {

    }

    public Sprite Sprite { get; protected set; }
    public Vector2 Size { get; protected set; }
    public Vector2 Offset { get; protected set; }

    public override void Init()
    {

    }

    public override void Start()
    {

    }

    public override void Update()
    {

    }
}