using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
   public class ClassRepository : IRepository<Classroom>
    {
        BasEntities db = new BasEntities();
        public bool Ekle(Classroom c)
        {
            Classroom cs = new Classroom();
            cs.ClosedDate = c.ClosedDate;
            cs.CreatedDate = c.CreatedDate;
            cs.IsActive = c.IsActive;
            cs.SectionID = cs.SectionID;
            cs.Name = cs.Name;
            cs.TrainerID = c.TrainerID;
            cs.Name = c.Name;
            cs.SectionID = c.SectionID;
            db.Classrooms.Add(cs);
            db.SaveChanges();
            return true;   
        }

        public bool Guncelle(Classroom c)
        {
            Classroom cs = db.Classrooms.FirstOrDefault(pro => pro.Id == c.Id);
            cs.ClosedDate = c.ClosedDate;
            cs.Name = cs.Name;
            cs.CreatedDate = c.CreatedDate;
            cs.IsActive = c.IsActive;
            cs.SectionID = cs.SectionID;
            cs.TrainerID = c.TrainerID;
            db.SaveChanges();
            return true;
        }

        public List<Classroom> HepsiniGetir()
        {
            var sonuc = db.Classrooms.ToList();
            return sonuc;
        }

        public bool Sil(int id)
        {
            Classroom pf = db.Classrooms.FirstOrDefault(pro => pro.Id == id);
            db.Classrooms.Remove(pf);
            db.SaveChanges();
            return true;
        }

        public bool DurumGuncelle(int sinifId, bool aktif)
        {
            Classroom kullanici = db.Classrooms.FirstOrDefault(k => k.Id == sinifId);

            kullanici.IsActive = aktif;
            db.SaveChanges();

            return true;
        }


        public Classroom TekGetir(int id)
        {
            Classroom sonuc = db.Classrooms.Find(id);
            //.Select(pro => new CLASSROOM()
            //{
            //    ClassRoomID = pro.ClassRoomID,
            //     ClassName=pro.ClassName,
            //    ClosedDate = pro.ClosedDate,
            //    CreatedDate = pro.CreatedDate,
            //    IsActive = pro.IsActive,
            //    SECTION = pro.SECTION,
            //    SectionID = pro.SectionID,
            //    STUDENT = pro.STUDENT,
            //    StudentID = pro.StudentID,
            //    TrainerID = pro.TrainerID,
            //    UserID = pro.UserID,
            //});

            return sonuc;

        }
    }
}
