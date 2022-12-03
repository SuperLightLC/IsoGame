using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace IsoGame;

public class Editor
{
    private List<GameObject> gameObjects = new List<GameObject>();

    private GraphicsDevice _graphicsDevice;

    BasicEffect effect;
    Texture2D texture;
    List<VertexPositionColorTexture> vertexData;
    List<int> indexData;
    Matrix viewMatrix;
    Matrix worldMatrix;
    Matrix projectionMatrix;
    GameWindow _window;
    Vector3 cameraPosition = new Vector3(0, 0, 30);

    private static readonly Vector3[] voxelVertices = new Vector3[8]{
        new Vector3(0, 0, 0),
        new Vector3(1, 0, 0),
        new Vector3(1, 1, 0),
        new Vector3(0, 1, 0),
        new Vector3(0, 0, 1),
        new Vector3(1, 0, 1),
        new Vector3(1, 1, 1),
        new Vector3(0, 1, 1)
    };
    private static readonly int[,] voxelTris = new int[6, 6]{
        {0, 3, 1, 1, 3, 2},
        {5, 6, 4, 4, 6, 7},
        {3, 7, 2, 2, 7, 6},
        {1, 5, 0, 0, 5, 4},
        {4, 7, 0, 0, 7, 3},
        {1, 2, 5, 5, 2, 6}
    };
    private static readonly Vector2[] voxelUvs = new Vector2[6]{
        new Vector2(0, 0),
        new Vector2(0, 1),
        new Vector2(1, 0),
        new Vector2(1, 0),
        new Vector2(0 ,1),
        new Vector2(1, 1)
    };

    public Editor(GraphicsDevice graphicsDevice, GameWindow window)
    {
        _graphicsDevice = graphicsDevice;
        _window = window;

        GameObject.Register += EventRegister;

        texture = Registry.GetTexture("Editor.GUI_1");
        effect = new BasicEffect(_graphicsDevice);
        SetUpVoxel(Color.White);
        SetUpCamera();
    }

    //---
    private void SetUpVoxel(Color color)
    {
        const float HALF_SIDE = 1.0f;
        const float Z = 1.0f;

        vertexData = new List<VertexPositionColorTexture>();
        for (int vertexIndex = 0; vertexIndex < 8; vertexIndex++)
        {
            indexData = new List<int>();
            for (int i = 0; i < 6; i++)
            {
                vertexData.Add(new VertexPositionColorTexture(voxelVertices[vertexIndex], color, voxelUvs[i]));

                for (int j = 0; j < 6; j++)
                {
                    indexData.Add(voxelTris[i, j]);
                }
            }
        }
    }

    private void SetUpCamera()
    {
        projectionMatrix = Matrix.CreatePerspectiveFieldOfView(
            MathHelper.ToRadians(45f),
            _graphicsDevice.Viewport.AspectRatio,
            1.0f,
            100.0f);

        viewMatrix = Matrix.CreateLookAt(
            cameraPosition,
            Vector3.Zero,
            Vector3.Up);

        worldMatrix = Matrix.CreateWorld(
            new Vector3(),
            Vector3.Forward,
            Vector3.Up);
    }
    //---

    private void EventRegister(object sender, GameObject gameObject)
    {
        gameObjects.Add(gameObject);
        Debug.Log("Register GameObject : " + gameObject.Name, LogType.System);
    }

    public void Draw()
    {
        // Draw textured box
        _graphicsDevice.RasterizerState = RasterizerState.CullNone;  // vertex order doesn't matter
        _graphicsDevice.BlendState = BlendState.NonPremultiplied;    // use alpha blending
        _graphicsDevice.DepthStencilState = DepthStencilState.None;  // don't bother with the depth/stencil buffer

        effect.View = viewMatrix;
        effect.World = worldMatrix;
        effect.Projection = projectionMatrix;
        effect.Texture = texture;
        effect.TextureEnabled = true;
        effect.DiffuseColor = Color.White.ToVector3();
        effect.CurrentTechnique.Passes[0].Apply();

        _graphicsDevice.DrawUserIndexedPrimitives(PrimitiveType.TriangleList, vertexData.ToArray(), 0, 4, indexData.ToArray(), 0, 2);

        Matrix rotationMatrix = Matrix.CreateRotationY(
            MathHelper.ToRadians(1));
        cameraPosition = Vector3.Transform(cameraPosition, rotationMatrix);
        viewMatrix = Matrix.CreateLookAt(cameraPosition, new Vector3(), Vector3.Up);
    }

    public void Update()
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