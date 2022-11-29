using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace IsoGame;

public class Editor
{
    private List<GameObject> gameObjects = new List<GameObject>();

    public Editor()
    {
        GameObject.Register += EventRegister;
    }

    private void EventRegister(object sender, GameObject gameObject)
    {
        gameObjects.Add(gameObject);
        Console.WriteLine("Register GameObject : " + gameObject.Name);
    }

    public void Update(GraphicsDevice graphicsDevice)
    {

    }
}