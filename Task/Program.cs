using System;
using Microsoft.VisualBasic;


namespace Task4
{
    public abstract class TestBase
    {
        public int tc_id { get; set; }
        public string name { get; set; }

        public TestBase(int id, string testname)
        {
            tc_id = id;
            name = testname;
        }

        public abstract void prepare();

        public abstract void run();

        public abstract void clean_up();

        public void execute()
        {
            prepare();
            run();
            clean_up();
        }

    }


    public class TestCaseOne : TestBase
    {
        public TestCaseOne(int tc_id, string name) : base(tc_id, name)
        {
            Console.WriteLine($"TestCaseOne {tc_id}, {name}");
        }

        public override void prepare()
        {
            Console.WriteLine("Prepare");

            long seconds = (long)DateTime.UtcNow.Subtract(DateTime.UnixEpoch).TotalSeconds;

            Console.WriteLine($"Seconds {seconds}");
            if (seconds % 2 != 0)
            {
                System.Environment.Exit(1);
            }
        }

        public override void run()
        {
            Console.WriteLine("Run");

            string[] second = Directory.GetFiles("..\\net6.0\\"); // путь к папке

            for (int i = 0; i < second.Length; i++)
            {
                Console.WriteLine(second[i]);
            }
        }

        public override void clean_up()
        {
            Console.WriteLine("Clean up");
        }
    }

    public class TestCaseTwo : TestBase
    {
        public TestCaseTwo(int tc_id, string name) : base(tc_id, name)
        {
            Console.WriteLine($"TestCaseTwo {tc_id}, {name}");
        }

        public override void prepare()
        {
            Console.WriteLine("Prepare");
            int TotalRam = new Microsoft.VisualBasic.Devices.ComputerInfo().TotalPhysicalMemory;
            Console.WriteLine(TotalRam);

        }

        public override void run()
        {
            Console.WriteLine("Run");

            System.IO.File.WriteAllBytes("file.txt", new byte[1048576]);

            Console.WriteLine("File created");
        }

        public override void clean_up()
        {
            System.IO.File.Delete("file.txt");

            Console.WriteLine("Clean up, file deleted");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TestCaseTwo test = new TestCaseTwo(1,"first");
            TestCaseOne test2 = new TestCaseOne(2, "second");


            test.execute();
            test2.execute();

        }
    }
}