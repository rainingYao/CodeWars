using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeWars.Kata
{
    class LearnIEu
    {
        void test()
        {

            useIfoo(new Foo());
            useIfoo(new Foo());
            useIfoo(new Goo());


        }


        void useIfoo(IFoo ifoo)
        {
            ifoo.a();
            (ifoo as Foo).b();
            (ifoo as Goo).c();
        }


        void usefoo(Foo foo)
        {

            foo.a();
            foo.b();
        }
        void usegoo(Goo goo)
        {
            goo.a();
            goo.c();
        }
    }

    interface IFoo
    {
        int a();
    }

    class Foo : IFoo
    {
        public int a()
        {
            return 1;
        }

        public int b()
        {
            return 2;
        }
    }

    class Goo : IFoo
    {
        public int a()
        {
            return 3;
        }

        public int c()
        {
            return 4;
        }
    }



}
