using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThucHanh.Domain;
using ThucHanh.Repositories;

namespace ThucHanh
{
    class Program
    {
        static void Main(string[] args)
        {
            //Stopwatch st = Stopwatch.StartNew();

            {
              

                //Product p = new Product() { name="bbbbbbb"};

                //for (int i = 0; i <= 5000; i++)
                //    if (i > 0)
                //    {
                //        Product p = new Product();
                //        IProductRepository rp = new ProductRepository();
                //        rp.Add(p);
                //    }


                //session.Query<Product>()
                //    .Where(c => c.Id == 5004)
                //    .UpdateBuilder()
                //    .Set(c => c.name, c => "su dung update builder")
                //    .Set(c => c.soluong, c => 4000)
                //    .Set(c => c.loai, c => "Vip")
                //    .Set(c => c.gia, c => 90000)
                //    .Set(c => c.so8, c => 1)
                //    .Set(c => c.so9, c => 1)
                //    .Set(c => c.so10, c => 1)
                //    .Update();

                //var fromDB = session.Get<Product>(5004);
                //Console.WriteLine(fromDB.Id + "," + fromDB.name + "," + fromDB.xuatxu + "," + fromDB.gia);

                //IQuery query = session.CreateSQLQuery("SELECT * FROM Product Where Id=5004").AddEntity(typeof(Product));
                //IList<Product> proInfo = query.List<Product>();
                //foreach (var a in proInfo)
                //{
                //    Console.WriteLine(a.Id + "," + a.name + "," + a.xuatxu + "," + a.gia);
                //}

                //IQuery query = session.CreateQuery("FROM Product WHERE Id='5004'");
                //IList<Product> pInfo = query.List<Product>();
                //foreach(var p in pInfo)
                //{
                //    Console.WriteLine(p.Id + "," + p.name + "," + p.xuatxu + "," + p.gia);
                //}

                //var fromDB = session.Load<Product>(5004);
                //Console.WriteLine(fromDB.Id + "," + fromDB.name + "," + fromDB.xuatxu + "," + fromDB.gia);
                //tr.Commit();

                //session.Query<Product>()
                //    .Where(c => c.Id == 5004)
                //    .Delete();
                //tr.Commit();

                //var query = session.CreateQuery("Delete Product Where id='4999'")
                //    .ExecuteUpdate();
                //tr.Commit();

                //        }
                //    }
                //}            
                //st.Stop();
                //Console.WriteLine("\n\n\n\n\n"+st.Elapsed);
                //Console.ReadKey();

                IProductRepository rp = new ProductRepository();
                rp.GetAll();
                Random rd = new Random();
                List<Task> list = new List<Task>();
                for (int i = 0; i < 1000; i++)
                {
                    Task t = new Task(() =>
                    {
                        Random r = new Random();
                        int a = r.Next(1, 10000);                     
                        rp.GetbyId(a);
                        rp.Delete(a);                      
                    });
                    t.Start();
                    list.Add(t);
                }
                Task.WaitAll(list.ToArray());

                //var tmp = new ProductRepository();
                //tmp.GetbyId(1);

                //int count_id = 0;
                //int count_non_id = 0;
                //int temp;
                //Random r = new Random();           
                //IProductRepository rp = new ProductRepository();            
                //for (int i = 0; i < 100; i++)
                //{
                //    Task t = new Task(() =>
                //    {
                //        temp = r.Next(0, 10000);
                //        //Lay Id chia het cho 12, sau do xoa Id nay
                //        if (temp % 12 == 0)
                //        {
                //            IList<Product> list = rp.Where(x => x.Id == temp);
                //            if (rp.Kiemtra(temp) == true)
                //            {
                //                count_id++;
                //                Stopwatch st = Stopwatch.StartNew();
                //                foreach (var p in list)
                //                {
                //                    Console.WriteLine("Id " + p.Id + " da duoc lay ra!!!");
                //                    rp.Delete(p);
                //                    Console.WriteLine("Id " + p.Id + " da duoc xoa!!");
                //                }
                //                st.Stop();
                //                Console.WriteLine(st.Elapsed);
                //            }
                //            else
                //            {
                //                count_non_id++;
                //                Console.WriteLine("Id " + temp + " khong co trong csdl!!");
                //            }
                //        }
                //        //Insert nhung Id chia het cho 5
                //        else if(temp%5==0)
                //        {
                //            count_id++;
                //            Product p = new Product() { Id = temp, xuatxu = "Thai Lan" };
                //            rp.Add(p);                     
                //        }
                //        //Update theo Id
                //        else
                //        {
                //            if (rp.Kiemtra(temp) == true)
                //            {
                //                rp.Update(temp);
                //            }
                //            else
                //            {
                //                count_non_id++;
                //                Console.WriteLine("Id " + temp + " khong co trong csdl!!");
                //            }
                //        }
                //    });
                //    t.Start();
                //    list_t.Add(t);
                //}
                //Task.WaitAll(list_t.ToArray());


                //foreach (var p in list)
                //{
                //    rp.Delete(p);
                //}

                //Task t1 = new Task(() =>
                // {
                //     IProductRepository rp = new ProductRepository();
                //     rp.GetbyId(2);
                //     rp.Delete(2);
                // });
                //t1.Start();
                //t1.Wait();

                //Task t2 = new Task(() =>
                //{
                //    IProductRepository rp = new ProductRepository();
                //    rp.GetbyId(2);
                //    //rp.Update(2);
                //});
                //t2.Start();
                //t2.Wait();          
                //Random r = new Random();

                //IProductRepository rp = new ProductRepository();
                //List<Task> task = new List<Task>();
                //for (int i = 0; i < 5; i++)
                //{
                //    //int m = r.Next(59, 5090);
                //    int m = r.Next(0,5090);
                //    Task t = new Task(() =>
                //    {                    
                //        var fromDB = rp.GetByLoai("Vip");
                //        foreach (var a in fromDB)
                //        {                       
                //            if(m==a.Id)
                //            {
                //                rp.Update(m);                          
                //                if (m % 2 == 0)
                //                {
                //                    rp.Delete(m);                              
                //                }
                //                if (m % 3 == 0)
                //                {
                //                    if (rp.Kiemtra(m) == true)
                //                    {
                //                        rp.Update1(m);                                  
                //                    }
                //                    else
                //                    {
                //                        Console.WriteLine(a.Id + " khong co trong CSDL");
                //                    }
                //                }
                //                if (m % 5==0) 
                //                {                                                                                                                                    
                //                    Product p = new Product() {xuatxu = "Campuchia", loai = "Least", gia = 5993 };
                //                    rp.Add(p);

                //                }
                //            }
                //        }

                //    });
                //    t.Start();
                //    task.Add(t);
                //}
                //Task.WaitAll(task.ToArray());

                //    string[] v = { "Vip", "Normal", "Good", "Least"};
                //    string[] h = { "Vip", "Normal", "Good", "Least" };
                //    string[] j = { "Vip", "Normal", "Good", "Least"};
                //    string[] k = { "Vip", "Normal", "Good", "Least"};
                //    string[] g = { "Vip", "Normal", "Good", "Least"};
                //    int index1 = r.Next(v.Length);
                //    int index2 = r.Next(h.Length);
                //    int index3 = r.Next(j.Length);
                //    int index4 = r.Next(k.Length);
                //    int index5 = r.Next(g.Length);
                //    Console.WriteLine("TASK 1");
                //    Task task1 = new Task(() =>
                //    {
                //        var fromDB = rp.GetByLoai("Vip");
                //        Stopwatch st = Stopwatch.StartNew();               
                //        foreach (var a in fromDB)
                //        {
                //            int i = r.Next(59, 5100);
                //            Console.WriteLine(a.Id + "," + a.loai + "," + a.xuatxu);  
                //            if(i==a.Id)
                //            {
                //                rp.Delete(i);
                //                Console.WriteLine("Xoa thanh cong Id " + i);                      
                //            }
                //            else
                //            {
                //                Console.WriteLine(i + " khong co doi tuong de xoa!!");
                //            }
                //        }
                //        st.Stop();
                //        Console.WriteLine("THOI GIAN HOAN THANH HET: "+st.Elapsed);

                //    });
                //    task1.Start();
                //    task1.Wait();

                //    Console.WriteLine("TASK 2");
                //    Task task2 = new Task(() =>
                //    {
                //        var fromDB = rp.GetByLoai("Vip");
                //        Stopwatch st = Stopwatch.StartNew();
                //        foreach (var a in fromDB)
                //        {
                //            int i = r.Next(59, 5100);
                //            Console.WriteLine(a.Id + "," + a.loai + "," + a.xuatxu);             
                //            if (i == a.Id)
                //            {
                //                rp.Update(i);
                //                Console.WriteLine("Xoa thanh cong Id " + i);

                //            }
                //            else
                //            {
                //                Console.WriteLine(i + " khong co doi tuong de xoa!!");
                //            }
                //        }
                //        st.Stop();
                //        Console.WriteLine("THOI GIAN HOAN THANH HET: " + st.Elapsed);
                //    });
                //    task2.Start();
                //    task2.Wait();

                //    Console.WriteLine("TASK 3");
                //    Task task3 = new Task(() =>
                //    {
                //        var fromDB = rp.GetByLoai("Vip");
                //        Stopwatch st = Stopwatch.StartNew();
                //        foreach (var a in fromDB)
                //        {
                //            int i = r.Next(59, 5100);
                //            Console.WriteLine(a.Id + "," + a.loai + "," + a.xuatxu);
                //            if (i == a.Id)
                //            {
                //                rp.Update(i);
                //                Console.WriteLine("Xoa thanh cong Id " + i);

                //            }
                //            else
                //            {
                //                Console.WriteLine(i + " khong co doi tuong de xoa!!");
                //            }
                //        }
                //        st.Stop();
                //        Console.WriteLine("THOI GIAN HOAN THANH HET: " + st.Elapsed);
                //    });
                //    task3.Start();
                //    task3.Wait();

                //    Console.WriteLine("TASK 4");
                //    Task task4 = new Task(() =>
                //    {
                //        var fromDB = rp.GetByLoai("Vip");
                //        Stopwatch st = Stopwatch.StartNew();
                //        foreach (var a in fromDB)
                //        {
                //            int i = r.Next(59, 5100);
                //            Console.WriteLine(a.Id + "," + a.loai + "," + a.xuatxu);
                //            if (i == a.Id)
                //            {
                //                rp.Update(i);
                //                Console.WriteLine("Xoa thanh cong Id " + i);
                //            }
                //            else
                //            {
                //                Console.WriteLine(i + " khong co doi tuong de xoa!!");
                //            }
                //        }
                //        st.Stop();
                //        Console.WriteLine("THOI GIAN HOAN THANH HET: " + st.Elapsed);
                //    });
                //    task4.Start();
                //    task4.Wait();

                //    Console.WriteLine("Vip");
                //    Task task5 = new Task(() =>
                //    {
                //        var fromDB = rp.GetByLoai(k[index4]);
                //        Stopwatch st = Stopwatch.StartNew();
                //        foreach (var a in fromDB)
                //        {
                //            int i = r.Next(59, 5100);
                //            Console.WriteLine(a.Id + "," + a.loai + "," + a.xuatxu);
                //            if (i == a.Id)
                //            {
                //                rp.Update(i);
                //                Console.WriteLine("Xoa thanh cong Id " + i);
                //            }
                //            else
                //            {
                //                Console.WriteLine(i + " khong co doi tuong de xoa!!");
                //            }
                //        }
                //        st.Stop();
                //        Console.WriteLine("THOI GIAN HOAN THANH HET: " + st.Elapsed);
                //    });
                //    task5.Start();
                //    task5.Wait();
                //    //Console.WriteLine("CO tat ca " + count_id + " Id da duoc lay ra!");
                //    //Console.WriteLine("Co tat ca " + count_non_id + " khong co trong CSDL");

                //    var tasks = new Task[1];
                //    for(int i=0;i<tasks.Length;i++)
                //    {
                //        tasks[i] = Task.Run(() => {
                //            Console.WriteLine(i);
                //            Add();
                //        });                               
                //    }

                //    Task.WaitAll(tasks);           
                //    Console.ReadKey();
                //}
                //static void Add()
                //{

                //    var r = new Random();
                //    for (int i = 0; i < 10; i++) // Thực hiện  1 task 10 lần
                //    {
                //        var a = r.Next(1, 100);
                //        if (a % 2 == 0)
                //        {
                //            Console.WriteLine("abc");
                //        }
                //        else
                //            Console.WriteLine("oiu");
                //    }
                //}
            }
        }
    }
}

