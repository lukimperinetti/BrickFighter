using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickFighter.Scenes
{
    public abstract class SceneModel
    {
        protected ContentManager content;
        protected SpriteBatch spriteBatch;

        public SceneModel(ContentManager content, SpriteBatch spriteBatch)
        {
            this.content = content;
            this.spriteBatch = spriteBatch;
        }

        protected SceneModel(SpriteBatch spriteBatch)
        {
            this.spriteBatch = spriteBatch;
        }

        public abstract void LoadContent();
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(GameTime gameTime);

    }
}
