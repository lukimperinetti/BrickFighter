using BrickFighter.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace BrickFighter.GameObjects
{
    public class SpriteGameObject : GameObject
    {
        protected Texture2D texture;
        public Vector2 position;
        public Color color;
        public float rotation;
        public Vector2 scale;
        public Vector2 offset;
        public Rectangle collider
        {
            get
            {
                return new Rectangle((int)(position.X - offset.X), (int)(position.Y - offset.Y), texture.Width, texture.Height); // permet de renvoyer le rectangle exacte de la texture. permet une hitbox propore
            }
        }

        public SpriteGameObject(Scene root) : base(true, root)
        {
            position = Vector2.Zero;
            color = Color.White;
            rotation = 0f;
            scale = Vector2.One;
            offset = Vector2.Zero;
        }

        public SpriteGameObject(Scene root, Vector2 position) : base(true, root)
        {
            this.position = position;
            color = Color.White;
            rotation = 0f;
            scale = Vector2.One;
            offset = Vector2.Zero;
        }

        public override void Draw (SpriteBatch sb)
        {
            if (texture == null) return;
            sb.Draw(texture, position, null, color, rotation, offset, scale, SpriteEffects.None, 0);
        }

        public virtual void OnCollide(SpriteGameObject other)
        {

        }

    }
}
