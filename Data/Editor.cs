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
        Debug.Log("Register GameObject : " + gameObject.Name, LogType.System);
    }

    public void Update(GraphicsDevice graphicsDevice)
    {
        UpdateGameObjects();
    }

    private void UpdateGameObjects()
    {
        foreach (var gameObject in gameObjects)
        {
            gameObject.Update();

            foreach (var component in gameObject.GetAllComponent())
            {
                component.Update();
            }
        }
    }
}