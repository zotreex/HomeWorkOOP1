using HomeWorkOOP1;
using System;
using System.Collections.Generic;

namespace HomeWorkOOP1
{
    class Program
    {
        static void Main(string[] args)
        {
            Person personGrandDad = new Person("person", Sex.male);
            Person personDad = new Person("person1", Sex.male);
            Person personMom = new Person("person2", Sex.female);

            personDad.MarrriedOn(personMom);

            Person me = new Person("person2", Sex.male);

            personMom.SetChild(me);

            me.SetChild(personMom);

            Console.WriteLine(me.GetParentsNames());

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