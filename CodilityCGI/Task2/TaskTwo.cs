using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodilityCGI.Task2 {


    public class RoadElement {
        public int OursSide { get; set; }

        public int ForeignSide { get; set; }

        public bool IsCapital { get { return OursSide == ForeignSide;  } }

        public int DistanceToCapital { get; set; }

        public RoadElement(int elOne, int ElTwo)
        {
            OursSide = elOne;
            ForeignSide = ElTwo;
        }

        public bool ConnectingCity(int cityIndex)
        {
            return cityIndex == OursSide || cityIndex == ForeignSide;
        }

        public int GetOtherSideCity(int cityIndex)
        {
            if (cityIndex == OursSide)
                return ForeignSide;
            else if (cityIndex == ForeignSide)
                return OursSide;
            else
                return -1;

        }

        public bool Visited { get; set; }
    }


    public class Solution {

        public List<RoadElement> _Roads { get; private set; }
        public Solution()
        {
            _Roads = new List<RoadElement>();
        }

        public int[] solution(int[] T)
        {
            SetMap(T);
            var capital = GetCapital();
            capital.Visited = true;
            GoToNeighBords(_Roads, capital.OursSide, 1);
            var list = _Roads.Distinct();
            var groups = _Roads.Where(x=>!x.IsCapital).GroupBy(x => x.DistanceToCapital).OrderBy(x => x.Key).Select(g => new { distance = g.Key, cities = g.Count() });
            int[] result = new int[9];
            var groupsArray = groups.Select(x => x.cities).ToArray();
            groupsArray.CopyTo(result, 0);
            return result;
        }

        public void SetMap(int[] T)
        {
            for (int i = 0; i < T.Length; i++)
                _Roads.Add(new RoadElement(T[i], i));
        }

        public RoadElement GetCapital()
        {
            return _Roads.First(x => x.IsCapital);
        }

        public void GoToNeighBords(List<RoadElement> roads, int citySide, int currentDistance = 0)
        {
            var neigbordCities = roads.Where(x => x.ConnectingCity(citySide) && !x.IsCapital && !x.Visited);
            if(neigbordCities.Count() > 0)
                foreach(var neighbor in neigbordCities)
                {
                    neighbor.Visited = true;
                    neighbor.DistanceToCapital = currentDistance;
                    GoToNeighBords(roads, neighbor.GetOtherSideCity(citySide), currentDistance +1);
                }
        }


        /// [9, 1, 4, 9, 0, 4, 8, 9, 0, 1]
        ///         (got[] expected [1, 3, 2, 3, 0, 0, 0, ..)



    }
}
