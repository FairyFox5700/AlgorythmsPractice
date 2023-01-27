using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAlgorythms
{
    public enum ColoringStates
    {
        Unvisited,
        Temp,
        Visited,

    }
    public class CourseScheduleWithColouring
    {
        private ColoringStates[] _coloringStates;

        private List<int> _coursesInOrder;
        // simle adjacency list
        private Dictionary<int, List<int>> graph;

        public List<int> CanFinish(int numCourses, int[][] prerequisites)
        {
            //Create a graph from the given edges
            graph = new();
            for (int i = 0; i < numCourses; i++)
                graph.Add(i, new());

            foreach (var pre in prerequisites)
            {
                var course = pre[0];
                var req = pre[1];
                graph[course].Add(req);
            }

            _coloringStates = new ColoringStates[numCourses];
            _coursesInOrder = new();
            foreach (var course in graph.Keys)
            {
                if (DFS(course) == false)
                {
                    return new List<int>();
                }
            }

            return _coursesInOrder;
        }


        private bool DFS(int course)
        {
            if (_coloringStates[course] == ColoringStates.Temp)
            {
                //we have found a cycle
                return false;
            }
            //course already visited
            if (_coloringStates[course] == ColoringStates.Visited)
            {
                return true;
            }

            _coloringStates[course] = ColoringStates.Temp;
            foreach (var req in graph[course])
            {
                // if false for any of adjacent-> return false
                if (DFS(req) == false)
                {
                    return false;
                }
            }

            //remove requisites as we already passed this courses
            graph[course] = new List<int>();
            _coloringStates[course] = ColoringStates.Visited;
            _coursesInOrder.Add(course);
            return true;
        }
    }
}
