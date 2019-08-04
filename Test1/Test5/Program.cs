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

namespace Test5
{
    class Program
    {
        static void Main(string[] args)
        {
            //Xoá tất cả record sử dụng SQL
            //ISalesRepository rp = new SalesRepository();
            //rp.Delete();
                        
            //bulkinsert();           
            //WorkA();
            WorkB();
            Console.ReadKey();
        }
        //Chạy 100 Task get query
        public static void WorkA()
        {
            var tasks = new Task[100];
            Stopwatch st = Stopwatch.StartNew();
            var timeSpan = new List<TimeSpan>();
            timeSpan.Add(st.Elapsed);
            ISalesRepository rp = new SalesRepository();
            Random random = new Random();
            //Random ID từ 1->10tr
            int randomID = random.Next(1, 10000000);
            //Lấy danh sách dữ liệu theo ID
            for (int i = 0; i < tasks.Length; i++)
            {
                tasks[i] = Task.Run(() =>
                {
                    rp.Where(x => x.Id == randomID);                 
                });

            }
            Task.WaitAll(tasks);
            st.Stop();
            double doubleAverageTicks = timeSpan.Average(t => t.Ticks);
            Console.WriteLine(st.Elapsed);
            Console.WriteLine("Time TB: " + doubleAverageTicks);

        }
        //Chạy 50 Task thực hiện các tác vụ khác nha 
        public static void WorkB()
        {
            var tasks = new Task[50];
            Stopwatch st = Stopwatch.StartNew();
            var timeSpan = new List<TimeSpan>();
            timeSpan.Add(st.Elapsed);
            ISalesRepository rp = new SalesRepository();
            Random random = new Random();
            //Random ID từ 1->50
            int randomID = random.Next(1, 200);
            //Lấy danh sách dữ liệu theo ID
            for (int i = 0; i < tasks.Length; i++)
            {
                tasks[i] = Task.Run(() =>
                {
                    if (randomID % 2 == 0)
                    {
                        Sales s = new Sales() { Salesperson = "songoku", so1 = 2, so2 = 4, so3 = 5 };
                        rp.Add(s);
                    }
                    else if (randomID % 4 == 0)
                    {
                        Sales s = new Sales() { Id = randomID, Salesperson = "me thien ha", so1 =31312, so2 = 424143, so3 = 1897414 };
                        rp.Update(s);
                    }
                    else
                        rp.GetById(randomID);
                });

            }
            Task.WaitAll(tasks);
            st.Stop();
            double doubleAverageTicks = timeSpan.Average(t => t.Ticks);
            Console.WriteLine(st.Elapsed);
            Console.WriteLine("Time TB: " + doubleAverageTicks);
        }
        //Insert lượng lớn dữ liệu sử dụng Bulkinsert
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
