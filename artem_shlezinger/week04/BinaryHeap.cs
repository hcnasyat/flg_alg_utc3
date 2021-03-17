namespace Algorithms.PriorityQueue
{
    class BinaryHeap
    {
        public int Len { get; private set; }

        int[] Heap; 

        public BinaryHeap(int[] items)
        {
            Heap = items;
            MakeHeap();
        }

        private void Sink(int sp, int len)
        {
            while ((sp + 1) * 2 - 1 < len)
            {
                int p = (sp + 1) * 2 - 1;

                if (p + 1 < len && Heap[p + 1] > Heap[p] && Heap[p + 1] > Heap[sp])
                    p++;

                if (Heap[sp] >= Heap[p] && (p + 1 >= len || Heap[sp] >= Heap[p + 1]))
                    break;

                int h = Heap[sp];
                Heap[sp] = Heap[p];
                Heap[p] = h;

                sp = p;
            }
        }

        private void MakeHeap()
        {
            Len = Heap.Length - 1;
            int i = Len / 2;

            while(i >= 0)
            {
                Sink(i, Len + 1);
                i--;
            }
        }
       

        public int DelMax()
        {
            int h = Heap[0];
            Heap[0] = Heap[Len];
            Heap[Len] = 0;
            Len--;

            Sink(0, Len + 1);

            return h;
        }


        private void Swim(int i)
        {
            while (i > 0)
            {
                int h = Heap[(i - 1) / 2];

                if (h < Heap[i])
                {
                    Heap[(i - 1) / 2] = Heap[i];
                    Heap[i] = h;
                }
                else
                    break;

                i = (i - 1) / 2;
            }
        }

        public void Insert(int item)
        {
            Len++;
            Heap[Len] = item;
            Swim(Len);
        }


        public void HeapSort()
        {
            MakeHeap();

            int len = Heap.Length;

            for (int i = len - 1; i > 0; i--)
            {
                int h = Heap[0];
                Heap[0] = Heap[i];
                Heap[i] = h;

                Sink(0, i - 1);
            }

            if(len > 1 && Heap[0] > Heap[1])
            {
                int h = Heap[1];
                Heap[1] = Heap[0];
                Heap[0] = h;
            }
        }
    }
}
