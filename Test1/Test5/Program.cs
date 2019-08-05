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
            ISalesRepository rp = new SalesRepository();
            //rp.Delete(); //Xoá tất cả record sử dụng SQL
            //bulkinsert();
            //WorkA();
            WorkB();
            Console.ReadKey();
        }
        //Chạy 100 Task get query
        public static void WorkA()
        {           
            var tasks = new Task[100];  //Tạo mảng 100 task
            var timeSpan = new List<TimeSpan>();            
            ISalesRepository rp = new SalesRepository();
            Random random = new Random();            
            Stopwatch st;
            bool kiemtra = true;
            //while (kiemtra)
            //{
                int randomID = random.Next(1, 100);     //Random ID từ 1->10tr
                for (int i = 0; i < tasks.Length; i++)
                {
                    tasks[i] = Task.Run(() =>
                    {                        
                        st = Stopwatch.StartNew();
                        //Get theo Id  
                        //rp.Where(x => x.Id == randomID);
                        rp.GetListbyId(randomID);
                        //rp.GetById(randomID);
                        st.Stop();
                        Console.WriteLine(st.Elapsed);
                        timeSpan.Add(st.Elapsed);                        
                    });                   
                }
                // randomId ngẫu nhiên các số này sẽ dừng vòng lặp
                //if (randomID == 9 || randomID == 19||randomID == 39 || randomID == 49 || randomID == 59 || 
                //    randomID == 69 || randomID == 79 || randomID == 89 || randomID == 99)
                //    kiemtra = false;
            //}
            Task.WaitAll(tasks);                                 
            double doubleAverageTicks = timeSpan.Average(t => t.Ticks);            
            Console.WriteLine("Time TB: " + doubleAverageTicks);
        }
        //Chạy 50 Task thực hiện các tác vụ khác nhau 
        public static void WorkB()
        {
            var tasks = new Task[50];
            Stopwatch st;
            var timeSpan = new List<TimeSpan>();           
            ISalesRepository rp = new SalesRepository();
            Random random = new Random();
            //Random ID từ 1->50
            int randomID = random.Next(1, 200);
            //Lấy danh sách dữ liệu theo ID
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
                    sqlBulk.BatchSize = 5000;
                    sqlBulk.WriteToServer(dt);
                }
                //}
            }
            Console.ReadKey();
        }
        
    }
}
