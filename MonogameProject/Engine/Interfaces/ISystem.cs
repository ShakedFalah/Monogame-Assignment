using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonogameProject.Engine.Interfaces
{
    internal interface ISystem
    {
        public void Start();
        public void Update(GameTime gameTime);
    }
}
