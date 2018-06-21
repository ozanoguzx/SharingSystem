using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class PresentationRepository : IRepository<Presentation>
    {
        BasEntities db = new BasEntities();
        public bool Ekle(Presentation c)
        {
            Presentation cs = new Presentation();
            cs.CreatedDate = c.CreatedDate;
            cs.IsActive = c.IsActive;
            cs.FileUrl = c.FileUrl;
            cs.Id = c.Id;
            cs.TrainerID = c.TrainerID;
            cs.SubjectID = c.SubjectID;
            cs.SectionID = c.SectionID;
            cs.TrainerID = c.TrainerID;
            cs.ClassroomID = c.ClassroomID;
            cs.FileName = c.FileName;
            cs.TrainerID = c.TrainerID;
            db.Presentations.Add(cs);
            db.SaveChanges();
            return true;
        }

        public bool Guncelle(Presentation c)
        {
            Presentation cs = db.Presentations.FirstOrDefault(pro => pro.Id == c.Id);
            cs.CreatedDate = c.CreatedDate;
            cs.IsActive = c.IsActive;
            cs.FileUrl = c.FileUrl;
            cs.FileName = c.FileName;
            cs.Id = c.Id;
            cs.TrainerID = c.TrainerID;
            cs.TrainerID = cs.TrainerID;
            cs.TrainerID = c.TrainerID;
            db.SaveChanges();
            return true;
        }

        public List<Presentation> HepsiniGetir()
        {
            var sonuc = db.Presentations.OrderByDescending(p => p.CreatedDate).ToList();
            return sonuc;
        }

        public bool Sil(int id)
        {
            Presentation pf = db.Presentations.FirstOrDefault(pro => pro.Id == id);
            db.Presentations.Remove(pf);
            db.SaveChanges();
            return true;
        }

        public bool DurumGuncelle(int sunumid, bool aktif)
        {
            Presentation sunum = db.Presentations.FirstOrDefault(k => k.Id == sunumid);

            sunum.IsActive = aktif;
            db.SaveChanges();

            return true;
        }


        public Presentation TekGetir(int id)
        {

            var sonuc = db.Presentations.Find(id);
            return sonuc;

        }
    }
}