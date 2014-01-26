﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AWGL.Interfaces;
using AWGL.Managers;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using AWGL.Shapes;
using AWGL.Utilities;
using System.Drawing;
using System.Diagnostics;

namespace AWGL.States
{
    public class VboState : IGameObject
    {
        BufferObjectManager m_bufferObjectManager = new BufferObjectManager();
        BufferObject m_bufferObject;
        StateManager m_stateManager;
        ShaderManager m_shaderManager;
        Cube cube;

        public VboState(StateManager stateManager, ShaderManager shaderManager)
        {
            m_stateManager = stateManager;
            this.m_stateManager = stateManager;
            this.m_shaderManager = shaderManager;

            cube = new Cube();

            CreateVBOs();

            //// Other state
            GL.Enable(EnableCap.DepthTest);
            GL.ClearColor(Color.MidnightBlue);
        }

        private void CreateVBOs()
        {
            // this buffer object will take care of VAO generation temporarily - stored in bufferObject.VaoId
            BufferObject tempVBO = new BufferObject();
            tempVBO.PositionData = cube.Vertices;//new Vector3[cube.Vertices.Length];
            tempVBO.NormalsData = cube.Normals; // Vector3[cube.Normals.Length];
            tempVBO.IndicesData = cube.Indices;
            tempVBO.PrimitiveType = PrimitiveType.Triangles;

            m_bufferObjectManager.AddBufferObject("test-cube", tempVBO, m_shaderManager.ProgramHandle);
            m_bufferObject = m_bufferObjectManager.GetBuffer("test-cube");

        }

        public void Update(float elapsedTime)
        {

        }

        public void Render()
        {
            GL.BindVertexArray(m_bufferObject.VaoID);
            GL.DrawElements(m_bufferObject.PrimitiveType,
                            m_bufferObject.IndicesData.Length,
                            DrawElementsType.UnsignedInt,
                            IntPtr.Zero);
        }
    }
}