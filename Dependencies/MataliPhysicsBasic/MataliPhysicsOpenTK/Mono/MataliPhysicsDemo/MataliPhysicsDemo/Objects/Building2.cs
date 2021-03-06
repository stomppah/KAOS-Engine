/*
    Matali Physics Demo
    Copyright (c) 2013 KOMIRES Sp. z o. o.
 */
using System;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using Komires.MataliPhysics;

namespace MataliPhysicsDemo
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Building2
    {
        Demo demo;
        PhysicsScene scene;
        string instanceIndexName;

        public Building2(Demo demo, int instanceIndex)
        {
            this.demo = demo;
            instanceIndexName = " " + instanceIndex.ToString();
        }

        public void Initialize(PhysicsScene scene)
        {
            this.scene = scene;
        }

        public static void CreateShapes(Demo demo, PhysicsScene scene)
        {
        }

        public void Create(Vector3 objectPosition, Vector3 objectScale, Quaternion objectOrientation)
        {
            Shape box = scene.Factory.ShapeManager.Find("Box");

            PhysicsObject objectRoot = null;
            PhysicsObject objectBase = null;
            PhysicsObject objectA = null;
            PhysicsObject objectB = null;

            objectRoot = scene.Factory.PhysicsObjectManager.Create("Building 2" + instanceIndexName);

            objectA = scene.Factory.PhysicsObjectManager.Create("Building 2 Level 1" + instanceIndexName);
            objectRoot.AddChildPhysicsObject(objectA);
            objectA.Material.RigidGroup = true;

            objectBase = scene.Factory.PhysicsObjectManager.Create("Building 2 Level 1 Floor" + instanceIndexName);
            objectA.AddChildPhysicsObject(objectBase);
            objectBase.Shape = box;
            objectBase.UserDataStr = "Box";
            objectBase.Material.RigidGroup = true;
            objectBase.Material.MinBreakRigidGroupVelocity = 200.0f;
            objectBase.InitLocalTransform.SetPosition(0.0f, -8.0f, 100.0f);
            objectBase.InitLocalTransform.SetScale(100.0f, 1.0f, 100.0f);
            objectBase.Integral.SetDensity(1.0f);
            objectBase.CreateSound(true);

            objectBase = scene.Factory.PhysicsObjectManager.Create("Building 2 Level 1 Wall 1" + instanceIndexName);
            objectA.AddChildPhysicsObject(objectBase);
            objectBase.Shape = box;
            objectBase.UserDataStr = "Box";
            objectBase.Material.RigidGroup = true;
            objectBase.Material.MinBreakRigidGroupVelocity = 200.0f;
            objectBase.InitLocalTransform.SetPosition(0.0f, 21.0f, 201.0f);
            objectBase.InitLocalTransform.SetScale(100.0f, 1.0f, 30.0f);
            objectBase.InitLocalTransform.SetOrientation(Quaternion.FromAxisAngle(Vector3.UnitX, MathHelper.DegreesToRadians(90.0f)));
            objectBase.Integral.SetDensity(1.0f);
            objectBase.CreateSound(true);

            objectBase = scene.Factory.PhysicsObjectManager.Create("Building 2 Level 1 Wall 2" + instanceIndexName);
            objectA.AddChildPhysicsObject(objectBase);
            objectBase.Shape = box;
            objectBase.UserDataStr = "Box";
            objectBase.Material.RigidGroup = true;
            objectBase.Material.MinBreakRigidGroupVelocity = 200.0f;
            objectBase.InitLocalTransform.SetPosition(101.0f, 21.0f, 100.0f);
            objectBase.InitLocalTransform.SetScale(30.0f, 1.0f, 102.0f);
            objectBase.InitLocalTransform.SetOrientation(Quaternion.FromAxisAngle(Vector3.UnitZ, MathHelper.DegreesToRadians(90.0f)));
            objectBase.Integral.SetDensity(1.0f);
            objectBase.CreateSound(true);

            objectBase = scene.Factory.PhysicsObjectManager.Create("Building 2 Level 1 Wall 3" + instanceIndexName);
            objectA.AddChildPhysicsObject(objectBase);
            objectBase.Shape = box;
            objectBase.UserDataStr = "Box";
            objectBase.Material.RigidGroup = true;
            objectBase.Material.MinBreakRigidGroupVelocity = 200.0f;
            objectBase.InitLocalTransform.SetPosition(-101.0f, 21.0f, 100.0f);
            objectBase.InitLocalTransform.SetScale(30.0f, 1.0f, 102.0f);
            objectBase.InitLocalTransform.SetOrientation(Quaternion.FromAxisAngle(Vector3.UnitZ, MathHelper.DegreesToRadians(90.0f)));
            objectBase.Integral.SetDensity(1.0f);
            objectBase.CreateSound(true);

            objectBase = scene.Factory.PhysicsObjectManager.Create("Building 2 Level 1 Wall 41" + instanceIndexName);
            objectA.AddChildPhysicsObject(objectBase);
            objectBase.Shape = box;
            objectBase.UserDataStr = "Box";
            objectBase.Material.RigidGroup = true;
            objectBase.Material.MinBreakRigidGroupVelocity = 200.0f;
            objectBase.InitLocalTransform.SetPosition(-60.0f, 21.0f, -1.0f);
            objectBase.InitLocalTransform.SetScale(40.0f, 1.0f, 30.0f);
            objectBase.InitLocalTransform.SetOrientation(Quaternion.FromAxisAngle(Vector3.UnitX, MathHelper.DegreesToRadians(90.0f)));
            objectBase.Integral.SetDensity(1.0f);
            objectBase.CreateSound(true);

            objectBase = scene.Factory.PhysicsObjectManager.Create("Building 2 Level 1 Wall 42" + instanceIndexName);
            objectA.AddChildPhysicsObject(objectBase);
            objectBase.Shape = box;
            objectBase.UserDataStr = "Box";
            objectBase.Material.RigidGroup = true;
            objectBase.Material.MinBreakRigidGroupVelocity = 200.0f;
            objectBase.InitLocalTransform.SetPosition(0.0f, 21.0f + 15.0f, -1.0f);
            objectBase.InitLocalTransform.SetScale(20.0f, 1.0f, 15.0f);
            objectBase.InitLocalTransform.SetOrientation(Quaternion.FromAxisAngle(Vector3.UnitX, MathHelper.DegreesToRadians(90.0f)));
            objectBase.Integral.SetDensity(1.0f);
            objectBase.CreateSound(true);

            objectBase = scene.Factory.PhysicsObjectManager.Create("Building 2 Level 1 Wall 43" + instanceIndexName);
            objectA.AddChildPhysicsObject(objectBase);
            objectBase.Shape = box;
            objectBase.UserDataStr = "Box";
            objectBase.Material.RigidGroup = true;
            objectBase.Material.MinBreakRigidGroupVelocity = 200.0f;
            objectBase.InitLocalTransform.SetPosition(0.0f, 21.0f - 29.0f, -1.0f);
            objectBase.InitLocalTransform.SetScale(20.0f, 1.0f, 1.0f);
            objectBase.Integral.SetDensity(1.0f);
            objectBase.CreateSound(true);

            objectBase = scene.Factory.PhysicsObjectManager.Create("Building 2 Level 1 Wall 44" + instanceIndexName);
            objectA.AddChildPhysicsObject(objectBase);
            objectBase.Shape = box;
            objectBase.UserDataStr = "Box";
            objectBase.Material.RigidGroup = true;
            objectBase.Material.MinBreakRigidGroupVelocity = 200.0f;
            objectBase.InitLocalTransform.SetPosition(60.0f, 21.0f, -1.0f);
            objectBase.InitLocalTransform.SetScale(40.0f, 1.0f, 30.0f);
            objectBase.InitLocalTransform.SetOrientation(Quaternion.FromAxisAngle(Vector3.UnitX, MathHelper.DegreesToRadians(90.0f)));
            objectBase.Integral.SetDensity(1.0f);
            objectBase.CreateSound(true);

            objectBase = scene.Factory.PhysicsObjectManager.Create("Building 2 Level 1 Wall 45" + instanceIndexName);
            objectA.AddChildPhysicsObject(objectBase);
            objectBase.Shape = box;
            objectBase.UserDataStr = "Box";
            objectBase.Material.RigidGroup = true;
            objectBase.Material.MinBreakRigidGroupVelocity = 200.0f;
            objectBase.InitLocalTransform.SetPosition(0.0f, 21.0f - 29.0f, -6.9f);
            objectBase.InitLocalTransform.SetScale(20.0f, 0.1f, 5.0f);
            objectBase.InitLocalTransform.SetOrientation(Quaternion.FromAxisAngle(Vector3.UnitX, MathHelper.DegreesToRadians(10.4f)));
            objectBase.Integral.SetDensity(1.0f);
            objectBase.CreateSound(true);

            objectBase = scene.Factory.PhysicsObjectManager.Create("Building 2 Level 1 Ceiling 11" + instanceIndexName);
            objectA.AddChildPhysicsObject(objectBase);
            objectBase.Shape = box;
            objectBase.UserDataStr = "Box";
            objectBase.Material.RigidGroup = true;
            objectBase.Material.MinBreakRigidGroupVelocity = 200.0f;
            objectBase.InitLocalTransform.SetPosition(0.0f, 50.0f, 120.0f);
            objectBase.InitLocalTransform.SetScale(100.0f, 1.0f, 40.0f);
            objectBase.Integral.SetDensity(1.0f);
            objectBase.CreateSound(true);

            objectBase = scene.Factory.PhysicsObjectManager.Create("Building 2 Level 1 Ceiling 12" + instanceIndexName);
            objectA.AddChildPhysicsObject(objectBase);
            objectBase.Shape = box;
            objectBase.UserDataStr = "Box";
            objectBase.Material.RigidGroup = true;
            objectBase.Material.MinBreakRigidGroupVelocity = 200.0f;
            objectBase.InitLocalTransform.SetPosition(0.0f, 50.0f, 40.0f);
            objectBase.InitLocalTransform.SetScale(100.0f, 1.0f, 40.0f);
            objectBase.Integral.SetDensity(1.0f);
            objectBase.CreateSound(true);

            objectBase = scene.Factory.PhysicsObjectManager.Create("Building 2 Level 1 Ceiling 13" + instanceIndexName);
            objectA.AddChildPhysicsObject(objectBase);
            objectBase.Shape = box;
            objectBase.UserDataStr = "Box";
            objectBase.Material.RigidGroup = true;
            objectBase.Material.MinBreakRigidGroupVelocity = 200.0f;
            objectBase.InitLocalTransform.SetPosition(-40.0f, 50.0f, 180.0f);
            objectBase.InitLocalTransform.SetScale(60.0f, 1.0f, 20.0f);
            objectBase.Integral.SetDensity(1.0f);
            objectBase.CreateSound(true);

            objectBase = scene.Factory.PhysicsObjectManager.Create("Building 2 Level 1 Ceiling 14" + instanceIndexName);
            objectA.AddChildPhysicsObject(objectBase);
            objectBase.Shape = box;
            objectBase.UserDataStr = "Box";
            objectBase.Material.RigidGroup = true;
            objectBase.Material.MinBreakRigidGroupVelocity = 200.0f;
            objectBase.InitLocalTransform.SetPosition(80.0f, 50.0f, 180.0f);
            objectBase.InitLocalTransform.SetScale(20.0f, 1.0f, 20.0f);
            objectBase.Integral.SetDensity(1.0f);
            objectBase.CreateSound(true);

            for (int i = 0; i < 29; i++)
            {
                objectBase = scene.Factory.PhysicsObjectManager.Create("Building 2 Level 1 Stair " + i.ToString() + instanceIndexName);
                objectA.AddChildPhysicsObject(objectBase);
                objectBase.Shape = box;
                objectBase.UserDataStr = "Box";
                objectBase.Material.UserDataStr = "Wood2";
                objectBase.Material.RigidGroup = true;
                objectBase.Material.MinBreakRigidGroupVelocity = 200.0f;
                objectBase.InitLocalTransform.SetPosition(2.5f * i - 12.5f, -7.0f + i * 2.0f * 1.0f + 1.0f, 180.0f);
                objectBase.InitLocalTransform.SetScale(2.5f, 1.0f, 20.0f);
                objectBase.Integral.SetDensity(1.0f);
                objectBase.CreateSound(true);
            }

            objectB = scene.Factory.PhysicsObjectManager.Create("Building 2 Level 2" + instanceIndexName);
            objectRoot.AddChildPhysicsObject(objectB);
            objectB.Material.RigidGroup = true;

            objectBase = scene.Factory.PhysicsObjectManager.Create("Building 2 Level 2 Wall 1" + instanceIndexName);
            objectB.AddChildPhysicsObject(objectBase);
            objectBase.Shape = box;
            objectBase.UserDataStr = "Box";
            objectBase.Material.RigidGroup = true;
            objectBase.Material.MinBreakRigidGroupVelocity = 200.0f;
            objectBase.InitLocalTransform.SetPosition(0.0f, 21.0f + 60.0f, 201.0f);
            objectBase.InitLocalTransform.SetScale(100.0f, 1.0f, 30.0f);
            objectBase.InitLocalTransform.SetOrientation(Quaternion.FromAxisAngle(Vector3.UnitX, MathHelper.DegreesToRadians(90.0f)));
            objectBase.Integral.SetDensity(1.0f);
            objectBase.CreateSound(true);

            objectBase = scene.Factory.PhysicsObjectManager.Create("Building 2 Level 2 Wall 2" + instanceIndexName);
            objectB.AddChildPhysicsObject(objectBase);
            objectBase.Shape = box;
            objectBase.UserDataStr = "Box";
            objectBase.Material.RigidGroup = true;
            objectBase.Material.MinBreakRigidGroupVelocity = 200.0f;
            objectBase.InitLocalTransform.SetPosition(101.0f, 21.0f + 60.0f, 100.0f);
            objectBase.InitLocalTransform.SetScale(30.0f, 1.0f, 102.0f);
            objectBase.InitLocalTransform.SetOrientation(Quaternion.FromAxisAngle(Vector3.UnitZ, MathHelper.DegreesToRadians(90.0f)));
            objectBase.Integral.SetDensity(1.0f);
            objectBase.CreateSound(true);

            objectBase = scene.Factory.PhysicsObjectManager.Create("Building 2 Level 2 Wall 3" + instanceIndexName);
            objectB.AddChildPhysicsObject(objectBase);
            objectBase.Shape = box;
            objectBase.UserDataStr = "Box";
            objectBase.Material.RigidGroup = true;
            objectBase.Material.MinBreakRigidGroupVelocity = 200.0f;
            objectBase.InitLocalTransform.SetPosition(-101.0f, 21.0f + 60.0f, 100.0f);
            objectBase.InitLocalTransform.SetScale(30.0f, 1.0f, 102.0f);
            objectBase.InitLocalTransform.SetOrientation(Quaternion.FromAxisAngle(Vector3.UnitZ, MathHelper.DegreesToRadians(90.0f)));
            objectBase.Integral.SetDensity(1.0f);
            objectBase.CreateSound(true);

            objectBase = scene.Factory.PhysicsObjectManager.Create("Building 2 Level 2 Wall 41" + instanceIndexName);
            objectB.AddChildPhysicsObject(objectBase);
            objectBase.Shape = box;
            objectBase.UserDataStr = "Box";
            objectBase.Material.RigidGroup = true;
            objectBase.Material.MinBreakRigidGroupVelocity = 200.0f;
            objectBase.InitLocalTransform.SetPosition(-60.0f, 21.0f + 60.0f, -1.0f);
            objectBase.InitLocalTransform.SetScale(40.0f, 1.0f, 30.0f);
            objectBase.InitLocalTransform.SetOrientation(Quaternion.FromAxisAngle(Vector3.UnitX, MathHelper.DegreesToRadians(90.0f)));
            objectBase.Integral.SetDensity(1.0f);
            objectBase.CreateSound(true);

            objectBase = scene.Factory.PhysicsObjectManager.Create("Building 2 Level 2 Wall 42" + instanceIndexName);
            objectB.AddChildPhysicsObject(objectBase);
            objectBase.Shape = box;
            objectBase.UserDataStr = "Box";
            objectBase.Material.RigidGroup = true;
            objectBase.Material.MinBreakRigidGroupVelocity = 200.0f;
            objectBase.InitLocalTransform.SetPosition(0.0f, 21.0f + 15.0f + 60.0f, -1.0f);
            objectBase.InitLocalTransform.SetScale(20.0f, 1.0f, 15.0f);
            objectBase.InitLocalTransform.SetOrientation(Quaternion.FromAxisAngle(Vector3.UnitX, MathHelper.DegreesToRadians(90.0f)));
            objectBase.Integral.SetDensity(1.0f);
            objectBase.CreateSound(true);

            objectBase = scene.Factory.PhysicsObjectManager.Create("Building 2 Level 2 Wall 43" + instanceIndexName);
            objectB.AddChildPhysicsObject(objectBase);
            objectBase.Shape = box;
            objectBase.UserDataStr = "Box";
            objectBase.Material.RigidGroup = true;
            objectBase.Material.MinBreakRigidGroupVelocity = 200.0f;
            objectBase.InitLocalTransform.SetPosition(0.0f, 21.0f - 29.0f + 60.0f, -1.0f);
            objectBase.InitLocalTransform.SetScale(20.0f, 1.0f, 1.0f);
            objectBase.Integral.SetDensity(1.0f);
            objectBase.CreateSound(true);

            objectBase = scene.Factory.PhysicsObjectManager.Create("Building 2 Level 2 Wall 44" + instanceIndexName);
            objectB.AddChildPhysicsObject(objectBase);
            objectBase.Shape = box;
            objectBase.UserDataStr = "Box";
            objectBase.Material.RigidGroup = true;
            objectBase.Material.MinBreakRigidGroupVelocity = 200.0f;
            objectBase.InitLocalTransform.SetPosition(60.0f, 21.0f + 60.0f, -1.0f);
            objectBase.InitLocalTransform.SetScale(40.0f, 1.0f, 30.0f);
            objectBase.InitLocalTransform.SetOrientation(Quaternion.FromAxisAngle(Vector3.UnitX, MathHelper.DegreesToRadians(90.0f)));
            objectBase.Integral.SetDensity(1.0f);
            objectBase.CreateSound(true);

            objectBase = scene.Factory.PhysicsObjectManager.Create("Building 2 Level 2 Ceiling 11" + instanceIndexName);
            objectB.AddChildPhysicsObject(objectBase);
            objectBase.Shape = box;
            objectBase.UserDataStr = "Box";
            objectBase.Material.RigidGroup = true;
            objectBase.Material.MinBreakRigidGroupVelocity = 200.0f;
            objectBase.InitLocalTransform.SetPosition(0.0f, 50.0f + 60.0f, 160.0f);
            objectBase.InitLocalTransform.SetScale(100.0f, 1.0f, 40.0f);
            objectBase.Integral.SetDensity(1.0f);
            objectBase.CreateSound(true);

            objectBase = scene.Factory.PhysicsObjectManager.Create("Building 2 Level 2 Ceiling 12" + instanceIndexName);
            objectB.AddChildPhysicsObject(objectBase);
            objectBase.Shape = box;
            objectBase.UserDataStr = "Box";
            objectBase.Material.RigidGroup = true;
            objectBase.Material.MinBreakRigidGroupVelocity = 200.0f;
            objectBase.InitLocalTransform.SetPosition(0.0f, 50.0f + 60.0f, 40.0f);
            objectBase.InitLocalTransform.SetScale(100.0f, 1.0f, 40.0f);
            objectBase.Integral.SetDensity(1.0f);
            objectBase.CreateSound(true);

            objectBase = scene.Factory.PhysicsObjectManager.Create("Building 2 Level 2 Ceiling 13" + instanceIndexName);
            objectB.AddChildPhysicsObject(objectBase);
            objectBase.Shape = box;
            objectBase.UserDataStr = "Box";
            objectBase.Material.RigidGroup = true;
            objectBase.Material.MinBreakRigidGroupVelocity = 200.0f;
            objectBase.InitLocalTransform.SetPosition(40.0f, 50.0f + 60.0f, 100.0f);
            objectBase.InitLocalTransform.SetScale(60.0f, 1.0f, 20.0f);
            objectBase.Integral.SetDensity(1.0f);
            objectBase.CreateSound(true);

            objectBase = scene.Factory.PhysicsObjectManager.Create("Building 2 Level 2 Ceiling 14" + instanceIndexName);
            objectB.AddChildPhysicsObject(objectBase);
            objectBase.Shape = box;
            objectBase.UserDataStr = "Box";
            objectBase.Material.RigidGroup = true;
            objectBase.Material.MinBreakRigidGroupVelocity = 200.0f;
            objectBase.InitLocalTransform.SetPosition(-80.0f, 50.0f + 60.0f, 100.0f);
            objectBase.InitLocalTransform.SetScale(20.0f, 1.0f, 20.0f);
            objectBase.Integral.SetDensity(1.0f);
            objectBase.CreateSound(true);

            for (int i = 0; i < 29; i++)
            {
                objectBase = scene.Factory.PhysicsObjectManager.Create("Building 2 Level 2 Stair " + i.ToString() + instanceIndexName);
                objectB.AddChildPhysicsObject(objectBase);
                objectBase.Shape = box;
                objectBase.UserDataStr = "Box";
                objectBase.Material.UserDataStr = "Wood2";
                objectBase.Material.RigidGroup = true;
                objectBase.Material.MinBreakRigidGroupVelocity = 200.0f;
                objectBase.InitLocalTransform.SetPosition(-2.5f * i + 12.5f, 51.0f + i * 2.0f * 1.0f + 1.0f, 100.0f);
                objectBase.InitLocalTransform.SetScale(2.5f, 1.0f, 20.0f);
                objectBase.Integral.SetDensity(1.0f);
                objectBase.CreateSound(true);
            }

            objectRoot.InitLocalTransform.SetOrientation(ref objectOrientation);
            objectRoot.InitLocalTransform.SetScale(ref objectScale);
            objectRoot.InitLocalTransform.SetPosition(ref objectPosition);

            scene.UpdateFromInitLocalTransform(objectRoot);
        }
    }
}
