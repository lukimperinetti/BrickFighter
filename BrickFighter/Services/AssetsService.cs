
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;

namespace BrickFighter.Services
{
    public class AssetsService
    {
        /// <summary>
        /// Création d'un dictionnaire qui va contenir différents assets. On prend des Objet en paramètre pour pouvoir prendre des polices, image, musique etc...
        /// </summary>
        private Dictionary<string, object> _assets = new Dictionary<string, object>();

        public AssetsService()
        {
            ServiceLocator.Register<AssetsService>(this); // on enregistre direct l'asset service
        }

        /// <summary>
        /// <T> permet de donner un type générique a l'appel de la fonction
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        public void LoadAsset<T>(string name)
        {
            ContentManager content = ServiceLocator.Get<ContentManager>();
            T asset = content.Load<T>(name); // Je charge un asset avec son nom
            _assets.Add(name, asset); // ajoute au dictionnaire
        }

        public T Get<T>(string name)
        {
            if (!_assets.ContainsKey(name))
                throw new Exception($"Asset named {name} not registered.");
            return (T)_assets[name];
        }

    }
}
