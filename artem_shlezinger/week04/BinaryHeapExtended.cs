using System;

namespace Algorithms.PriorityQueue
{
    class Item
    {
        public int Key { get; private set; }
        public string Value { get; private set; }

        public Item(int key, string value)
        {
            Key = key;
            Value = value;
        }
    }

    class BinaryHeapExtended
    {
        public Item[] Heap;

        public int Len { get; private set; } = -1;

        public BinaryHeapExtended(int len)
        {
            Heap = new Item[len];
        }

        public void Insert(Item item)
        {
            Len++;
            Heap[Len] = item;
            Swim(Len);
        }


        private void Swim(int i)
        {
            while (i > 0)
            {
                Item h = Heap[(i - 1) / 2];

                if (h.Key < Heap[i].Key || h.Key == Heap[i].Key && String.Compare(h.Value, Heap[i].Value) > 0 )
                {
                    Heap[(i - 1) / 2] = Heap[i];
                    Heap[i] = h;
                }
                else
                    break;

                i = (i - 1) / 2;
            }
        }


        public Item DelMax()
        {
            Item h = Heap[0];
            Heap[0] = Heap[Len];
            Heap[Len] = null;
            Len--;

            Sink(0, Len + 1);

            return h;
        }


        private void Sink(int sp, int len)
        {
            while ((sp + 1) * 2 - 1 < len)
            {
                int p = (sp + 1) * 2 - 1;

                if (p + 1 < len && 
                    (Heap[p + 1].Key > Heap[p].Key && Heap[p + 1].Key >= Heap[sp].Key
                        || Heap[p + 1].Key == Heap[p].Key && String.Compare(Heap[p + 1].Value, Heap[p].Value) < 0
                    ))
                    p++;

                if (
                    (
                        Heap[sp].Key > Heap[p].Key 
                        || Heap[sp].Key == Heap[p].Key && String.Compare(Heap[sp].Value, Heap[p].Value) < 0
                    )
                    && 
                    (
                        p + 1 >= len 
                        || Heap[sp].Key > Heap[p + 1].Key || String.Compare(Heap[sp].Value, Heap[p + 1].Value) < 0
                    )
                  )
                    break;

                Item h = Heap[sp];
                Heap[sp] = Heap[p];
                Heap[p] = h;

                sp = p;
            }
        }
    }
}
