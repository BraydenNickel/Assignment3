using Assignment3.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Tests
{
    internal class SLLTest
    {
        private SLL users;
        [SetUp]
        public void Setup()
        {
            users = new SLL();
            users.AddLast(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            users.AddLast(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
            users.AddLast(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));
            users.AddLast(new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999"));

        }
        [TearDown]
        public void TearDown()
        {
            users.Clear();
        }

        [Test]
        public void TestPrepends()
        {

        }

        [Test]
        public void TestContains()
        {
            User user1 = new User(1, "Joe Blow", "jblow@gmail.com", "password");
            User user2 = new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555");
            User user3 = new User(6, "Pirate King", "pirateking@gmail.com", "Monkey");

            Assert.IsTrue(users.Contains(user1));
            Assert.IsTrue(users.Contains(user2));
            Assert.IsFalse(users.Contains(user3));
        }

        [Test]
        public void TestIndexOf()
        {
            int index1 = users.IndexOf(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            int index2 = users.IndexOf(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));


            Assert.That(index1, Is.EqualTo(0));
            Assert.That(index2, Is.EqualTo(2));
  
        }
        [Test]
        public void TestAdd()
        {
            SLL users = new SLL();
            users.AddLast(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            users.AddLast(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
            users.AddLast(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));

            User newUser = new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999");
            int index = 2;

            users.Add(newUser, index);

            Assert.That(users.GetValue(index), Is.EqualTo(newUser));
        }

        [Test]
        public void TestAddFirst()
        {
            var users = new SLL();
            users.AddLast(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            users.AddLast(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));

            var newUser = new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555");
            users.AddFirst(newUser);

            Assert.That(users.Head.Value, Is.EqualTo(newUser));
        }

        [Test]
        public void TestAddLast()
        {
            var users = new SLL();
            users.AddLast(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            users.AddLast(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));

            var newUser = new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555");
            users.AddLast(newUser);

            var currentNode = users.Head;
            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
            }

            Assert.That(currentNode.Value, Is.EqualTo(newUser));
        }

        [Test]
        public void TestClear()
        {
            SLL users = new SLL();
            users.AddLast(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            users.AddLast(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
            users.AddLast(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));
            users.AddLast(new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999"));

            users.Clear();

            Assert.That(users.Count, Is.EqualTo(0));
        }

        [Test]
        public void TestCount()
        {
            int expected = 4;

            SLL users = new SLL();
            users.AddLast(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            users.AddLast(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
            users.AddLast(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));
            users.AddLast(new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999"));

            int actual = users.Count();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestGetValue()
        {
            SLL users = new SLL();
            users.AddLast(new User(1, "Joe Blow", "jblow@gmail.com", "password"));


            User user1 = users.GetValue(0);
            Assert.That(user1.Id, Is.EqualTo(1));
            Assert.That(user1.Name, Is.EqualTo("Joe Blow"));
            Assert.That(user1.Email, Is.EqualTo("jblow@gmail.com"));
            Assert.That(user1.Password, Is.EqualTo("password"));

        }

        [Test]
        public void TestIsEmpty()
        {
            SLL emptyList = new SLL();
            Assert.IsTrue(emptyList.IsEmpty());

            SLL filledList = new SLL();
            filledList.AddLast(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            filledList.AddLast(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
            filledList.AddLast(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));
            filledList.AddLast(new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999"));
            Assert.IsFalse(filledList.IsEmpty());
        }

        [Test]
        public void TestRemove()
        {
            SLL users = new SLL();
            users.AddLast(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            users.AddLast(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
            users.AddLast(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));
            users.AddLast(new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999"));

            users.Remove(1);

            Assert.IsFalse(users.Contains(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef")));
            Assert.That(users.Count(), Is.EqualTo(3));
        }

        [Test]
        public void TestRemoveFirst()
        {
            SLL users = new SLL();
            users.AddLast(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            users.AddLast(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
            users.AddLast(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));
            users.AddLast(new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999"));

            users.RemoveFirst();

            Assert.IsFalse(users.Contains(new User(1, "Joe Blow", "jblow@gmail.com", "password")));
            Assert.That(users.Count(), Is.EqualTo(3));
        }

        [Test]
        public void TestRemoveLast()
        {
            SLL users = new SLL();
            users.AddLast(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            users.AddLast(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
            users.AddLast(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));
            users.AddLast(new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999"));

            users.RemoveLast();

            Assert.IsFalse(users.Contains(new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999")));
            Assert.That(users.Count(), Is.EqualTo(3));
        }

        [Test]
        public void TestReplace()
        {
            SLL users = new SLL();
            users.AddLast(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            users.AddLast(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
            users.AddLast(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));
            users.AddLast(new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999"));

            User newUser = new User(5, "PirateKing", "Pirateking@gmail.com", "Monkey");
            users.Replace(newUser, 2);

            Assert.IsTrue(users.Contains(new User(5, "PirateKing", "Pirateking@gmail.com", "Monkey")));
            Assert.IsFalse(users.Contains(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555")));
            Assert.IsTrue(users.Contains(new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999")));
            Assert.IsTrue(users.Contains(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef")));
            Assert.That(users.Count(), Is.EqualTo(4));
        }

        [Test]
        public void TestJoin()
        {
            var group1 = new SLL();
            group1.AddLast(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            group1.AddLast(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));

            var group2 = new SLL();
            group2.AddLast(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
            group2.AddLast(new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999"));

            group1.Join(group2);

            Assert.That(group1.Count(), Is.EqualTo(4));
            Assert.That(group1.GetValue(0).Id, Is.EqualTo(1));
            Assert.That(group1.GetValue(1).Id, Is.EqualTo(3));
            Assert.That(group1.GetValue(2).Id, Is.EqualTo(2));
            Assert.That(group1.GetValue(3).Id, Is.EqualTo(4));

        }
    }
}

