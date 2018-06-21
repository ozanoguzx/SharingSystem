using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
   public class SectionsRepository : IRepository<Section>
    {
        BasEntities db = new BasEntities();
        public bool Ekle(Section c)
        {
            Section section = new Section();
            section.Classrooms = c.Classrooms;
            section.CreatedDate = c.CreatedDate;
            section.IsActive = c.IsActive;
            section.Name = c.Name;
            //section.UserID = c.UserID;
            db.Sections.Add(section);
            db.SaveChanges();
            return true;
        }

        public bool Guncelle(Section c)
        {
            Section section = db.Sections.FirstOrDefault(pro => pro.Id == c.Id);
            section.Classrooms = c.Classrooms;
            section.CreatedDate = c.CreatedDate;
            section.IsActive = c.IsActive;
            section.Name = c.Name;
            //section.UserID = c.UserID;
            db.SaveChanges();
            return true;
        }
        public List<Section> Getir()
        {
            var sonuc = db.Sections.ToList();
            return sonuc;
        }

        public List<Section> HepsiniGetir()
        {

            var sonuc = db.Sections.ToList();
            return sonuc;
        }

        public bool DurumGuncelle(int bolumid, bool aktif)
        {
            Section kullanici = db.Sections.FirstOrDefault(k => k.Id == bolumid);

            kullanici.IsActive = aktif;
            db.SaveChanges();

            return true;
        }

        public bool Sil(int id)
        {
            Section pf = db.Sections.FirstOrDefault(pro => pro.Id == id);
            db.Sections.Remove(pf);
            db.SaveChanges();
            return true;
        }

        public Section TekGetir(int id)
        {
            var sonuc = db.Sections.Find(id);
            return sonuc;
        }
    }
}
