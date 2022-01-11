using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace HomeWorkOOP1
{
    enum Sex { male, female };

    class Person
    {
        private Sex sex;
        private string name;
        private Person partner { get; set; }
        private Person dad;
        private Person mom;
        private List<Person> child;

        public Person(string name, Sex sex)
        {
            this.name = name;
            this.sex = sex;
        }


        public string GetPersonName()
        {
            return this.name;
        }

        public string GetPartnerName()
        {

            if (this.partner != null)
            {
                return this.partner.name;
            }
            else
            {
                return "Not found";
            }
        }
        public Person GetPartner()
        {
            return this.partner;
        }


        public void MarrriedOn(Person married)
        {
            if (!isValid(married))
            {
                return;
            }

            if (!isChildValidation(this, married))
                return;

            if (this.sex == married.sex)
            {
                Console.WriteLine("not available in your country");
                return;
            }

            if (this.partner == null)
            {
                this.partner = married;
                married.partner = this;
            }

            else
            {
                this.partner.partner = null;
                this.partner = married;
                married.partner = this;
            }
        }


        public void SetChild(Person child)
        {
            if (!isValid(child))
            {
                return;
            }

            if (child.dad != null || child.mom != null)
                return;

            if (this.child != null)
            {
                this.child.Add(child);
            }
            if (this.child == null)
            {
                List<Person> children = new List<Person>();
                children.Add(child);
                this.child = children;
            }

            if (this.partner != null)

            {

                if (this.partner.child != null)
                {
                    this.partner.child.Add(child);
                }

                if (this.partner.child == null)

                {
                    List<Person> children = new List<Person>();
                    children.Add(child);
                    this.partner.child = children;

                }

                if (this.partner.sex == Sex.male)
                {
                    child.dad = this.partner;
                }

                if (this.partner.sex == Sex.female)
                {
                    child.mom = this.partner;
                }
            }

            if (this.sex == Sex.male) { child.dad = this; }
            if (this.sex == Sex.female) { child.mom = this; }
        }


        private Person GetDad()
        {
            return this.dad;
        }

        private Person GetMom()
        {
            return this.mom;
        }

        public string GetParentsNames()

        {
            return this.dad?.name + " " + this.mom?.name;
        }

        private List<Person> FindBloodUncles()
        {
            List<Person> uncle_list = new List<Person>();
            if (this.dad != null || this.mom != null)
            {
                if (this.dad?.dad != null)
                {
                    foreach (Person uncle in this.dad.dad.child)
                    {
                        if (uncle != this.dad && uncle != this.mom)
                        {
                            uncle_list.Add(uncle);

                        }
                    }
                }

                if (this.mom?.dad != null && this?.mom != null)
                {
                    foreach (Person uncle in this.mom.dad.child)
                    {
                        if (uncle != this.mom && uncle != this.dad)
                        {
                            uncle_list.Add(uncle);
                        }
                    }
                }


                if (this.dad?.mom != null && this.dad != null)
                {
                    foreach (Person uncle in this.dad.mom.child)
                    {
                        if (uncle != this.mom && uncle != this.dad)
                        {
                            foreach (Person person in uncle_list)
                            {
                                if (uncle != person)
                                {
                                    uncle_list.Add(uncle);
                                }

                            }

                        }
                    }
                }

                if (this.mom?.mom != null && this?.mom != null)
                {
                    foreach (Person uncle in this.mom.mom.child)
                    {
                        if (uncle != this.mom && uncle != this.dad)
                        {
                            foreach (Person person in uncle_list)
                            {
                                if (uncle != person)
                                {
                                    uncle_list.Add(uncle);

                                }
                            }
                        }
                    }
                }

            }

            return uncle_list;
        }
        public List<Person> GetUncles()
        {
            List<Person> listOfUncles = new List<Person>();
            foreach (Person uncles in this.FindBloodUncles())
            {
                listOfUncles.Add(uncles);
                if (uncles.partner != null)
                {
                    listOfUncles.Add(uncles.partner);
                }
            }
            return listOfUncles;

        }

        public void PrintUncles()
        {
            foreach (Person uncles in this.GetUncles())
            {
                Console.WriteLine(uncles.name);

            }

        }


        private List<Person> GetLaws()
        {
            List<Person> laws_list = new List<Person>();
            if (this.partner != null)
            {
                laws_list.Add(this.partner.dad);
                laws_list.Add(this.partner.mom);
            }
            return laws_list;

        }

        public void PrintLaws()
        {

            foreach (Person laws in this.GetLaws())
            {
                Console.WriteLine(laws.name);
            }
        }

        public List<Person> GetCusins()
        {
            List<Person> cusin_list = new List<Person>();
            List<Person> Uncles_list = this.GetUncles();
            Person LastUncle = null;
            foreach (Person uncle in Uncles_list)
            {
                if (uncle.child != null && LastUncle != uncle.partner)
                {
                    cusin_list.AddRange(uncle.child);
                    LastUncle = uncle;
                }

            }
            return cusin_list;
        }




        public void PrintCusins()
        {

            foreach (Person cusin in this.GetCusins())
            {
                Console.WriteLine(cusin.name);
            }
        }


        public void PrintChild()
        {
            if (this.child != null)
            {
                foreach (Person child in this.child)
                {
                    Console.WriteLine(child.name);
                }
            }

            else
            {
                Console.WriteLine("not found");

            }
        }

        private bool isValid(Person comparedPerson)
        {
            if (this == comparedPerson)
            {
                Console.WriteLine("validate failed");
                return false;
            }

            if(!isFamilyValid(this, comparedPerson))
                return false;

            return true;
        }

        private bool isFamilyValid(Person person, Person complarePerson)
        {
            bool validation = true;

            if (person.dad == complarePerson || person.mom == complarePerson)
                validation = false;

            if (person.child?.Contains(complarePerson) ?? false) validation = false;

            if(person.dad != null)
                if(!isFamilyValid(person.dad, complarePerson)) validation = false;

            if (person.mom != null) 
                if (!isFamilyValid(person.mom, complarePerson)) validation = false;

            if (!validation) Console.WriteLine("family validation Failded");
            return validation;
        }

        private bool isChildValidation(Person person, Person complarePerson)
        {
            bool validation = true;

            if(person == complarePerson) validation = false;

            foreach (Person child in person.child ?? new List<Person>())
            {
                if (!isChildValidation(child, complarePerson)) validation = false;
            }

            foreach (Person child in complarePerson.child ?? new List<Person>())
            {
                if (!isChildValidation(child, person)) validation = false;
            }

            return validation;
        }
    }


}
