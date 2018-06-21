using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SubjectRepository : IRepository<Subject>
    {
        BasEntities db = new BasEntities();
        public bool Ekle(Subject c)
        {
            Subject sc = new Subject();
            sc.CreatedDate = c.CreatedDate;
            sc.SectionID = c.SectionID;
            sc.Name = c.Name;
            sc.IsActive = c.IsActive;
            db.Subjects.Add(sc);
            db.SaveChanges();
            return true;
            
        }

        public bool Guncelle(Subject c)
        {
            Subject cs = db.Subjects.FirstOrDefault(pro => pro.Id == c.Id);
            cs.SectionID = c.SectionID;
            cs.Name = c.Name;
            cs.CreatedDate = c.CreatedDate;
            db.SaveChanges();
            return true;
        }

        public bool DurumGuncelle(int bolumid, bool aktif)
        {
            Subject kullanici = db.Subjects.FirstOrDefault(k => k.Id == bolumid);

            kullanici.IsActive = aktif;
            db.SaveChanges();

            return true;
        }

        public List<Subject> HepsiniGetir()
        {
            var sonuc = db.Subjects.ToList();
            return sonuc;
        }

        public bool Sil(int id)
        {
            Subject pf = db.Subjects.FirstOrDefault(pro => pro.Id == id);
            db.Subjects.Remove(pf);
            db.SaveChanges();
            return true;
        }

        public Subject TekGetir(int id)
        {
            var sonuc = db.Subjects.Find(id);
            return sonuc;
        }
    }
}
