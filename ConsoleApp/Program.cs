namespace ConsoleApp
{
    using System;

    enum CarName
    {
        Ford,
        Mersedes,
        Toyota,
        Opel,
        Renault
    }
    enum RepairType
    {
        Engine,
        Wheels,
        Transmition,
        Doors,
        Bumper
    }
    class ConsoleApp
    {
        abstract class RepairCarFactory
        {
            public abstract CarFactory CreateRepairCarFactory(CarName Name);
            public abstract void Repair();
            public abstract CarName GetName();
        }
        abstract class CarFactory : RepairCarFactory
        {
            public override CarFactory CreateRepairCarFactory(CarName Name)
            {
                Console.Write("Run Repair Your Car ... - ");
                switch (Name)
                {
                    case CarName.Ford:
                        return new CarFord(Name);
                    case CarName.Mersedes:
                        return new CarMersedes(Name);
                    case CarName.Toyota:
                        return new CarToyota(Name);
                    case CarName.Opel:
                        return new CarOpel(Name);
                    case CarName.Renault:
                        return new CarRenault(Name);
                    default:
                        throw new ArgumentException("AutoService can't repair your Car!");
                }                
            }            
        }
        class CarFord : CarFactory
        {
            private CarName Name;
            public CarFord(CarName Name)
            {
                if (Name == CarName.Ford)
                {
                    this.Name = Name;
                }
                else
                {
                    throw new ArgumentException("\"Ford\" AutoService can't repaire your car, you need to repair your car in \"" + Name + "\" AutoService");
                }
            }
            public override void Repair()
            {
                Random r = new Random((int)DateTime.Now.Ticks);
                int rInt = r.Next(0, 4);

                Console.Write("Your car is \"{0}\", The \"{1}\" is repaired\r\n", Name, (RepairType)rInt);
            }
            public override CarName GetName()
            {
                return Name;
            }
        }
        class CarMersedes : CarFactory
        {
            private CarName Name;
            public CarMersedes(CarName Name)
            {
                if (Name == CarName.Mersedes)
                {
                    this.Name = Name;
                }
                else
                {
                    throw new ArgumentException("\"Mersedes\" AutoService can't repaire your car, you need to repair your car in \"" + Name + "\" AutoService");
                }
            }
            public override void Repair()
            {
                Random r = new Random((int)DateTime.Now.Ticks);
                int rInt = r.Next(0, 4);

                Console.Write("Your car is \"{0}\", The \"{1}\" is repaired\r\n", Name, (RepairType)rInt);
            }
            public override CarName GetName()
            {
                return Name;
            }
        }
        class CarToyota : CarFactory
        {
            private CarName Name;
            public CarToyota(CarName Name)
            {
                if (Name == CarName.Toyota)
                {
                    this.Name = Name;
                }
                else
                {
                    throw new ArgumentException("\"Toyota\" AutoService can't repaire your car, you need to repair your car in \"" + Name + "\" AutoService");
                }
            }
            public override void Repair()
            {
                Random r = new Random((int)DateTime.Now.Ticks);
                int rInt = r.Next(0, 4);

                Console.Write("Your car is \"{0}\", The \"{1}\" is repaired\r\n", Name, (RepairType)rInt);
            }
            public override CarName GetName()
            {
                return Name;
            }
        }
        class CarOpel : CarFactory
        {
            private CarName Name;
            public CarOpel(CarName Name)
            {
                if (Name == CarName.Opel)
                {
                    this.Name = Name;
                }
                else
                {
                    throw new ArgumentException("\"Opel\" AutoService can't repaire your car, you need to repair your car in \"" + Name + "\" AutoService");
                }
            }
            public override void Repair()
            {
                Random r = new Random((int)DateTime.Now.Ticks);
                int rInt = r.Next(0, 4);

                Console.Write("Your car is \"{0}\", The \"{1}\" is repaired\r\n", Name, (RepairType)rInt);
            }
            public override CarName GetName()
            {
                return Name;
            }
        }
        class CarRenault : CarFactory
        {
            private CarName Name;
            public CarRenault(CarName Name)
            {
                if (Name == CarName.Renault)
                {
                    this.Name = Name;
                }
                else
                {
                    throw new ArgumentException("\"Renault\" AutoService can't repaire your car, you need to repair your car in \"" + Name + "\" AutoService");
                }
            }
            public override void Repair()
            {
                Random r = new Random((int)DateTime.Now.Ticks);
                int rInt = r.Next(0, 4);

                Console.Write("Your car is \"{0}\", The \"{1}\" is repaired\r\n", Name, (RepairType)rInt);
            }
            public override CarName GetName()
            {
                return Name;
            }
        }
        class AutoService
        {
            private RepairCarFactory _carFactory;
            // Constructor
            public AutoService(RepairCarFactory factory)
            {
                _carFactory = factory.CreateRepairCarFactory(factory.GetName());
            }
            public void RunRepairCar()
            {
                _carFactory.Repair();
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("\r\n a.tkachenko/homework/12-AutoService \r\n");
            
            try
            {
                RepairCarFactory MyFord = new CarFord(CarName.Ford);
                AutoService Service = new AutoService(MyFord);
                Service.RunRepairCar();

                RepairCarFactory MyMersedes = new CarMersedes(CarName.Mersedes);
                Service = new AutoService(MyMersedes);
                Service.RunRepairCar();

                RepairCarFactory MyToyota = new CarToyota(CarName.Toyota);
                Service = new AutoService(MyToyota);
                Service.RunRepairCar();

                RepairCarFactory MyOpel = new CarOpel(CarName.Opel);
                Service = new AutoService(MyOpel);
                Service.RunRepairCar();

                RepairCarFactory MyRenault = new CarRenault(CarName.Renault);
                Service = new AutoService(MyRenault);
                Service.RunRepairCar();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
