using Algorithms.PriorityQueue;

namespace Algorithms
{
    class LastStone
    {
        public int LastStoneWeight(int[] stones)
        {
            BinaryHeap heap = new BinaryHeap(stones);

            int aMax, bMax;

            while(heap.Len > 0)
            {
                aMax = heap.DelMax();
                bMax = heap.DelMax();
                heap.Insert(aMax - bMax);
            }

            return stones[0];

        }
    }
}
