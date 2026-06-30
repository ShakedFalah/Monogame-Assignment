using MonogameProject.MyEngine.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonogameProject.MyEngine.Interfaces
{
    internal interface IActionMap
    {
        void Update(InputState state);
    }
}
