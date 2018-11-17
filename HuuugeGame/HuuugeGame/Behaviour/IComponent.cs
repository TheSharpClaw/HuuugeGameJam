using HuuugeGame.Content.Behaviour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuuugeGame.Behaviour
{
    interface IComponent
    {
        List<IEntity> DrawList { get; set; }
        List<IEntity> UpdateList { get; set; }
    }
}
