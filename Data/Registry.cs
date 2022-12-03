using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace IsoGame;

public class Registry
{
    private static Dictionary<string, Texture2D> textureRegistry = new Dictionary<string, Texture2D>();

    private Registry()
    {

    }

    public static Texture2D GetTexture(string id)
    {
        try
        {
            return textureRegistry[id];
        }
        catch (Exception exception)
        {
            Debug.Log(exception.Message + "\n" + exception.StackTrace, LogType.Error);
        }

        return null;
    }

    public static void Register(Dictionary<string, Texture2D> textures)
    {
        try
        {
            textureRegistry = new Dictionary<string, Texture2D>(textures);
        }
        catch (Exception exception)
        {
            Debug.Log(exception.Message + "\n" + exception.StackTrace, LogType.Error);
        }
    }
}