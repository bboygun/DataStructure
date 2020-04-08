using System;

namespace PTA3
{

    public class Node<T>
    {
        private T data;//数据域
        private Node<T> next;//引用域

        //构造器：数据域和引用域，普通结点
        public Node(T val, Node<T> p)
        {
            data = val;
            next = p;
        }
        //构造器：引用域，头结点
        public Node(Node<T> p)
        {
            next = p;
        }
        //构造器：数据域，尾结点
        public Node(T val)
        {
            data = val;
            next = null;
        }
        //构造器：无参数
        public Node()
        {
            data = default(T);
            next = null;
        }
        //数据域属性
        public T Data
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
            }
        }
        //引用域属性
        public Node<T> Next
        {
            get
            {
                return next;
            }
            set
            {
                next = value;
            }
        }

    }

    //链表类，包含链表定义及基本操作方法
    public class MyLinkList<T>
    {
        private Node<T> head; //单链表的头结点

        //头结点属性
        public Node<T> Head
        {
            get { return head; }
            set { head = value; }
        }
        //构造器
        public MyLinkList()
        {
            head = null;
        }
        //求单链表的长度
        public int GetLength()
        {
            Node<T> p = head;
            int len = 0;
            while (p != null)
            {
                ++len;
                p = p.Next;
            }
            return len;
        }
        //清空单链表
        public void Clear()
        {
            head = null;
        }
        //判断单链表是否为空
        public bool IsEmpty()
        {
            if (head == null) { return true; }
            else { return false; }
        }
        //在单链表的末尾添加新元素
        public void Append(T item)
        {
            Node<T> q = new Node<T>(item);
            Node<T> p = new Node<T>();
            if (head == null)
            {
                head = q;
                return;
            }
            p = head;
            while (p.Next != null)
            {
                p = p.Next;
            }
            p.Next = q;
        }
        //在单链表的第i个结点的位置前插入一个值为item的结点  
        public void Insert(T item, int i)
        {
            if (IsEmpty() || i < 1 || i > GetLength())
            {
                Console.WriteLine("LinkList is empty or Position is error!");
                return;
            }
            if (i == 1)
            {
                Node<T> q = new Node<T>(item);
                q.Next = head;
                head = q;
                return;
            }
            Node<T> p = head;
            Node<T> r = new Node<T>();
            int j = 1;
            while (p.Next != null && j < i)
            {
                r = p;
                p = p.Next;
                ++j;
            }
            if (j == i)
            {
                Node<T> q = new Node<T>(item);
                q.Next = p;
                r.Next = q;
            }
        }
        //在单链表的第i个结点的位置后插入一个值为item的结点  
        public void InsertPost(T item, int i)
        {
            if (IsEmpty() || i < 1 || i > GetLength())
            {
                Console.WriteLine("LinkList is empty or Position is error!");
                return;
            }
            if (i == 1)
            {
                Node<T> q = new Node<T>(item);
                q.Next = head.Next;
                head.Next = q;
                return;
            }
            Node<T> p = head;
            int j = 1;
            while (p != null && j < i)
            {
                p = p.Next;
                ++j;
            }
            if (j == i)
            {
                Node<T> q = new Node<T>(item);
                q.Next = p.Next;
                p.Next = q;
            }
        }
        //删除单链表的第i个结点  
        public T Delete(int i)
        {
            if (IsEmpty() || i < 0 || i > GetLength())
            {
                Console.WriteLine("LinkList is empty or Position is error!");
                return default(T);
            }
            Node<T> q = new Node<T>();
            if (i == 1)
            {
                q = head;
                head = head.Next;
                return q.Data;
            }
            Node<T> p = head;
            int j = 1;
            while (p.Next != null && j < i)
            {
                ++j;
                q = p;
                p = p.Next;
            }
            if (j == i)
            {
                q.Next = p.Next;
                return p.Data;
            }
            else
            {
                Console.WriteLine("The " + i + "th node is not exist!");
                return default(T);
            }
        }
        //获得单链表的第i个数据元素  
        public T GetElem(int i)
        {
            if (IsEmpty() || i < 0)
            {
                Console.WriteLine("LinkList is empty or position is error! ");
                return default(T);
            }
            Node<T> p = new Node<T>();
            p = head;
            int j = 1;
            while (p.Next != null && j < i)
            {
                ++j;
                p = p.Next;
            }
            if (j == i)
            {
                return p.Data;
            }
            else
            {
                Console.WriteLine("The " + i + "th node is not exist!");
                return default(T);
            }
        }
        //在单链表中查找值为value的结点  
        public int Locate(T value)
        {
            if (IsEmpty())
            {
                Console.WriteLine("LinkList is Empty!");
                return -1;
            }
            Node<T> p = new Node<T>();
            p = head;
            int i = 1;
            while (!p.Data.Equals(value) && p.Next != null)
            {
                p = p.Next;
                ++i;
            }
            return i;
        }
        //显示链表  
        public void Display()
        {
            Node<T> p = new Node<T>();
            p = this.head;
            while (p != null)
            {
                Console.Write(p.Data + " ");
                p = p.Next;
            }
        }
    }

    struct item
    {
        public int coef;
        public int expo;
    }
    public class Program
    {
        static void Main(string[] args)
        {
            MyLinkList<item> P1, P2, PP, PS;
            P1 = newPolynomial();
            P2 = newPolynomial();
            PP = Mult(P1, P2);
            PrintPoly(PP);
            PS = Add(P1, P2);
            PrintPoly(PS);
        }
        static MyLinkList<item> Mult(MyLinkList<item> P1, MyLinkList<item> P2)
        {
            Node<item> t1, t2;
            MyLinkList<item> newP = new MyLinkList<item>();

            t1 = P1.Head;
            t2 = P2.Head;
            while (t1 != null)
            {
                MyLinkList<item> tempP = new MyLinkList<item>();
                while (t2 != null)
                {
                    item temp = new item
                    {
                        coef = t1.Data.coef * t2.Data.coef,
                        expo = t1.Data.expo + t2.Data.expo
                    };

                    
                    tempP.Append(temp);
                    t2 = t2.Next;
                }

                newP = Add(newP, tempP);
                t1 = t1.Next;
                t2 = P2.Head;

            }
            return newP;

        }
        static MyLinkList<item> Add(MyLinkList<item> P1, MyLinkList<item> P2)
        {
            Node<item> t1, t2;
            MyLinkList<item> newP = new MyLinkList<item>();
            t1 = P1.Head;
            t2 = P2.Head;
            while(t1!=null&&t2!=null)
            {
                if(t1.Data.expo==t2.Data.expo)
                {
                    item temp = new item
                    {
                        coef = t1.Data.coef + t2.Data.coef,
                        expo = t1.Data.expo
                    };
                    if(temp.coef!=0) newP.Append(temp);
                    t1 = t1.Next;
                    t2 = t2.Next;
                }
                else if(t1.Data.expo > t2.Data.expo)
                {
                    item temp = new item
                    {
                        coef = t1.Data.coef,
                        expo = t1.Data.expo
                    };
                    newP.Append(temp);
                    t1 = t1.Next;
                }
                else if (t1.Data.expo < t2.Data.expo)
                {
                    item temp = new item();  
 
                    temp.coef = t2.Data.coef;
                    temp.expo = t2.Data.expo;
                    newP.Append(temp);
                    t2 = t2.Next;
                }
            }
            while(t1!=null)
            {
                item temp = new item
                {
                    coef = t1.Data.coef,
                    expo = t1.Data.expo
                };
                newP.Append(temp);
                t1 = t1.Next;
            }
            while(t2!=null)
            {
                item temp = new item();

                temp.coef = t2.Data.coef;
                temp.expo = t2.Data.expo;
                newP.Append(temp);
                t2 = t2.Next;
            }
            return newP;
        }

        static void PrintPoly(MyLinkList<item> P)
        {
            int flag = 0;
            Node<item> p = P.Head;
            if (p == null)
            {
                Console.WriteLine("0 0\n");
                return;
            }
            string outPut = "";
            while (p != null)
            {
                outPut = string.Format(outPut + "{0} {1} ",p.Data.coef,p.Data.expo);
                p = p.Next;
                if (flag == 0)
                    flag = 1;
            }
            outPut = outPut.Trim();
            if (flag == 0) outPut = "0 0";


            Console.WriteLine(outPut);
        }
        private static MyLinkList<item> newPolynomial()
        {
            MyLinkList<item> polynomial = new MyLinkList<item>(); //实例化一个单链表  
            string str = Console.ReadLine();
            str = str.Trim();
            string[] nums = str.Split(new string[] { " " }, StringSplitOptions.None);
            int n = Convert.ToInt32(nums[0]) * 2 + 1;
            if (Convert.ToInt32(nums[0]) == 0) return null;
            int[] input = new int[n];
            int j = 0;
            for (int i = 0; i <= nums.Length - 1; i++)
            {
                if (nums[i] != "")
                {
                    input[j] = Convert.ToInt32(nums[i]);
                    j++;
                }
            }
            for (int i = 1; i <= input[0]; i++)
            {
                item a = new item();
                a.coef = input[2 * i - 1];
                a.expo = input[2 * i];
                polynomial.Append(a);
            }
            return polynomial;
        }
    }
}
