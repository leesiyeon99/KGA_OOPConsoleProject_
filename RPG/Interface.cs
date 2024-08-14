using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public interface IInteractable
    {
        void Interaction(Player player);
    }

    public interface IGainable
    {
        void Gain(Player user);
    }
    public interface IUseable
    {
        void Use(Player player);
    }
}
