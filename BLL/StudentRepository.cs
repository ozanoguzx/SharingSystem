using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class StudentRepository : IRepository<Student>
    {
        BasEntities db = new BasEntities();
        public bool Ekle(Student student)
        {
            //Classroom classroom;
            //foreach (var cls in student.Classrooms)
            //{
            //    classroom = new Classroom();
            //    classroom.Id = cls.Id;
            //    classroom.Name = cls.Name;
            //    classroom.SectionID = cls.SectionID;
            //    classroom.TrainerID = cls.TrainerID;
            //    classroom.CreatedDate = cls.CreatedDate;
            //    classroom.ClosedDate = cls.ClosedDate;
            //    classroom.IsActive = cls.IsActive;


            //    //clNew = db.Classrooms.FirstOrDefault(clt => clt.Id == cls.Id);
            //    this.student.Classrooms.Add(classroom);
            //}
            
        

            Student stu = new Student();
            //Classroom cls = new Classroom();
            //cls = c.Classrooms.FirstOrDefault();
            stu.CreatedDate = DateTime.Now;
            stu.IsActive = student.IsActive;
            stu.LastName = student.LastName;
            stu.FirstName = student.FirstName;
            stu.Email = student.Email;
            stu.Password = student.Password;
            stu.UserName = student.UserName;
            stu.SectionID = student.SectionID;

            
            
            
            
            foreach (var item in student.Classrooms)
            {
                stu.Classrooms.Add(item);
                
                
            }
            //stu.Classrooms.Add(cr);
            //db.Set<Student>().Attach(stu);
            //db.Entry(stu).State = System.Data.Entity.EntityState.Added;
            db.Students.Add(student);
            db.SaveChanges();
            return true;
        }


        public bool DurumGuncelle(int ogrenciid, bool aktif)
        {
            Student kullanici = db.Students.FirstOrDefault(k => k.Id == ogrenciid);

            kullanici.IsActive = aktif;
            db.SaveChanges();

            return true;
        }
        public bool Guncelle(Student c)
        {
            Student stu = db.Students.FirstOrDefault(pro => pro.Id == c.Id);
            stu.CreatedDate = c.CreatedDate;
            stu.IsActive = c.IsActive;
            stu.LastName = c.LastName;
            stu.FirstName = c.FirstName;
            stu.Email = c.Email;
            stu.Password = c.Password;
            stu.UserName = c.UserName;
            db.SaveChanges();
            return true;
        }
        public bool DetayGuncelle(Student c)
        {
            Student stu = db.Students.FirstOrDefault(k => k.Id == c.Id);
            stu.Id = c.Id;
            stu.LastName = c.LastName;
            stu.FirstName = c.FirstName;
            stu.Email = c.Email;
            db.SaveChanges();
            return true;
        }

        public bool SifreGuncelle(Student c)
        {
            Student stu = db.Students.FirstOrDefault(pro => pro.Id == c.Id);
            stu.Password = c.Password;
            db.SaveChanges();
            return true;
        }

        public List<Student> HepsiniGetir()
        {
            var sonuc = db.Students.OrderByDescending(p => p.FirstName).ToList();
            return sonuc;
        }

        public bool Sil(int id)
        {
            Student pf = db.Students.FirstOrDefault(pro => pro.Id == id);
            db.Students.Remove(pf);
            db.SaveChanges();
            return true;
        }

        public Student TekGetir(int id)
        {
            var sonuc = db.Students.Find(id);
            return sonuc;
        }
    }
}
