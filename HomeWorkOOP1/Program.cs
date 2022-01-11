using HomeWorkOOP1;
using System;
using System.Collections.Generic;

namespace HomeWorkOOP1
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person("person", Sex.male);
            var parent = new Person("parent", Sex.female);
            parent.SetChild(person);

            var grandparent = new Person("grandparent", Sex.male);
            grandparent.SetChild(parent);

            var uncle = new Person("uncle", Sex.male);
            grandparent.SetChild(uncle);

            var cousin = new Person("cousin", Sex.male);
            uncle.SetChild(cousin);

            person.PrintCusins(); // ничего не выводит

            /*father.MarrriedOn(mother);
            father.SetChild(me);

            Person grandFatherByFather = new Person("Alex", Sex.male);
            grandFatherByFather.SetChild(father);
            Person grandMotherByFather = new Person("Tomua", Sex.female);
            Person fatherSister = new Person("Nastya", Sex.female);
            Person fatherBrother = new Person("Sergey", Sex.male);
            grandFatherByFather.MarrriedOn(grandMotherByFather);
            grandFatherByFather.SetChild(fatherSister);
            grandFatherByFather.SetChild(fatherBrother);

            Person grandFatherByMother = new Person("Yura", Sex.male);
            Person grandMotherByMother = new Person("Luda", Sex.female);
            grandFatherByMother.MarrriedOn(grandMotherByMother);
            grandFatherByMother.SetChild(mother);
            me.PrintUncles();
            me.PrintCusins();
            Console.WriteLine(me.GetParentsNames());*/

        }
    }
}