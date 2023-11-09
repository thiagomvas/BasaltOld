using GameEngineProject.Libraries.AutoDocumentation;
using GameEngineProject.Source.Core;
using GameEngineProject.Source.Entities;
using static Raylib_cs.Raylib;
using System.Numerics;
using Raylib_cs;
using GameEngineProject.Source.Core.Utils;
using GameEngineProject.Source.Components;
using System.Reflection;

namespace GameEngineProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            //AutoDocumentation.SourceNamespace = "GameEngineProject.Source";
            //AutoDocumentation.SourceDirectory = "C:\\Users\\Thiago\\source\\repos\\GameEngineProject\\Source\\";
            //AutoDocumentation.DocsRootDirectory = "C:\\Users\\Thiago\\source\\repos\\GameEngineProject\\docs\\";
            //AutoDocumentation.GithubPagesLink = "https://thiagomvas.github.io/GameEngine/";
            //AutoDocumentation.GenerateAutoDocumentation();


            Engine.Setup();

        }
    }
}