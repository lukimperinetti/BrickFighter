using Microsoft.Xna.Framework.Content;
using Services;
using System;
using System.Collections.Generic;

namespace Services
{
/*    public class AssetsService
    {
        private Dictionary<string, objet> _assets = new Dictionary<string, objet>();

        public AssetsService()
        {
            ServiceLocator.Register<AssetsService>(this); //enregistre automatiquement 
        }


        public void Load<T>(string name)
        {
            ContentManager content = ServiceLocator.Get<ContentManager>();
            T asset = content.Load<T>(name);
            _assets[name] = asset;
        }

        public T Get<T>(string name)
        {
            if (!_assets.ContainsKey(name))
                throw new InvalidOperationException($"Asset service doest not contain {name}");
            return (T)_assets[name];
        }
    }*/
}
