using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Game_Prototype.Entities;

namespace Game_Prototype.Utilities
{
    //The static content service allows classes to load content without having to pass around the initial ContentManager
    class ContentService
    {
        public static ContentManager content;



        public static void Initialise(ContentManager _content)
        {
            content = _content;
        }

        public static Texture2D getTexture(String reference)
        {
            if (content.Load<Texture2D>(reference) != null)
            {
                return content.Load<Texture2D>(reference);
            }
            else
            {
                return null;
            }

        }

 


    }
}
