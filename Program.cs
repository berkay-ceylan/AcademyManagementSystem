using _51_entity_lab2.concretes;
using _51_entity_lab2.Contexts;
using _51_entity_lab2.Contracts;
using _51_entity_lab2.DTOs;
using _51_entity_lab2.Enums;
using _51_entity_lab2.Models;
using System.Threading.Tasks.Dataflow;

namespace _51_entity_lab2
{
    internal class Program
    {
        private static bool dogrumu;

        static void Main(string[] args)
        {
            AppDbContext context = new AppDbContext();
            IcategoryRepo categoryRepo = new CategoryRepo(context);
            ICourseRepo courseRepo = new CourseRepo(context);
            ICourseDetailRepo courseDetailRepo = new CoursDetailRepo(context);
            IEnrollmentRepo enrollmentRepo = new EnrollmentRepo(context);
            IInstructorRepo instructorRepo = new InstructorRepo(context);
            IStudentRepo studentRepo = new StudentRepo(context);

            while (true)
            {
                Console.WriteLine("Devam etmek için entera basın");
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine("==== ÖĞRENCİ KAYIT SİSTEMİ ====\n");
                Console.WriteLine("0. Çıkış");
                Console.WriteLine("1. Kategori Listele");
                Console.WriteLine("2. Kategori Ekle");
                Console.WriteLine("3. Kategori Sil");
                Console.WriteLine("4. Kategori Güncelle");
                Console.WriteLine("5. Kategori Çöp Kutusu");
                Console.WriteLine("6. Öğrenci Listele");
                Console.WriteLine("7. Öğrenci Ekle");
                Console.WriteLine("8. Öğrenci sil");
                Console.WriteLine("9. Öğrenci güncelle");
                Console.WriteLine("10. Öğrenci Çöp Kutusu");
                Console.WriteLine("11. Öğretmen Listele");
                Console.WriteLine("12. Öğretmen Ekle");
                Console.WriteLine("13. Öğretmen sil");
                Console.WriteLine("14. Öğretmen güncelle");
                Console.WriteLine("15. Öğretmen Çöp Kutusu");
                Console.WriteLine("16. Kurs Listele");
                Console.WriteLine("17. Kurs Ekle");
                Console.WriteLine("18. Kurs sil");
                Console.WriteLine("19. Kurs güncelle");
                Console.WriteLine("20. Kurs Çöp Kutusu");
                Console.WriteLine("21. Kayıtları Listele");
                Console.WriteLine("22. Yeni Kayıt");
                Console.WriteLine("22. Yeni Kayıt");


                Console.Write("Seçiminiz: ");
                string input = Console.ReadLine();
                Console.Clear();
                switch (input)
                {
                    case "0":
                        return;
                    case "1":
                        GetAllCategory(categoryRepo);
                        break;
                    case "2":
                        CreateCategory(categoryRepo);
                        break;
                    case "3":
                        DeleteCategory(categoryRepo);
                        break;
                    case "4":
                        UpdateCategory(categoryRepo);
                        break;
                    case "5":
                        UndoDelete(categoryRepo);
                        break;
                    case "6":
                        GetAllStudent(studentRepo);
                        break;
                    case "7":
                        CreateStudent(categoryRepo, studentRepo);
                        break;
                    case "8":
                        DeleteStudent(studentRepo);
                        break;
                    case "9":
                        UpdateStudent(studentRepo);
                        break;
                    case "10":

                        UndoDeletestudent(studentRepo);
                        break;
                    case "11":
                        GetAllInstructor(instructorRepo);
                        break;
                    case "12":
                        CreateInstructor(categoryRepo, instructorRepo);
                        break;
                    case "13":
                        DeleteInstructor(instructorRepo);
                        break;
                    case "14":

                        UpdateInstructor(instructorRepo);
                        break;
                    case "15":
                        UndoDeleteInstructor(instructorRepo);
                        break;

                    case "16":
                        GetAllCourse(categoryRepo, courseRepo, instructorRepo);
                        break;
                    case "17":
                        CreateCourse(categoryRepo, courseRepo, instructorRepo);
                        break;
                    case "18":

                        DeleteCourse(courseRepo, categoryRepo, instructorRepo, studentRepo);
                        break;

                    case "19":

                        UpdateCourse(courseRepo, categoryRepo, instructorRepo);

                        break;
                    case "20":
                        UndoDeleteCourse(courseRepo);

                        break;
                    case "21":
                        GetAllEnrollment(courseRepo, enrollmentRepo, studentRepo);
                        break;
                    case "22":
                        CreateEnrollment(categoryRepo, courseRepo, enrollmentRepo, studentRepo);
                        break;

                    default:
                        Console.WriteLine("Geçersiz seçim!");
                        break;
                }
            }

            static void GetAllCategory(IcategoryRepo categoryRepo)
            {
                foreach (var item in categoryRepo.GetAll())
                {
                    Console.WriteLine($"[{item.Id}] {item.Name}");
                }
            }

            static void CreateCategory(IcategoryRepo categoryRepo)
            {
                Console.Write("Yeni Kategori Adı: ");
                string name = Console.ReadLine();
                categoryRepo.Add(new Category() { Name = name });
                Console.WriteLine(categoryRepo.save() ? "Başarılı" : "Başarısız!");
            }

            static void DeleteCategory(IcategoryRepo categoryRepo)
            {
                GetAllCategory(categoryRepo);
                Console.Write("Silinecek Kategori Id: ");
                int catId = int.Parse(Console.ReadLine());
                Console.Write("a - çöp kutusana gönder, b - sil");
                string result = Console.ReadLine();
                if (result == "a")
                {
                    categoryRepo.SoftDelete(catId);
                    Console.WriteLine(categoryRepo.save() ? "Başarılı" : "Başarısız!");
                }
                else if (result == "b")
                {
                    categoryRepo.Delete(catId);
                    Console.WriteLine(categoryRepo.save() ? "Başarılı" : "Başarısız!");
                }
                else
                    Console.WriteLine("Yanlış bir seçim yaptınız!");
            }

            static void UpdateCategory(IcategoryRepo categoryRepo)
            {
                GetAllCategory(categoryRepo);
                Console.Write("Güncelenecek Kategori Id:");
                int result = int.Parse(Console.ReadLine());
                var oldCategory = categoryRepo.GetById(result);
                Console.Write("Yeni Ad: ");
                string newName = Console.ReadLine();
                oldCategory.Name = newName;
                categoryRepo.Update(oldCategory);
                Console.WriteLine(categoryRepo.save() ? "Başarılı" : "Başarısız!");
            }

            static void UndoDelete(IcategoryRepo categoryRepo)
            {
                foreach (var item in categoryRepo.GetAll(false))
                {
                    Console.WriteLine($"[{item.Id}] {item.Name}");
                }
                Console.Write("Geri Almak Istediğiniz Id Yoksa 0 Girin: ");
                int result = int.Parse(Console.ReadLine());
                if (result > 0)
                {
                    categoryRepo.UndoDelete(result);
                    Console.WriteLine(categoryRepo.save() ? "Başarılı" : "Başarısız!");
                }

            }

            static void GetAllStudent(IStudentRepo studentRepo)
            {
                foreach (var item in studentRepo.GetAll())
                {
                    Console.WriteLine($"[{item.Id}] {item.Fullname}");
                }
            }

            static void CreateStudent(IcategoryRepo categoryRepo, IStudentRepo studentRepo)
            {
                Console.Write("Öğrenci Adı: ");
                string name = Console.ReadLine();
                Console.Write("Öğrenci Soyadı: ");
                string lastName = Console.ReadLine();
                studentRepo.Add(new Student() { Firstname = name, Lastname = lastName });
                Console.WriteLine(categoryRepo.save() ? "Başarılı" : "Başarısız!");
            }

            static void GetAllInstructor(IInstructorRepo instructorRepo)
            {
                foreach (var item in instructorRepo.GetAll())
                {
                    Console.WriteLine($"[{item.Id}] {item.Name}");
                }
            }

            static void GetAllCourse(IcategoryRepo categoryRepo, ICourseRepo courseRepo, IInstructorRepo instructorRepo)
            {
                Console.Write("a - Hepsini Getir, b - Kategoriye Göre, c - Isme göre, d - Egitmene göre");
                string result = Console.ReadLine();
                switch (result)
                {
                    case "a":
                        foreach (var item in courseRepo.GetDetails())
                        {
                            Console.WriteLine($"[{item.Id}] {item.Title} {item.Description} {item.Duration}");
                        }
                        break;
                    case "b":
                        Console.WriteLine("Kategoriler");
                        GetAllCategory(categoryRepo);
                        Console.Write("Kategori Id: ");
                        int catId = int.Parse(Console.ReadLine());
                        foreach (var item in courseRepo.GetByCategoryId(catId))
                        {
                            Console.WriteLine($"[{item.Id}] {item.Title} Kategori: {item.CategoryId}");
                        }
                        break;
                    case "c":
                        Console.Write("Kategori Adı: ");
                        string catName = Console.ReadLine();
                        foreach (var item in courseRepo.FindByTitle(catName))
                        {
                            Console.WriteLine($"[{item.Id}] {item.Title}");
                        }
                        break;
                    case "d":
                        Console.WriteLine("Eğitmenler");
                        GetAllInstructor(instructorRepo);
                        Console.Write("Eğitmen Id: ");
                        int insId = int.Parse(Console.ReadLine());
                        foreach (var item in courseRepo.GetByCategoryId(insId))
                        {
                            Console.WriteLine($"[{item.Id}] {item.Title} Kategori: {item.CategoryId}");
                        }
                        Console.WriteLine(categoryRepo.save() ? "Başarılı" : "Başarısız!");
                        break;
                    default:
                        return;
                }
            }

            static void CreateInstructor(IcategoryRepo categoryRepo, IInstructorRepo instructorRepo)
            {
                Console.Write("Yeni Öğretmen Adı: ");
                string name = Console.ReadLine();
                instructorRepo.Add(new Instructor() { Name = name });
                Console.WriteLine(categoryRepo.save() ? "Başarılı" : "Başarısız!");
            }

            static void CreateCourse(IcategoryRepo categoryRepo, ICourseRepo courseRepo, IInstructorRepo instructorRepo)
            {
                Console.Write("Kurs Adı: ");
                string courseName = Console.ReadLine();
                GetAllCategory(categoryRepo);
                Console.Write("Kategori Id: ");
                int catId = int.Parse(Console.ReadLine());
                GetAllInstructor(instructorRepo);
                Console.Write("Eğtimen Id: ");
                int insId = int.Parse(Console.ReadLine());
                Console.Write("Kurs Açıklaması: ");
                string description = Console.ReadLine();
                Console.Write("Kurs Süresi: ");
                int duration = int.Parse(Console.ReadLine());
                var courseDetail = new CourseDetail { Description = description, Duration = duration };
                courseRepo.Add(new Course() { Title = courseName, CategoryId = catId, InstructorId = insId, Coursedetails = courseDetail });
                Console.WriteLine(categoryRepo.save() ? "Başarılı" : "Başarısız!");
            }

            static void GetAllEnrollment(ICourseRepo courseRepo, IEnrollmentRepo enrollmentRepo, IStudentRepo studentRepo)
            {
                Console.Write("a - Hepsini Getir, b - Öğrenciye Göre, c - Kursa Göre: ");
                string result = Console.ReadLine();
                switch (result)
                {
                    case "a":
                        foreach (var item in enrollmentRepo.GetAll())
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    case "b":
                        GetAllStudent(studentRepo);
                        Console.Write("Student Id: ");
                        int studentId = int.Parse(Console.ReadLine());
                        foreach (var item in enrollmentRepo.GetByStudentId(studentId))
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    case "c":
                        foreach (var item in courseRepo.GetDetails())
                        {
                            Console.WriteLine($"[{item.Id}] {item.Title} {item.Description} {item.Duration}");
                        }
                        Console.Write("Kurs Id: ");
                        int courseId = int.Parse(Console.ReadLine());
                        foreach (var item in enrollmentRepo.GetByCourseId(courseId))
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    default:
                        break;
                }
            }

            static void CreateEnrollment(IcategoryRepo categoryRepo, ICourseRepo courseRepo, IEnrollmentRepo enrollmentRepo, IStudentRepo studentRepo)
            {
                GetAllStudent(studentRepo);
                Console.Write("Student Id: ");
                int studentID = int.Parse(Console.ReadLine());
                foreach (var item in courseRepo.GetDetails())
                {
                    Console.WriteLine($"[{item.Id}] {item.Title} {item.Description} {item.Duration}");
                }
                Console.Write("Kurs Id: ");
                int courseId = int.Parse(Console.ReadLine());
                Console.Write("Fiyat: ");
                decimal price = decimal.Parse(Console.ReadLine());
                enrollmentRepo.Add(new Enrollment() { CourseId = courseId, StudentId = studentID, Price = price });
                Console.WriteLine(categoryRepo.save() ? "Başarılı" : "Başarısız!");
            }

            static void DeleteStudent(IStudentRepo studentRepo)
            {
                GetAllStudent(studentRepo);
                Console.Write("Silinecek öğrenci Id: ");
                int catId = int.Parse(Console.ReadLine());
                Console.Write("a - çöp kutusana gönder, b - sil");
                string result = Console.ReadLine();
                if (result == "a")
                {
                    studentRepo.SoftDelete(catId);
                    Console.WriteLine(studentRepo.save() ? "Başarılı" : "Başarısız!");
                }
                else if (result == "b")
                {
                    studentRepo.Delete(catId);
                    Console.WriteLine(studentRepo.save() ? "Başarılı" : "Başarısız!");
                }
                else
                    Console.WriteLine("Yanlış bir seçim yaptınız!");
            }
            static void UpdateStudent(IStudentRepo studentRepo)
            {
                GetAllStudent(studentRepo);
                Console.Write("Güncelenecek Kategori Id:");
                int result = int.Parse(Console.ReadLine());
                var oldstudent = studentRepo.GetById(result);
                Console.Write("Yeni Ad: ");
                string newName = Console.ReadLine();
                oldstudent.Firstname = newName;
                studentRepo.Update(oldstudent);
                Console.WriteLine(studentRepo.save() ? "Başarılı" : "Başarısız!");
            }
            static void UndoDeletestudent(IStudentRepo studentRepo)
            {
                foreach (var item in studentRepo.GetAll(false))
                {
                    Console.WriteLine($"[{item.Id}] {item.Fullname}");
                }
                Console.Write("Geri Almak Istediğiniz Id Yoksa 0 Girin: ");
                int result = int.Parse(Console.ReadLine());
                if (result > 0)
                {
                    studentRepo.UndoDelete(result);
                    Console.WriteLine(studentRepo.save() ? "Başarılı" : "Başarısız!");
                }

            }
            static void DeleteInstructor(IInstructorRepo instructorRepo)
            {
                GetAllInstructor(instructorRepo);
                Console.Write("Silinecek öğretmen Id: ");
                int catId = int.Parse(Console.ReadLine());
                Console.Write("a - çöp kutusana gönder, b - sil");
                string result = Console.ReadLine();
                if (result == "a")
                {
                    instructorRepo.SoftDelete(catId);
                    Console.WriteLine(instructorRepo.save() ? "Başarılı" : "Başarısız!");
                }
                else if (result == "b")
                {
                    instructorRepo.Delete(catId);
                    Console.WriteLine(instructorRepo.save() ? "Başarılı" : "Başarısız!");
                }
                else
                    Console.WriteLine("Yanlış bir seçim yaptınız!");
            }

            static void UpdateInstructor(IInstructorRepo instructorRepo)
            {
                GetAllInstructor(instructorRepo);
                Console.Write("Güncelenecek Kategori Id:");
                int result = int.Parse(Console.ReadLine());
                var oldınstructor = instructorRepo.GetById(result);
                Console.Write("Yeni Ad: ");
                string newName = Console.ReadLine();
                oldınstructor.Name = newName;
                instructorRepo.Update(oldınstructor);
                Console.WriteLine(instructorRepo.save() ? "Başarılı" : "Başarısız!");
            }

            static void UndoDeleteInstructor(IInstructorRepo instructorRepo)
            {
                foreach (var item in instructorRepo.GetAll(false))
                {
                    Console.WriteLine($"[{item.Id}] {item.Name}");
                }
                Console.Write("Geri Almak Istediğiniz Id Yoksa 0 Girin: ");
                int result = int.Parse(Console.ReadLine());
                if (result > 0)
                {
                    instructorRepo.UndoDelete(result);
                    Console.WriteLine(instructorRepo.save() ? "Başarılı" : "Başarısız!");
                }

            }


            static void DeleteCourse(ICourseRepo courseRepo, IcategoryRepo categoryRepo, IInstructorRepo instructorRepo, IStudentRepo studentRepo)
            {
                GetAllCourse(categoryRepo, courseRepo, instructorRepo);
                Console.Write("Silinecek kurs Id: ");
                int catId = int.Parse(Console.ReadLine());
                Console.Write("a - çöp kutusana gönder, b - sil");
                string result = Console.ReadLine();
                if (result == "a")
                {
                    courseRepo.SoftDelete(catId);
                    Console.WriteLine(courseRepo.save() ? "Başarılı" : "Başarısız!");
                }
                else if (result == "b")
                {
                    courseRepo.Delete(catId);
                    Console.WriteLine(courseRepo.save() ? "Başarılı" : "Başarısız!");
                }
                else
                    Console.WriteLine("Yanlış bir seçim yaptınız!");

            }

            static void UpdateCourse(ICourseRepo courseRepo, IcategoryRepo categoryRepo, IInstructorRepo instructorRepo)
            {
                GetAllCourse(categoryRepo, courseRepo, instructorRepo);
                Console.Write("Güncelenecek Kurs Id:");
                int result = int.Parse(Console.ReadLine());
                var oldCourse = courseRepo.GetById(result);
                Console.Write("Yeni Ad: ");
                string newName = Console.ReadLine();
                oldCourse.Title = newName;
                courseRepo.Update(oldCourse);
                Console.WriteLine(courseRepo.save() ? "Başarılı" : "Başarısız!");
            }

            static void UndoDeleteCourse(ICourseRepo courseRepo)
            {
                foreach (var item in courseRepo.GetAll(false))
                {
                    Console.WriteLine($"[{item.Id}] {item.Title}");
                }
                Console.Write("Geri Almak Istediğiniz Id Yoksa 0 Girin: ");
                int result = int.Parse(Console.ReadLine());
                if (result > 0)
                {
                    courseRepo.UndoDelete(result);
                    Console.WriteLine(courseRepo.save() ? "Başarılı" : "Başarısız!");
                }

            }


        }

    }
}