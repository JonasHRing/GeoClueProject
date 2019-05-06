using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoClueProject.Models
{
    public class CreaterService
    {
        List<Creater> creaters;

        public void Add()
        {
            var creater = new Creater();
            creaters = new List<Creater>();
            //creaters.Add();
        }
    }
}
