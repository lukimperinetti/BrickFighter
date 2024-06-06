using BrickFighter.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;



namespace BrickFighter.GameObjects
{
    public abstract class GameObject
    {
        public Scene root { get; private set; }
        public bool isFree = false;
        private bool _enable;
        public bool enable { 
            get { return _enable; }
            set {
                if (_enable != value)
                {
                    _enable = value;
                    if (_enable) OnEnable();
                    else OnDisable();
                }
            } 
        }

        public GameObject(bool enable, Scene root)
        {
            _enable = enable;
            this.root = root;
        }

        protected virtual void OnEnable() { }
        protected virtual void OnDisable() { }
        public virtual void Start() { }
        public virtual void OnFree() { }
        public virtual void Update(float dt) { }
        public virtual void Draw(SpriteBatch sb) { }
    }
}
