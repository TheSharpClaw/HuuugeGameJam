using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuuugeGame
{
    interface StateTemplate
    {
        void Update();
        void Draw();
        void OnLoad();
    }
}
