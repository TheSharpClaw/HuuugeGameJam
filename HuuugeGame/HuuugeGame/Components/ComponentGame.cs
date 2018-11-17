using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuuugeGame
{
    class ComponentGame : StateTemplate
    {
        //RYSOWANIE NA EKRANIE
        public void Draw()
        {

        }

        //OBLICZENIA
        public void Update()
        {


            Draw();
        }


        public void CheckCollisions()
        {
            //TODO: butterfly -> spider
            //TODO: butterfly -> web
        }

        public void SpiderControls()
        {
            //TODO: movement
            //TODO: place web
        }

        public void ButterflyControls()
        {
            //TODO: movement
        }
    }
}
