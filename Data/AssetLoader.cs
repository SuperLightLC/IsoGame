using System.Reflection;
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework.Graphics;

namespace IsoGame;

public class AssetLoader
{
    private const string RESOURCES_PATH = @"\Editor\Resources\";

    private AssetLoader()
    {

    }

    public static void LoadAssets(GraphicsDevice graphicsDevice)
    {
        var textures = new Dictionary<string, Texture2D>();
        var rootDirectory = new DirectoryInfo(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + RESOURCES_PATH);
        try
        {
            foreach (var subDirectory in rootDirectory.GetDirectories())
            {
                var directoryName = subDirectory.Name;

                foreach (var loadingFile in subDirectory.GetFiles("*.png", SearchOption.AllDirectories))
                {
                    //LoadingAssets
                    switch (directoryName)
                    {
                        //Textures
                        case ("Textures"):
                            var texture = Texture2D.FromFile(graphicsDevice, loadingFile.FullName);
                            var textureId = "Editor." + loadingFile.Name.Replace(loadingFile.Extension, "");
                            textures.Add(textureId, texture);
                            Console.WriteLine("Register Texture : " + textureId);
                            break;
                        //Audios
                        case ("Audios"):

                            break;
                    }
                }
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message + "\n" + exception.StackTrace);
        }
    }
}