using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test5.Repositories;
using Test5.Domain;
using NHibernate;

namespace Test5
{
    class Program
    {
        static void Main(string[] args)
        {
            ISalesRepository rp = new SalesRepository();
            var testobs = rp.CreateTestObjects(50000);
            Stopwatch st = Stopwatch.StartNew();
            foreach (var testob in testobs)
            {
                rp.Add(testob);
            }
            st.Stop();
            Console.WriteLine(st.Elapsed);
            /*rp.Delete();*/ //Xoá tat ca record su dung SQL
            //bulkinsert();
            //WorkA();
            //WorkB();
            Console.ReadKey();
        }
        //Chay 100 Task get query
        public static void WorkA()
        {           
            var tasks = new Task[100];  //T?o m?ng 100 task
            var timeSpan = new List<TimeSpan>();          
            Random random = new Random();            
            Stopwatch st;
            bool kiemtra = true;
            while (kiemtra)
            {
                ISalesRepository rp = new SalesRepository();
                int randomID = random.Next(1, 50000000);     //Random ID t? 1->10tr
                for (int i = 0; i < tasks.Length; i++)
                {
                    tasks[i] = Task.Run(() =>
                    {                        
                        st = Stopwatch.StartNew();
                        //Get theo Id  
                        //rp.Where(x => x.Id == randomID);
                        //rp.GetListbyId(randomID);
                        rp.GetById(randomID);
                        st.Stop();
                        Console.WriteLine(st.Elapsed);
                        timeSpan.Add(st.Elapsed);
                        if (randomID == 22564783)
                            kiemtra = false;
                    });                   
                }
                // randomId ng?u nhiên các s? này s? d?ng vòng l?p
                //if (randomID == 9 || randomID == 19||randomID == 39 || randomID == 49 || randomID == 59 || 
                //    randomID == 69 || randomID == 79 || randomID == 89 || randomID == 99)
                //    kiemtra = false;
            }
            Task.WaitAll(tasks);                                 
            double doubleAverageTicks = timeSpan.Average(t => t.Ticks);            
            Console.WriteLine("Time TB: " + doubleAverageTicks);
        }
        //Chay 50 Task thuc hien các tác vu khác nhau 
        public static void WorkB()
        {
            var tasks = new Task[50];
            Stopwatch st;
            var timeSpan = new List<TimeSpan>();           
            ISalesRepository rp = new SalesRepository();
            Random random = new Random();
            //Random ID t? 1->50
            int randomID = random.Next(1, 200);
            //L?y danh sách d? li?u theo ID
            for (int i = 0; i < tasks.Length; i++)
            {
                st = Stopwatch.StartNew();
                tasks[i] = Task.Run(() =>
                {
                    if (randomID % 2 == 0)
                    {
                        Sales s = new Sales() { Id = randomID, Salesperson = "me thien ha", so1 = 31312, so2 = 424143, so3 = 1897414 };
                        rp.GetById(randomID);
                    }
                    else if (randomID % 4 == 0)
                    {
                        Sales s = new Sales() { Id = randomID };
                        rp.Update(s);
                        rp.GetById(randomID);
                    }
                    else
                    {
                        Sales s = new Sales() { Salesperson = "songoku", so1 = 2, so2 = 4, so3 = 5 };
                        rp.Add(s);
                    }
                });
                st.Stop();
                Console.WriteLine(st.Elapsed);
                timeSpan.Add(st.Elapsed);
            }
            Task.WaitAll(tasks);                       
            double doubleAverageTicks = timeSpan.Average(t => t.Ticks);
            Console.WriteLine("Time TB: " + doubleAverageTicks);
        }
        //Insert luong lon du lieu su dung Bulkinsert
        public static void bulkinsert()
        {
            string _connectionString = @"Server=DESKTOP-15V18E8;Database=SecondProject;Trusted_Connection=True";
            var dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Saleperson");
            dt.Columns.Add("Area");
            dt.Columns.Add("so1");
            dt.Columns.Add("so2");
            dt.Columns.Add("so3");
            dt.Columns.Add("so4");
            dt.Columns.Add("so5");
            dt.Columns.Add("so6");
            dt.Columns.Add("Value");


            Stopwatch st = Stopwatch.StartNew();
            for (int i = 0; i < 5000000; i++)
            {
                dt.Rows.Add(i + 1, "So " + i + 1, "KV:" + i + 1, 1, 2, 3, 4, 5, 6, 100000);

            }
            st.Stop();
            Console.WriteLine(st.Elapsed);


            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var transaction = connection.BeginTransaction();

                //using (var sqlBulk = new SqlBulkCopy(connection, SqlBulkCopyOptions.KeepIdentity, transaction))
                //{
                //    sqlBulk.DestinationTableName = "Sales";
                //    sqlBulk.WriteToServer(dt);
                using (var sqlBulk = new SqlBulkCopy(_connectionString))
                {
                    sqlBulk.DestinationTableName = "Sales";
                    sqlBulk.BatchSize = 10000;
                    sqlBulk.WriteToServer(dt);
                }
                //}
            }
            Console.ReadKey();
        }
        
    }
}

