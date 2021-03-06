//------------------------------------------------------------
// Author: 烟雨迷离半世殇
// Mail: 1778139321@qq.com
// Data: 2019年7月20日 20:09:20
//------------------------------------------------------------

using System;
using System.Collections.Generic;
using Box2DSharp.Collision.Collider;
using Box2DSharp.Collision.Shapes;
using Box2DSharp.Dynamics;
using Box2DSharp.Dynamics.Contacts;

namespace ETModel
{
    [ObjectSystem]
    public class B2S_CollisionListenerComponentAwake: AwakeSystem<B2S_CollisionListenerComponent>
    {
        public override void Awake(B2S_CollisionListenerComponent self)
        {
            //绑定指定的物理世界，正常来说一个房间一个物理世界,这里是Demo，直接获取了
            Game.Scene.GetComponent<B2S_WorldComponent>().GetWorld().SetContactListener(self);
            //self.TestCollision();
            self.B2SWorldColliderManagerComponent = Game.Scene.GetComponent<B2S_WorldColliderManagerComponent>();
        }
    }

    [ObjectSystem]
    public class B2S_CollisionListenerComponentFixedUpdate: FixedUpdateSystem<B2S_CollisionListenerComponent>
    {
        public override void FixedUpdate(B2S_CollisionListenerComponent self)
        {
            self.FixedUpdate();
        }
    }

    /// <summary>
    /// 某一物理世界所有碰撞的监听者，负责碰撞事件的分发
    /// </summary>
    public class B2S_CollisionListenerComponent: Component, IContactListener
    {
        public B2S_WorldColliderManagerComponent B2SWorldColliderManagerComponent;

        public Dictionary<(long, long), bool> collisionRecorder = new Dictionary<(long, long), bool>();

        public void BeginContact(Contact contact)
        {
            //这里获取的是碰撞实体
            Entity entitya = (Entity) contact.FixtureA.UserData;
            Entity entityb = (Entity) contact.FixtureB.UserData;
            if (this.collisionRecorder.ContainsKey((entitya.Id, entityb.Id)))
            {
                this.collisionRecorder[(entitya.Id, entityb.Id)] = true;
            }
            else
            {
                this.collisionRecorder.Add((entitya.Id, entityb.Id), true);
            }

            entitya.GetComponent<B2S_CollisionResponseComponent>().OnCollideStart(entityb);
            entityb.GetComponent<B2S_CollisionResponseComponent>().OnCollideStart(entitya);
        }

        public void EndContact(Contact contact)
        {
            Entity entitya = (Entity) contact.FixtureA.UserData;
            Entity entityb = (Entity) contact.FixtureB.UserData;

            this.collisionRecorder[(entitya.Id, entityb.Id)] = false;

            entitya.GetComponent<B2S_CollisionResponseComponent>().OnCollideFinish(entityb);
            entityb.GetComponent<B2S_CollisionResponseComponent>().OnCollideFinish(entitya);
        }

        public void PreSolve(Contact contact, in Manifold oldManifold)
        {
        }

        public void PostSolve(Contact contact, in ContactImpulse impulse)
        {
        }

        public void FixedUpdate()
        {
            //TODO:待修整，var a = this.UnitComponent.Get(VARIABLE.Key.Item1);不能从unitcomponent取得，因为根本没有注册到它里面
            foreach (var VARIABLE in this.collisionRecorder)
            {
                if (VARIABLE.Value)
                {
                    var a = this.B2SWorldColliderManagerComponent.GetColliderEntity(VARIABLE.Key.Item1);
                    var b = this.B2SWorldColliderManagerComponent.GetColliderEntity(VARIABLE.Key.Item2);
                    a.GetComponent<B2S_CollisionResponseComponent>().OnCollideSustain(b);
                    b.GetComponent<B2S_CollisionResponseComponent>().OnCollideSustain(a);
                }
            }
        }

        public override void Dispose()
        {
            base.Dispose();
            if (this.IsDisposed)
                return;
            this.collisionRecorder.Clear();
        }

        /// <summary>
        /// 测试碰撞
        /// </summary>
        public void TestCollision()
        {
            BodyDef bodyDef = new BodyDef { BodyType = BodyType.DynamicBody };
            Body m_Body = Game.Scene.GetComponent<B2S_WorldComponent>().GetWorld().CreateBody(bodyDef);
            CircleShape m_CircleShape = new CircleShape();
            m_CircleShape.Radius = 5;
            m_Body.CreateFixture(m_CircleShape, 5);

            BodyDef bodyDef1 = new BodyDef { BodyType = BodyType.DynamicBody };
            Body m_Body1 = Game.Scene.GetComponent<B2S_WorldComponent>().GetWorld().CreateBody(bodyDef1);
            CircleShape m_CircleShape1 = new CircleShape();
            m_CircleShape1.Radius = 5;
            m_Body1.CreateFixture(m_CircleShape1, 5);
            Log.Info("创建完毕");
        }
    }
}