using BrickFighter.Props;
using BrickFighter.Services;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace BrickFighter.Scenes
{
    public class FightScene : Scene
    {
        private int _playedTurn = 0;
        public override void Load()
        {
            var screen = ServiceLocator.Get<IScreenService>();
            Rectangle bounds = screen.Bounds;
            //AddGameObject(new Ball(bounds, this));
        }

        public override void Update(float dt)
        {
            var gc = ServiceLocator.Get<GameController>();
            var sm = ServiceLocator.Get<ISceneManager>();
            var bricks = GetGameObjects<Brick>();
            var bricksSword = GetGameObjects<BrickSword>();
            var bricksMagic = GetGameObjects<BrickMagic>();
            var bricksArmor = GetGameObjects<BrickArmor>();
            
            //a la fin des 4 tours : je load la birck scene
            if (_playedTurn == 4)
            {
                gc.LevelUp();
                sm.Load<BrickScene>();
                return;
            }
            
            base.Update(dt);
        }
    }
}
