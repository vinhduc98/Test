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
            //var testobs = rp.CreateTestObjects(5000000);
            Stopwatch st = Stopwatch.StartNew();
            //bulkinsert();
            rp.Add(5000000);

            //using (var session = FluentNHibernateHleper.GetStatelessSession())
            //using (ITransaction tran = session.BeginTransaction())
            //{
            //    for (int i = 0; i < 5000000; i++)
            //    {
            //        Sales s = new Sales() { Id = i+1  };
            //        session.Delete(s);
            //    }
            //    tran.Commit();
            //}

            st.Stop();
            Console.WriteLine(st.Elapsed);
            //WorkA();
            /*rp.Delete();*/ //Xoá tat ca record su dung SQL
            //WorkA();
            //WorkB();
            //WorkC();
            Console.ReadKey();
        }
        //Chay 100 Task get query
        public static void WorkA()
        {
            var tasks = new Task[100];  //Tao mang 100 task
            var timeSpan = new List<TimeSpan>();
            Random random = new Random();
            Stopwatch st;
            bool kiemtra = true;
            //while (kiemtra)
            //{
                ISalesRepository rp = new SalesRepository();
                int randomID = random.Next(1, 10000000);     //Random ID t? 1->10tr
                for (int i = 0; i < tasks.Length; i++)
                {
                    tasks[i] = Task.Run(() =>
                    {
                        st = Stopwatch.StartNew();
                        //Get theo Id  
                        rp.Where(x => x.Id == randomID);
                        //rp.GetById(randomID);
                        st.Stop();
                        Console.WriteLine(st.Elapsed);
                        timeSpan.Add(st.Elapsed);
                        //if (randomID == 22564783)
                        //    kiemtra = false;
                    });
                }
                // randomId ng?u nhiên các s? này s? d?ng vòng l?p
                //if (randomID == 9 || randomID == 19||randomID == 39 || randomID == 49 || randomID == 59 || 
                //    randomID == 69 || randomID == 79 || randomID == 89 || randomID == 99)
                //    kiemtra = false;
            //}
            Task.WaitAll(tasks);
            double doubleAverageTicks = timeSpan.Average(t => t.Ticks);
            Console.WriteLine("Time TB: " + doubleAverageTicks);
        }
        //Chay 50 Task thuc hien các tác vu khác nhau 
        public static void WorkB()
        {
            var tasks = new Task[100];
            Stopwatch st;
            var timeSpan = new List<TimeSpan>();
            object locksales = new object();
            ISalesRepository rp = new SalesRepository();
            Random random = new Random();
            //Random ID t? 1->10tr   
            
            //L?y danh sách d? li?u theo ID
            for (int i = 0; i < tasks.Length; i++)
            {
                int randomID = random.Next(1, 6000000);
                Console.WriteLine(randomID);
                st = Stopwatch.StartNew();
                tasks[i] = Task.Run(() =>
                {
                    if (randomID % 2 == 0)
                    {
                        var fromDB = rp.GetById(randomID);
                        foreach (var sale in fromDB)
                        {
                            Console.WriteLine(sale.Id + "," + sale.Salesperson + "," + sale.Area);
                        }                     
                    }
                    if (randomID % 4 == 0)
                    {
                        Sales s = new Sales() { Id = randomID, Salesperson = "me thien ha", so1 = 31312, so2 = 424143, so3 = 1897414 };
                        Sales s1 = new Sales() { Id = randomID };
                        rp.Delete(s1);
                        rp.Update(s);
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
            TimeSpan doubleAverageTicks = new TimeSpan(Convert.ToInt64(timeSpan.Average(t => t.Ticks)));
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

            for (int i = 0; i < 5000000; i++)
            {
                dt.Rows.Add(i + 1, "So " + i + 1, "KV:" + i + 1, 1, 2, 3, 4, 5, 6, 100000);

            }

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var transaction = connection.BeginTransaction();

                using (var sqlBulk = new SqlBulkCopy(connection, SqlBulkCopyOptions.KeepIdentity, transaction))
                {
                    sqlBulk.DestinationTableName = "Sales";
                    sqlBulk.WriteToServer(dt);
                }
                using (var sqlBulk = new SqlBulkCopy(_connectionString))
                {
                    sqlBulk.DestinationTableName = "Sales";
                    sqlBulk.BatchSize = 100000;
                    sqlBulk.WriteToServer(dt);
                }
                //}
            }
        }
        public static void WorkC()
        {
            ISalesRepository rp = new SalesRepository();
            IPurchaseRepository rp1 = new PurchaseRepository();
            Random ran = new Random();

            Purchase p = new Purchase() { purchaseperson = "Cong lo" };
            Sales s = new Sales() { Salesperson = "qua duong" };
            object ob = new object();
            Stopwatch st = Stopwatch.StartNew();
            //Task t1 = Task.Run(() =>
            //    {
            //        rp1.Add(p);
            //        rp.Add(s);
            //        rp1.Add(p);
            //        rp1.Add(p);
            //        rp.Add(s);

            //    });
            //Task t2 = Task.Run(() =>
            //  {
            //      int randomID = ran.Next(1, 1000000);
            //      rp.GetById(randomID);
            //      rp1.GetById(randomID+100);
            //      rp1.Add(p);
            //      rp.Add(s);
            //  });
            //Task.WaitAll(t1,t2);          
            var tasks= new Task[3];
            for(int i=0;i<tasks.Length;i++)
            {
                tasks[0] = Task.Run(() =>
                    {
                        rp.Add(s);
                        rp1.Add(p);                        
                        rp1.Add(p);
                       
                    });
                tasks[1] = Task.Run(() =>
                  {
                      int randomID = ran.Next(1, 1000000);
                      rp.GetById(randomID);
                      rp1.GetById(randomID + 100);

                  });
                tasks[2] = Task.Run(() =>
                  {
                      rp1.Add(p);
                      rp.Add(s);
                  });
            }
            Task.WaitAll(tasks);
            st.Stop();
            Console.WriteLine(st.Elapsed);
        }

    }
}

