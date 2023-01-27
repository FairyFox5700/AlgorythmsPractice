using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAlgorythms
{
    internal class CourseScheduleWithInDegree
    {
        private int[] _inDegrees;

        private List<int> _coursesInOrder;
        Queue<int> zeroInDegreeQueue = new Queue<int>();
        // simle adjacency list
        private Dictionary<int, List<int>> graph;

        public int[] CanFinish(int numCourses, int[][] prerequisites)
        {
            //Create a graph from the given edges
            graph = new();
            _inDegrees = new int[numCourses];
            for (int i = 0; i < numCourses; i++)
                graph.Add(i, new());

            foreach (var pre in prerequisites)
            {
                var course = pre[0];
                var req = pre[1];
                graph[course].Add(req);
                _inDegrees[req]++;
            }

            _coursesInOrder = new();
            foreach (var course in graph.Keys)
            {
                if (_inDegrees[course] == 0)
                {
                    zeroInDegreeQueue.Enqueue(course);
                }
            }
            Search();
            _coursesInOrder.Reverse();
            return _coursesInOrder.ToArray();
        }


        private void Search()
        {

            while (zeroInDegreeQueue.Count > 0)
            {
                var el = zeroInDegreeQueue.Dequeue();
                _coursesInOrder.Append(el);
                foreach (var req in graph[el])
                {
                    _inDegrees[req]--;
                    if (_inDegrees[req] == 0)
                    {
                        zeroInDegreeQueue.Enqueue(req);
                    }
                }
            }
        }
    }
}
