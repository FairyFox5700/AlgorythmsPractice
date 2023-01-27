using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorythmsChapter.Threads
{
    // 15.3 Dining Philosophers: In the famous dining philosophers problem, a bunch of philosophers are
    // sitting around a circular table with one chopstick between each of them.A philosopher needs both
    // chopsticks to eat, and always picks up the left chopstick before the right one.A deadlock could
    //    potentially occur if all the philosophers reached for the left chopstick atthe same time. Using threads
    // and locks, implement a simulation of the dining philosophers problem that prevents deadlocks.

    public class Chopstick
    {
        private readonly object balanceLock = new object();
        private readonly int _priority;

        public Chopstick(int priority)
        {

            _priority = priority;
        }

        public void PickUp()
        {
            Monitor.Enter(balanceLock);
        }

        public void PutDown()
        {
            Monitor.Exit(balanceLock);
        }

        public int GetPriority()
        {
            return _priority;
        }
    }
    internal class DyningPhylosophers
    {
        private const int PhysolophersCount = 10;
        private Chopstick _left;
        private Chopstick _right;
        private readonly int _index;

        public DyningPhylosophers(int index, Chopstick left, Chopstick right)
        {
            _index = index;
            if (left.GetPriority() < right.GetPriority())
            {
                this._left = left;
                this._right = right;
            }
            else
            {
                this._left = right;
                this._right = left;
            }
        }

        public void PutDown()
        {
            _right.PutDown();
            _left.PutDown();
        }

        public void PickUp()
        {
            _left.PickUp();
            _right.PickUp();
        }
        public void Chew()
        {

        }

        public void Eat()
        {
            PickUp();
            Chew();
            PutDown();
        }

        public void Run()
        {
            var threadArray = new Thread[PhysolophersCount];

            for (int i = 0; i < PhysolophersCount; i++)
            {

                threadArray[i] = new Thread(Eat)
                {
                    Name = "Thread #" + i.ToString()
                };

                threadArray[i].Start(i);
            }
        }
    }
}
