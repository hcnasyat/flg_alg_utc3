namespace Algorithms.PriorityQueue
{
    class BinaryHeap
    {
        private void Sink(int[] heap, int sp, int len)
        {
            while ((sp + 1) * 2 - 1 < len)
            {
                int p = (sp + 1) * 2 - 1;

                if (p + 1 < len && heap[p + 1] > heap[p] && heap[p + 1] > heap[sp])
                    p++;

                if (heap[sp] > heap[p] && (p + 1 >= len || heap[sp] > heap[p + 1]))
                    break;

                int h = heap[sp];
                heap[sp] = heap[p];
                heap[p] = h;

                sp = p;
            }
        }

        public void MakeHeap(int[] heap)
        {
            int i = (heap.Length - 1) / 2;
            while(i >= 0)
            {
                Sink(heap, i, heap.Length);
                i--;
            }
        }
       

        public void HeapSort(int[] heap)
        {
            MakeHeap(heap);

            int len = heap.Length;

            for (int i = len - 1; i > 0; i--)
            {
                int h = heap[0];
                heap[0] = heap[i];
                heap[i] = h;

                Sink(heap, 0, i - 1);
            }

            if(len > 1 && heap[0] > heap[1])
            {
                int h = heap[1];
                heap[1] = heap[0];
                heap[0] = h;
            }
        }
    }
}
