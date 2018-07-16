using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldCSharp
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World");
			//Addition
			int number1, number2;
			Console.WriteLine("Addition");
			Console.WriteLine("Please enter first number:");
			number1 = int.Parse(Console.ReadLine());
			Console.WriteLine("Please enter second number:");
			number2 = int.Parse(Console.ReadLine());
			Console.WriteLine("Sum is " + (number1 + number2));
			//expandoobject
			dynamic user = new System.Dynamic.ExpandoObject();
			user.Name = "It's Me";
			user.Age = 666;
			user.Location = "Here";
			Console.WriteLine(user.Name + " " + user.Age + " " + user.Location);
			//var
			var camelCase = new {
				Name = "Person",
				PascalCase = true
			};
			Console.WriteLine(camelCase.Name + " " + camelCase.PascalCase);
			//dynamic
			dynamic thingus = new
			{
				Item = "Henlo"
			};
			Console.WriteLine(thingus.Item);
			thingus = "different";
			Console.WriteLine(thingus + " " + thingus.Length);
			//lists
			List<string> listOfNames = new List<string>()
			{
				"John Doe",
				"Jane Doe",
				"Joe Doe",
				"Another Doe"
			};

			listOfNames.RemoveAll(name =>
			{
				if (name.StartsWith("J"))
					return true;
				else
					return false;
			});
			Console.WriteLine(listOfNames[0]);
			//dictionaries
			Dictionary<string, int> users = new Dictionary<string, int>()
			{
				{ "John Doe", 42 },
				{ "Jane Doe", 38 },
				{ "Joe Doe", 12 },
				{ "Jenna Doe", 12 }
			};
			foreach (KeyValuePair<string, int> what in users.OrderBy(what => what.Value))
			{
				Console.WriteLine(what.Key + " is " + what.Value + " years old");
			}
			//classes
			Car car;
			car = new Car("Red");
			Console.WriteLine(car.Describe());
			//inheritance
			Animal a = new Animal();
			a.Greet();
			Dog d = new Dog();
			d.Greet();
			//abstract classes
			Dog2 fla = new Dog2();
			Console.WriteLine(fla.Describe());
			//interfaces
			List<Dog3> dogs = new List<Dog3>();
			dogs.Add(new Dog3("Fido"));
			dogs.Add(new Dog3("Bob"));
			dogs.Add(new Dog3("Adam"));
			dogs.Sort();
			foreach (Dog3 dog in dogs)
				Console.WriteLine(dog.Describe());
			//const and readonly
			const int answerToLife = 42;
			SomeClass s = new SomeClass();
			Console.WriteLine(s.later);
			//operators
			int? i = null;
			string value = null;
			Console.WriteLine(value ?? "No Value");
			double daysSinceMillenium = (DateTime.Now - new DateTime(2000, 1, 1)).TotalDays;
			Console.WriteLine($"Today is {DateTime.Now:d} and {daysSinceMillenium:N2} days have passed since the last millennium!");
			//enums
			Days day = (Days)5;
			Console.WriteLine(day);
			string[] values = Enum.GetNames(typeof(Days));
			foreach (string s1 in values)
				Console.WriteLine(s1);
			//structs
			Car2 car2;
			car2 = new Car2("Blue");
			Console.WriteLine(car2.Describe());
			Console.ReadLine();
		}
		public enum Days
		{
			Monday = 1, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
		}
		class Car
		{
			private string color;

			public Car(string color) : this()
			{
				this.color = color;
			}

			public Car()
			{
				Console.WriteLine("Constructor with no parameters called!");
			}

			public string Describe()
			{
				return "This car is " + Color;
			}

			public string Color
			{
				get { return color; }
				set { color = value; }
			}

			~Car()
			{
				Console.WriteLine("Destructor called!");
				Console.ReadLine();
			}
		}
		public class Animal
		{
			public virtual void Greet()
			{
				Console.WriteLine("Hello, I'm some sort of animal!");
			}
		}

		public class Dog : Animal
		{
			public override void Greet()
			{
				base.Greet();
				Console.WriteLine("Hello, I'm a dog!");
			}
		}
		abstract class FourLeggedAnimal
		{
			public virtual string Describe()
			{
				return "This animal has four legs.";
			}
		}

		class Dog2 : FourLeggedAnimal
		{
			public override string Describe()
			{
				string result = base.Describe();
				result += " In fact, it's a dog!";
				return result;
			}
		}
		interface IAnimal
		{
			string Describe();

			string Name
			{
				get;
				set;
			}
		}

		class Dog3 : IAnimal, IComparable
		{
			private string name;

			public Dog3(string name)
			{
				this.Name = name;
			}

			public string Describe()
			{
				return "Hello, I'm a dog and my name is " + this.Name;
			}

			public int CompareTo(object obj)
			{
				if (obj is IAnimal)
					return this.Name.CompareTo((obj as IAnimal).Name);
				return 0;
			}

			public string Name
			{
				get { return name; }
				set { name = value; }
			}
		}
		class SomeClass
		{
			private readonly DateTime rightNow;
			public readonly DateTime later = DateTime.Now.AddHours(2);

			public SomeClass()
			{
				this.rightNow = DateTime.Now;
			}
		}
		struct Car2
		{
			private string color;

			public Car2(string color)
			{
				this.color = color;
			}

			public string Describe()
			{
				return "This car is " + Color;
			}

			public string Color
			{
				get { return color; }
				set { color = value; }
			}
		}
	}
}
