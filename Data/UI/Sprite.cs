using System;
using Microsoft.Xna.Framework.Graphics;

namespace IsoGame.UI;

public class Sprite : Component
{
    private readonly Texture2D texture;

    public Sprite(Texture2D texture) : base("sprite")
    {
        try
        {
            this.texture = texture;
        }
        catch (Exception exception)
        {
            Debug.Log(exception.Message + "\n" + exception.StackTrace, LogType.Error);
        }
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
}