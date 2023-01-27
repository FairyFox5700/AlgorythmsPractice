using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAlgorythms
{
    public class CourseSchedule
    {
        private HashSet<int> visited;
        // simle adjacency list
        private Dictionary<int, List<int>> graph;

        public bool CanFinish(int numCourses, int[][] prerequisites)
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

            visited = new();

            foreach (var course in graph.Keys)
            {
                if (DFS(course) == false)
                {
                    return false;
                }
            }
            return true;
        }


        private bool DFS(int course)
        {
            if (visited.Contains(course))
            {
                //we have found a cycle
                return false;
            }
            //course without prerequisites
            if (graph[course].Count == 0)
            {
                return true;
            }
            visited.Add(course);
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
            visited.Remove(course);
            return true;
        }
    }

}
