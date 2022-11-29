using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace IsoGame;

public class Registry
{
    private static Dictionary<string, Texture2D> textureRegistry = new Dictionary<string, Texture2D>();

    private Registry()
    {

    }

    public static void Register(Dictionary<string, Texture2D> textures)
    {
        textureRegistry = new Dictionary<string, Texture2D>(textures);
    }
}