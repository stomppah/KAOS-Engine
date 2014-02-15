﻿using KAOS.Interfaces;
using KAOS.Managers;
using KAOS.Shapes;
using KAOS.Utilities;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;

namespace KAOS.States
{
    public class Skyboxstate : IGameObject
    {
        private BufferObjectManager m_bufferManager;
        private StateManager m_stateManager;
        private TextureManager m_textureManager;

        Cube cube;
        BufferObject cubeObject;

        // Data layout for each line below is:
        // position{XYZ},			    normal{XYZ},
        float[] vertexData = new float[] {
            0.5f, -0.5f, -0.5f,        -1.0f, 0.0f, 0.0f,
            0.5f, 0.5f, -0.5f,         -1.0f, 0.0f, 0.0f,
            0.5f, -0.5f, 0.5f,         -1.0f, 0.0f, 0.0f,
            0.5f, -0.5f, 0.5f,         -1.0f, 0.0f, 0.0f,
            0.5f, 0.5f, -0.5f,         -1.0f, 0.0f, 0.0f,
            0.5f, 0.5f, 0.5f,          -1.0f, 0.0f, 0.0f,
  
            0.5f, 0.5f, -0.5f,         0.0f, -1.0f, 0.0f,
            -0.5f, 0.5f, -0.5f,        0.0f, -1.0f, 0.0f,
            0.5f, 0.5f, 0.5f,          0.0f, -1.0f, 0.0f,
            0.5f, 0.5f, 0.5f,          0.0f, -1.0f, 0.0f,
            -0.5f, 0.5f, -0.5f,        0.0f, -1.0f, 0.0f,
            -0.5f, 0.5f, 0.5f,         0.0f, -1.0f, 0.0f,
  
            -0.5f, 0.5f, -0.5f,        1.0f, 0.0f, 0.0f,
            -0.5f, -0.5f, -0.5f,       1.0f, 0.0f, 0.0f,
            -0.5f, 0.5f, 0.5f,         1.0f, 0.0f, 0.0f,
            -0.5f, 0.5f, 0.5f,         1.0f, 0.0f, 0.0f,
            -0.5f, -0.5f, -0.5f,       1.0f, 0.0f, 0.0f,
            -0.5f, -0.5f, 0.5f,        1.0f, 0.0f, 0.0f,
  
            -0.5f, -0.5f, -0.5f,       0.0f, 1.0f, 0.0f,
            0.5f, -0.5f, -0.5f,        0.0f, 1.0f, 0.0f,
            -0.5f, -0.5f, 0.5f,        0.0f, 1.0f, 0.0f,
            -0.5f, -0.5f, 0.5f,        0.0f, 1.0f, 0.0f,
            0.5f, -0.5f, -0.5f,        0.0f, 1.0f, 0.0f,
            0.5f, -0.5f, 0.5f,         0.0f, 1.0f, 0.0f,
  
            0.5f, 0.5f, 0.5f,          0.0f, 0.0f, -1.0f,
            -0.5f, 0.5f, 0.5f,         0.0f, 0.0f, -1.0f,
            0.5f, -0.5f, 0.5f,         0.0f, 0.0f, -1.0f,
            0.5f, -0.5f, 0.5f,         0.0f, 0.0f, -1.0f,
            -0.5f, 0.5f, 0.5f,         0.0f, 0.0f, -1.0f,
            -0.5f, -0.5f, 0.5f,        0.0f, 0.0f, -1.0f,
  
            0.5f, -0.5f, -0.5f,        0.0f, 0.0f, 1.0f,
            -0.5f, -0.5f, -0.5f,       0.0f, 0.0f, 1.0f,
            0.5f, 0.5f, -0.5f,         0.0f, 0.0f, 1.0f,
            0.5f, 0.5f, -0.5f,         0.0f, 0.0f, 1.0f,
            -0.5f, -0.5f, -0.5f,       0.0f, 0.0f, 1.0f,
            -0.5f, 0.5f, -0.5f,        0.0f, 0.0f, 1.0f
        };

        static string defaultSkyboxPath = "Data/Skyboxes/set 16/";
        string[] skyboxFaces = new String[]
        {
            defaultSkyboxPath + "pos_x.bmp",
            defaultSkyboxPath + "neg_x.bmp",
            defaultSkyboxPath + "pos_y.bmp",
            defaultSkyboxPath + "neg_y.bmp",
            defaultSkyboxPath + "pos_z.bmp",
            defaultSkyboxPath + "neg_z.bmp",
        };

        Matrix3 modelMatrix3, normalMatrix;
        Vector3 eyeObjectSpace;
        Vector3 trans;

        
        int eye_handle, skybox_vao;

        float aspect = 1024 / (float)600;
        float _rotation;

        public Skyboxstate(StateManager stateManager)
        {
            m_bufferManager = new BufferObjectManager();
            m_stateManager = stateManager;
            m_textureManager = new TextureManager();

            LoadCubeMap();
            CreateShaders();

            _rotation = MathHelper.DegreesToRadians(90);
            trans = new Vector3(0f, 0f, -10f);

            LoadTestObject();
        }

        private void CreateShaders()
        {
            ShaderManager.LoadCustomProgram("Skybox", "skybox-vs", "skybox-fs");

            Renderer.handle_eyePosition = GL.GetUniformLocation(ShaderManager.Get("Skybox").ID, "eye_position");
            Renderer.handle_viewMatrix = GL.GetUniformLocation(ShaderManager.Get("Skybox").ID, "view_matrix");

            Logger.WriteLine("Render Shader");
            ShaderManager.LoadCustomProgram("Render", "render-vs", "render-fs");

            Renderer.handle_projectionMatrix = GL.GetUniformLocation(ShaderManager.Get("Render").ID, "proj_matrix");
            Renderer.handle_modelViewMatrix = GL.GetUniformLocation(ShaderManager.Get("Render").ID, "mv_matrix");
        }

        private void LoadCubeMap()
        {
            m_textureManager.LoadSkyTexture("skybox1", skyboxFaces);
            GL.Enable(EnableCap.TextureCubeMapSeamless);

            GL.GenVertexArrays(1, out skybox_vao);
            GL.BindVertexArray(skybox_vao);

            GL.DepthFunc(DepthFunction.Lequal);
        }

        private void LoadTestObject()
        {
            cube = new Cube(0, 0, 0);
            cubeObject = new BufferObject();
            cubeObject.PositionData = cube.Vertices;
            cubeObject.NormalsData = cube.Normals;
            cubeObject.IndicesData = cube.Indices;
            cubeObject.PrimitiveType = PrimitiveType.TriangleStrip;

            m_bufferManager.AddBufferObject("SkyCube", cubeObject, ShaderManager.Get("Skybox").ID);
            m_bufferManager.AddBufferObject("Cube", cubeObject, ShaderManager.Get("Render").ID);
        }

        public void Update(float elapsedTime)
        {
            MoveCamera();

            Renderer.projectionMatrix = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(90.0f), aspect, 0.1f, 100.0f);
            
            Renderer.viewMatrix = Camera.GetViewMatrix();

            Renderer.modelViewMatrix = Matrix4.Mult(Renderer.viewMatrix, Matrix4.CreateTranslation(Camera.Position));
            Renderer.eyePosition = Camera.Position;
        }

        public void Render()
        {
            cubeObject = m_bufferManager.GetBuffer("SkyCube");
            Renderer.DrawSkyBox(m_textureManager, cubeObject);
            
            cubeObject = m_bufferManager.GetBuffer("Cube");
            GL.BindVertexArray(cubeObject.VaoID);
            GL.UseProgram(ShaderManager.Get("Render").ID);

            GL.UniformMatrix4(Renderer.handle_modelViewMatrix, false, ref Renderer.modelViewMatrix);
            GL.UniformMatrix4(Renderer.handle_projectionMatrix, false, ref Renderer.projectionMatrix);

            GL.DrawElements(cubeObject.PrimitiveType, cubeObject.IndicesData.Length, DrawElementsType.UnsignedInt, IntPtr.Zero);
        }

        #region Input Control
        private void MoveCamera()
        {
            foreach (Key key in InputManager.keyList)
            {

                switch (key)
                {
                    case Key.W:
                        Camera.Move(0f, 0.1f, 0f);
                        break;

                    case Key.A:
                        Camera.Move(-0.1f, 0f, 0f);
                        break;

                    case Key.S:
                        Camera.Move(0f, -0.1f, 0f);
                        break;

                    case Key.D:
                        Camera.Move(0.1f, 0f, 0f);
                        break;

                    case Key.Q:
                        Camera.Move(0f, 0f, 0.1f);
                        break;

                    case Key.E:
                        Camera.Move(0f, 0f, -0.1f);
                        break;

                    case Key.F1:
                        Renderer.ToggleWireframeOn();
                        break;

                    case Key.F2:
                        Renderer.ToggleWireframeOff();
                        break;

                    default:
                        break;
                }


            }
        #endregion
        }
    }
}