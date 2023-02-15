using System;
using System.IO;
namespace Task4
{
    public abstract class TestBase
    {
        public int tc_id { get; private set; }
        public string name { get; private set; }

        public TestBase(int tc_id, string name)
        {
            this.tc_id = tc_id;
            this.name = name;
        }
        public abstract void prepare();
        public abstract void run();
        public abstract void clean_up();

        public void execute()
        {
            try
            {
                prepare();
                run();
                clean_up();
            }
            catch (Exception)
            {
                throw;
            }

        }

    }

    
    public class TestCaseOne : TestBase
    {
        public TestCaseOne(int tc_id, string name) : base(tc_id, name)
        {
        }

        public override void prepare()
        {
            long seconds = (long)DateTime.UtcNow.Subtract(DateTime.UnixEpoch).TotalSeconds;
        }

        public override void run()
        {
            string[] second = Directory.GetFiles(".."); // путь к папке

            for (int i = 0; i < second.Length; i++)
            {
                Console.WriteLine(second[i]);
            }
        }
        public override void clean_up()
        {

        }
    }
      class program
    {
        TestCaseOne testik = new TestCaseOne(1,"first");
        
        
    }
    
}