﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using OpenTK.Graphics.OpenGL;
using System.Diagnostics;
using OpenTK;
using System.Drawing;
using AWGL.Utilities;

namespace AWGL.Managers
{
    /// <summary>
    /// Responsible for building individual shaders and linking them to the main program.
    /// </summary>
    public class ShaderManager : IDisposable
    {
        #region Private Members
        // Handles
        private int m_vertexShaderHandle, m_fragmentShaderHandle, m_programHandle;

        private string defaultDataPath = "Data/Shaders/";
        private string m_vertexShaderPath = "Simple_VS";
        private string m_fragmentShaderPath = "Simple_FS";
        #endregion

        #region Contructors
        public ShaderManager() 
        { 
            m_programHandle = BuildProgram(); 
        }

        public ShaderManager(string vertexShaderPath, string fragmentShaderPath)
        {
            m_vertexShaderPath = vertexShaderPath;
            m_fragmentShaderPath = fragmentShaderPath;
            m_programHandle = BuildProgram();
        }
        #endregion

        #region Shader and Program Contruction Methods
        internal string LoadShader(string shaderSourcePath)
        {
            using (StreamReader sr = new StreamReader(defaultDataPath + shaderSourcePath + ".glsl"))
            {
                return sr.ReadToEnd();
            }
        }

        internal int BuildShader(string shaderSourcePath, ShaderType shaderType)
        {
            // Create space in memory for the shader
            int shaderHandle = GL.CreateShader(shaderType);
            GL.ShaderSource(shaderHandle, LoadShader(shaderSourcePath));

            // Compile
            GL.CompileShader(shaderHandle);

            Logger.ShaderInfo(shaderHandle);

            return shaderHandle;
        }

        internal int BuildProgram()
        {
            m_vertexShaderHandle = BuildShader(m_vertexShaderPath, ShaderType.VertexShader);
            m_fragmentShaderHandle = BuildShader(m_fragmentShaderPath, ShaderType.FragmentShader);

            int programHandle = GL.CreateProgram();

            GL.AttachShader(programHandle, m_vertexShaderHandle);
            GL.AttachShader(programHandle, m_fragmentShaderHandle);

            GL.LinkProgram(programHandle);

            #region Check linker success

            int linkSuccess;
            GL.GetProgram(programHandle, GetProgramParameterName.LinkStatus, out linkSuccess); // update to use OpenGL4
            if (linkSuccess == 0)
            {
                String message;
                GL.GetProgramInfoLog(programHandle, out message);
                Logger.WriteLine("Program link failed: " + message);
            }

            #endregion

            #region Validate Program

            int validateSuccess;
            GL.ValidateProgram(programHandle);
            GL.GetProgram(programHandle, GetProgramParameterName.ValidateStatus, out validateSuccess); // update to use OpenGL4
            if (validateSuccess == 0)
            {
                String message;
                GL.GetProgramInfoLog(programHandle, out message);
                Logger.WriteLine("Program validation failed" + message);
            }
            #endregion

            // Delete the shaders as the program has them now
            GL.DeleteShader(m_vertexShaderHandle);
            GL.DeleteShader(m_fragmentShaderHandle);

            return programHandle;
        }
        #endregion

        #region IDisposable
        public void Dispose()
        {
            GL.DeleteProgram(m_programHandle);
        }
        #endregion

        #region Public Methods

        public int ProgramHandle
        {
            get
            {
                return m_programHandle;
            }
        }

        public void SetUniforms(
            out int projMatrixHandle, out int mvMatrixHandle,
            out Matrix4 projMatrix, Matrix4 mvMatrix,
            Size dimensions, ref Camera camera)
        {
            projMatrixHandle = GL.GetUniformLocation(this.ProgramHandle, "projection_matrix");
            mvMatrixHandle = GL.GetUniformLocation(this.ProgramHandle, "modelview_matrix");

            float aspectRatio = dimensions.Width / (float)(dimensions.Height);
            Matrix4.CreatePerspectiveFieldOfView((float)Math.PI / 4, aspectRatio, 1, 100, out projMatrix);

            GL.UniformMatrix4(projMatrixHandle, false, ref projMatrix);
            GL.UniformMatrix4(mvMatrixHandle, false, ref mvMatrix);
        } 
        #endregion

    }
}
