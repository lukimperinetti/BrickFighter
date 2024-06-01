using BrickFighter.Scenes;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickFighter.GameObjects
{
    public class GameObject
    {
        private bool _enable;
        public SceneModel root { get; private set; }
        public bool isFree = false;
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

        public GameObject(bool enable, SceneModel root)
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
