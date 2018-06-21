using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{

    public class TrainerRepository : IRepository<Trainer>
    {
        BasEntities db = new BasEntities();
        public bool Ekle(Trainer c)
        {
            Trainer trainer = new Trainer();
            trainer.FirstName = c.FirstName;
            trainer.LastName = c.LastName;
            trainer.Password = c.Password;
            trainer.SectionID = c.SectionID;
            trainer.EMail = c.EMail;
            trainer.CreatedDate = c.CreatedDate;
            trainer.IsActive = c.IsActive;
            trainer.IsSuperAdmin = c.IsSuperAdmin;
            //trainer.UserID = c.UserID;
            trainer.Username = c.Username;
            trainer.FullName = c.FullName;
            trainer.Classrooms = c.Classrooms;
            db.Trainers.Add(trainer);
            db.SaveChanges();
            return true;
        }
        public List<Trainer> Getir()
        { 
            var sonuc = db.Trainers.ToList();
            return sonuc;
        }

        public bool DurumGuncelle(int sinifId, bool aktif)
        {
            Trainer kullanici = db.Trainers.FirstOrDefault(k => k.Id == sinifId);

            kullanici.IsActive = aktif;
            db.SaveChanges();

            return true;
        }
        public bool Guncelle(Trainer c)
        {
            Trainer trainer = db.Trainers.FirstOrDefault(pro => pro.Id == c.Id);
            trainer.FirstName = c.FirstName;
            trainer.Password = c.Password;
            trainer.SectionID = c.SectionID;
            trainer.EMail = c.EMail;
            trainer.CreatedDate = c.CreatedDate;
            trainer.IsActive = c.IsActive;
            trainer.IsSuperAdmin = c.IsSuperAdmin;
            trainer.LastName = c.LastName;
            //trainer.UserID = c.UserID;
            trainer.FullName = c.FullName;
            trainer.Username = c.Username;
            trainer.Classrooms = c.Classrooms;
            db.SaveChanges();
            return true;
        }

        public List<Trainer> HepsiniGetir()
        {
            var sonuc = db.Trainers.ToList();
            return sonuc;
        }

        public bool Sil(int id)
        {
            Trainer pf = db.Trainers.FirstOrDefault(pro => pro.Id == id);
            db.Trainers.Remove(pf);
            db.SaveChanges();
            return true;
        }

        public Trainer TekGetir(int id)
        {
            var sonuc = db.Trainers.Find(id);
            return sonuc;
        }
    }
}
