
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;

namespace BrickFighter.Services
{
    public interface IAssetsService
    {
        public T Get<T>(string name);
    }
    public sealed class AssetsService : IAssetsService
    {
        /// <summary>
        /// Création d'un dictionnaire qui va contenir différents assets. On prend des Objet en paramètre pour pouvoir prendre des polices, image, musique etc...
        /// </summary>
        private Dictionary<string, object> _assets = new Dictionary<string, object>();
        private ContentManager _contentManager;

        public AssetsService(ContentManager contentManager)
        {
            _contentManager = contentManager;
            ServiceLocator.Register<IAssetsService>(this); // on enregistre direct l'asset service
        }

        /// <summary>
        /// <T> permet de donner un type générique a l'appel de la fonction
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        public void Load<T>(string name)
        {
            if (_assets.ContainsKey(name))
                throw new Exception($"Asset named {name} already loaded.");
            T asset = _contentManager.Load<T>(name); // Je charge un asset avec son nom
            _assets[name] = asset; // ajoute au dictionnaire
        }

        public T Get<T>(string name)
        {
            if (!_assets.ContainsKey(name))
                throw new Exception($"Asset named {name} not registered.");
            return (T)_assets[name];
        }

    }
}
