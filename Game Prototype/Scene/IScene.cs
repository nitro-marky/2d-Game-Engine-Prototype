using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game_Prototype.Entities;
using Microsoft.Xna.Framework;

namespace Game_Prototype.Scene
{
    interface IScene
    {
        String getSceneType { get; }

        void LoadContent(List<IEntity> entities);

        void Update(GameTime gameTime);

        bool nextLevel { get; }

        IScene nextScene();

    }
}
