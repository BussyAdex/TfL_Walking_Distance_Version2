namespace TfL_Walking_Distance_Version2.Model
{
    class MyNode
    {
        private Object item;
        private MyNode next;

        public MyNode()
        {
            item = null;
            next = null;
        }

        public MyNode(Object item)
        {
            this.item = item;
            this.next = null;
        }

        public MyNode(Object item, MyNode next)
        {
            this.item = item;
            this.next = next;
        }

        public void setItem(Object item)
        {
            this.item = item;
        }

        public void setNext(MyNode next)
        {
            this.next = next;
        }

        public Object getItem()
        {
            return this.item;
        }

        public MyNode getNext()
        {
            return this.next;
        }

        public void print()
        {
            string itemValue = (item == null ? "NULL" : item.ToString());

            string nextValue = (next == null ? "NULL" : next.getItem().ToString());

            Console.WriteLine("MyNode[ item = " + itemValue + ", \t" +
                                         "next --> " + nextValue + " ]");

        }

    }
}
