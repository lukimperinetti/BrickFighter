using BrickFighter.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace BrickFighter.GameObjects
{
    public class Button : GameObject
    {
        public string Name { get; private set; }
        public Texture2D Texture { get; private set; }
        public int ButtonX { get; private set; }
        public int ButtonY { get; private set; }
        private Rectangle _boundingBox;

        public Action OnClick { get; set; }

        public Button(string name, Texture2D texture, int buttonX, int buttonY, Scene root) : base(true, root)
        {
            Name = name;
            Texture = texture;
            ButtonX = buttonX;
            ButtonY = buttonY;
            _boundingBox = new Rectangle(buttonX, buttonY, texture.Width, texture.Height);
        }

        // Vérifie si la souris est sur le bouton
        public bool IsMouseOver()
        {
            MouseState mouseState = Mouse.GetState();
            return _boundingBox.Contains(mouseState.Position);
        }

        public override void Update(float dt)
        {
            if (!enable) return;

            MouseState mouseState = Mouse.GetState();
            MouseState previousMouseState = MouseInput.LastMouseState;

            if (IsMouseOver() && previousMouseState.LeftButton == ButtonState.Released && mouseState.LeftButton == ButtonState.Pressed)
            {
                OnClick?.Invoke(); // Exécute l'action associée au clic
            }

            // Mettre à jour l'état de la souris pour la prochaine vérification
            MouseInput.LastMouseState = mouseState;
        }

        // Méthode de dessin
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!enable) return;

            spriteBatch.Draw(Texture, new Rectangle(ButtonX, ButtonY, Texture.Width, Texture.Height), Color.White);
        }
    }

    // Classe utilitaire pour la gestion de l'entrée de la souris
    public static class MouseInput
    {
        public static MouseState LastMouseState { get; set; }

        static MouseInput()
        {
            LastMouseState = Mouse.GetState();
        }

        public static int getMouseX()
        {
            return Mouse.GetState().X;
        }

        public static int getMouseY()
        {
            return Mouse.GetState().Y;
        }
    }
}
