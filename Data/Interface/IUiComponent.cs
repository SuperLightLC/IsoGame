using Microsoft.Xna.Framework;

namespace IsoGame.UI;

public interface IUiComponent
{
    public Sprite Sprite { get; protected set; }
    public Vector2 Size { get; protected set; }
    public Vector2 Offset { get; protected set; }
}